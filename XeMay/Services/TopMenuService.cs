using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.TopMenu;
using XeMay.Data;
using XeMay.Models;

namespace XeMay.Services
{
    public interface ITopMenuService
    {
        Task<List<TopMenuViewModel>> GetAll();

        Task<int> Create(TopMenuCreateRequest request);

        Task<TopMenuViewModel> Detail(long id);

        Task<TopMenuUpdateRequest> Edit(long id);

        Task<int> Update(TopMenuUpdateRequest request);

        Task<int> Delete(long id);
    }
    public class TopMenuService : ITopMenuService
    {
        private readonly XeMayContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "uploads";

        public TopMenuService(XeMayContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<List<TopMenuViewModel>> GetAll()
        {

            return await _context.TopMenus.Select(p => new TopMenuViewModel()
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

        public async Task<int> Create(TopMenuCreateRequest request)
        {
            try
            {
                TopMenu topMenu = new TopMenu()
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
                    topMenu.Logo = await SaveFile(request.FileUpload);
                }
                _context.TopMenus.Add(topMenu);
                int res = await _context.SaveChangesAsync();
                return res;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> Delete(long id)
        {
            try
            {
                TopMenu topMenu = await _context.TopMenus.FindAsync(id);
                if (topMenu == null) return -1;
                if (topMenu.Logo != null)
                {
                    await _storageService.DeleteFileAsync(topMenu.Logo);
                }
                _context.TopMenus.Remove(topMenu);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<TopMenuViewModel> Detail(long id)
        {
            try
            {
                return await _context.TopMenus.Where(x => x.Id == id).Select(p => new TopMenuViewModel()
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

        public async Task<TopMenuUpdateRequest> Edit(long id)
        {
            try
            {
                TopMenu topMenu = await _context.TopMenus.FindAsync(id);
                if (topMenu == null) return null;
                TopMenuUpdateRequest updateTopMenuViewModel = new TopMenuUpdateRequest()
                {
                    Id = topMenu.Id,
                    Name = topMenu.Name,
                    Logo = topMenu.Logo,
                    Link = topMenu.Link,
                    DisplayOrder = topMenu.DisplayOrder,
                    Status = topMenu.Status
                };

                return updateTopMenuViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int> Update(TopMenuUpdateRequest request)
        {
            try
            {
                TopMenu topMenu = await _context.TopMenus.FindAsync(request.Id);
                if (topMenu == null) return -1;
                topMenu.Name = request.Name;
                topMenu.Link = request.Link;
                topMenu.DisplayOrder = request.DisplayOrder;
                topMenu.Status = request.Status;
                if (request.FileUpload != null)
                {
                    await _storageService.DeleteFileAsync(topMenu.Logo);
                    topMenu.Logo = await SaveFile(request.FileUpload);
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
