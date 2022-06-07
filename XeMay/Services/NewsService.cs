using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.News;
using XeMay.Data;
using XeMay.Models;

namespace XeMay.Services
{
     public interface INewsService
    {
        Task<List<NewsViewModel>> GetAll();

        Task<int> Create(NewsCreateRequest request);

        Task<NewsViewModel> Detail(long id);

        Task<NewsUpdateRequest> Edit(long id);

        Task<int> Update(NewsUpdateRequest request);

        Task<int> Delete(long id);
    }
    public class NewsService:INewsService
    {
        private readonly XeMayContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "uploads";

        public NewsService(XeMayContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<List<NewsViewModel>> GetAll()
        {

            return await _context.News.Select(p => new NewsViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Logo = p.Logo,
                CategotyName = p.Category.Name,
                Description = p.Description,
                Detail = p.Detail,
                IsNew = p.IsNew,
                Url = p.Url,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }

         public async Task<int> Create(NewsCreateRequest request)
        {
            try
            {
                News news = new News()
                {
                    Name = request.Name,
                    Logo = request.Logo,
                    CategoryId = request.CategoryId,
                    Description = request.Description,
                    Detail = request.Detail,
                    IsNew = request.IsNew,                 
                    Url = request.Url,
                    DisplayOrder = request.DisplayOrder,
                    Status = request.Status,
                    CreateDate = DateTime.Now
                };
                if(request.FileUpload != null)
                {
                    news.Logo = await SaveFile(request.FileUpload);
                }
                _context.News.Add(news);
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
                News news = await _context.News.FindAsync(id);
                if (news == null) return -1;
                if (news.Logo != null)
                {
                    await _storageService.DeleteFileAsync(news.Logo);
                }
                _context.News.Remove(news);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<NewsViewModel> Detail(long id)
        {
            try
            {
                return await _context.News.Where(x=>x.Id==id).Select(p => new NewsViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Logo = p.Logo,
                    CategotyName = p.Category.Name,
                    Description = p.Description,
                    Detail = p.Detail,
                    IsNew = p.IsNew
                }).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<NewsUpdateRequest> Edit(long id)
        {
            try
            {
                News news = await _context.News.FindAsync(id);
                if (news == null) return null;
                NewsUpdateRequest updateNewsViewModel = new NewsUpdateRequest()
                {
                    Id = news.Id,
                    Name = news.Name,
                    Logo = news.Logo,
                    CategoryId = news.CategoryId,
                    Description = news.Description,
                    Detail = news.Detail,
                    IsNew = news.IsNew,
                    Url = news.Url,
                    DisplayOrder = news.DisplayOrder,
                    Status = news.Status
                };

                return updateNewsViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }  
     
        public async Task<int> Update(NewsUpdateRequest request)
        {
            try
            {
                News news = await _context.News.FindAsync(request.Id);
                if (news == null) return -1;
                news.Name = request.Name;
                news.CategoryId = request.CategoryId;
                news.Description = request.Description;
                news.Detail = request.Detail;
                news.IsNew = request.IsNew;
                news.Url = request.Url;
                news.DisplayOrder = request.DisplayOrder;
                news.Status = request.Status;
                news.EditDate = DateTime.Now;
                if (request.FileUpload != null)
                {
                    await _storageService.DeleteFileAsync(news.Logo);
                    news.Logo = await SaveFile(request.FileUpload);
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
