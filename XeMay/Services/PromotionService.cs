using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.Promotion;
using XeMay.Data;
using XeMay.Models;

namespace XeMay.Services
{
    public interface IPromotionService
    {
        Task<List<PromotionViewModel>> GetAll();

        Task<int> Create(PromotionCreateRequest request);

        Task<PromotionViewModel> Detail(long id);

        Task<PromotionUpdateRequest> Edit(long id);

        Task<int> Update(PromotionUpdateRequest request);

        Task<int> Delete(long id);
    }
    public class PromotionService : IPromotionService
    {
        private readonly XeMayContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "uploads";

        public PromotionService(XeMayContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<List<PromotionViewModel>> GetAll()
        {

            return await _context.Promotions.Select(p => new PromotionViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Logo = p.Logo,
                Link = p.Link,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }

        public async Task<int> Create(PromotionCreateRequest request)
        {
            try
            {
                Promotion promotion = new Promotion()
                {
                    Name = request.Name,
                    Logo = request.Logo,
                    Link = request.Link,
                    DisplayOrder = request.DisplayOrder,
                    Status = request.Status,
                    CreateDate = DateTime.Now
                };
                if (request.FileUpload != null)
                {
                    promotion.Logo = await SaveFile(request.FileUpload);
                }
                _context.Promotions.Add(promotion);
                int res = await _context.SaveChangesAsync();
                return res;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public async Task<int> Delete(long id)
        {
            try
            {
                Promotion promotion = await _context.Promotions.FindAsync(id);
                if (promotion == null) return -1;
                if (promotion.Logo != null)
                {
                    await _storageService.DeleteFileAsync(promotion.Logo);
                }
                _context.Promotions.Remove(promotion);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<PromotionViewModel> Detail(long id)
        {
            try
            {
                return await _context.Promotions.Where(x => x.Id == id).Select(p => new PromotionViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Logo = p.Logo,
                    Link = p.Link
                }).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<PromotionUpdateRequest> Edit(long id)
        {
            try
            {
                Promotion promotion = await _context.Promotions.FindAsync(id);
                if (promotion == null) return null;
                PromotionUpdateRequest updatePromotionViewModel = new PromotionUpdateRequest()
                {
                    Id = promotion.Id,
                    Name = promotion.Name,
                    Logo = promotion.Logo,
                    Link = promotion.Link,
                    DisplayOrder = promotion.DisplayOrder,
                    Status = promotion.Status
                };

                return updatePromotionViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int> Update(PromotionUpdateRequest request)
        {
            try
            {
                Promotion promotion = await _context.Promotions.FindAsync(request.Id);
                if (promotion == null) return -1;
                promotion.Name = request.Name;
                promotion.Link = request.Link;
                promotion.DisplayOrder = request.DisplayOrder;
                promotion.Status = request.Status;
                if (request.FileUpload != null)
                {
                    await _storageService.DeleteFileAsync(promotion.Logo);
                    promotion.Logo = await SaveFile(request.FileUpload);
                }
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

    }
}
