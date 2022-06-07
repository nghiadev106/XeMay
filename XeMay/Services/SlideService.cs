using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.Slide;
using XeMay.Data;
using XeMay.Models;

namespace XeMay.Services
{
    public interface ISlideService
    {
        Task<List<SlideViewModel>> GetAll();

        Task<int> Create(SlideCreateRequest request);

        Task<SlideViewModel> Detail(long id);

        Task<SlideUpdateRequest> Edit(long id);

        Task<int> Update(SlideUpdateRequest request);

        Task<int> Delete(long id);
    }
    public class SlideService : ISlideService
    {
        private readonly XeMayContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "uploads";

        public SlideService(XeMayContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<List<SlideViewModel>> GetAll()
        {

            return await _context.Slides.Select(p => new SlideViewModel()
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

        public async Task<int> Create(SlideCreateRequest request)
        {
            try
            {
                Slide slide = new Slide()
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
                    slide.Logo = await SaveFile(request.FileUpload);
                }
                _context.Slides.Add(slide);
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
                Slide slide = await _context.Slides.FindAsync(id);
                if (slide == null) return -1;
                if (slide.Logo != null)
                {
                    await _storageService.DeleteFileAsync(slide.Logo);
                }
                _context.Slides.Remove(slide);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<SlideViewModel> Detail(long id)
        {
            try
            {
                return await _context.Slides.Where(x => x.Id == id).Select(p => new SlideViewModel()
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

        public async Task<SlideUpdateRequest> Edit(long id)
        {
            try
            {
                Slide slide = await _context.Slides.FindAsync(id);
                if (slide == null) return null;
                SlideUpdateRequest updateSlideViewModel = new SlideUpdateRequest()
                {
                    Id = slide.Id,
                    Name = slide.Name,
                    Logo = slide.Logo,
                    Link = slide.Link,         
                    DisplayOrder = slide.DisplayOrder,
                    Status = slide.Status
                };

                return updateSlideViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<int> Update(SlideUpdateRequest request)
        {
            try
            {
                Slide slide = await _context.Slides.FindAsync(request.Id);
                if (slide == null) return -1;
                slide.Name = request.Name;
                slide.Link = request.Link;
                slide.DisplayOrder = request.DisplayOrder;
                slide.Status = request.Status;
                if (request.FileUpload != null)
                {
                    await _storageService.DeleteFileAsync(slide.Logo);
                    slide.Logo = await SaveFile(request.FileUpload);
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
