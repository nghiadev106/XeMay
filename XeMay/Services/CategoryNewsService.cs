using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.CategoryNews;
using XeMay.Model;
using XeMay.Models;

namespace XeMay.Services
{
    public interface ICategoryNewsService
    {

        Task<List<CategoryNewsViewModel>> GetAll();
        Task<List<CategoryNewsViewModel>> GetEdit(long id);

        Task<int> Create(CategoryNewsRequest request);

        Task<CategoryNewsViewModel> Detail(long id);

        Task<CategoryNewsRequest> Edit(long id);

        Task<int> Update(CategoryNewsRequest request);

        Task<int> Delete(long id);
    }
    public class CategoryNewsService : ICategoryNewsService
    {
        private readonly XeMayContext _context;

        public CategoryNewsService(XeMayContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CategoryNewsRequest request)
        {
            try
            {
                CategoriesNew categoriesNew = new CategoriesNew()
                {
                    Name = request.Name,
                    Description = request.Description,
                    ShowHome = request.ShowHome,
                    Url = request.Url,
                    DisplayOrder = request.DisplayOrder,
                    Status = request.Status,
                    CreateDate = DateTime.Now
                };
                _context.CategoriesNews.Add(categoriesNew);
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
                CategoriesNew CategoriesNew = await _context.CategoriesNews.FindAsync(id);
                if (CategoriesNew == null) return -1;
                _context.CategoriesNews.Remove(CategoriesNew);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<CategoryNewsViewModel> Detail(long id)
        {
            try
            {
                CategoriesNew category = await _context.CategoriesNews.FindAsync(id);
                CategoryNewsViewModel detailCategoryNewsViewModel = new CategoryNewsViewModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    ShowHome = category.ShowHome,
                    Description = category.Description,
                    Url = category.Url,
                    DisplayOrder = category.DisplayOrder,
                    Status = category.Status
                };
                return detailCategoryNewsViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<CategoryNewsRequest> Edit(long id)
        {
            try
            {
                CategoriesNew category = await _context.CategoriesNews.FindAsync(id);
                if (category == null) return null;
                CategoryNewsRequest updateCategorysViewModel = new CategoryNewsRequest()
                {
                    Id = category.Id,
                    Name = category.Name,
                    ShowHome = category.ShowHome,
                    Description = category.Description,
                    Url = category.Url,
                    DisplayOrder = category.DisplayOrder,
                    Status = category.Status
                };

                return updateCategorysViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<CategoryNewsViewModel>> GetAll()
        {

            return await _context.CategoriesNews.Select(p => new CategoryNewsViewModel()
            {

                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ShowHome = p.ShowHome,
                Url = p.Url,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }

        public async Task<List<CategoryNewsViewModel>> GetEdit(long id)
        {

            return await _context.CategoriesNews.Where(x => x.Id != id).Select(p => new CategoryNewsViewModel()
            {

                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ShowHome = p.ShowHome,
                Url = p.Url,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }



        public async Task<int> Update(CategoryNewsRequest request)
        {
            try
            {
                CategoriesNew category = await _context.CategoriesNews.FindAsync(request.Id);
                if (category == null) return -1;
                category.Name = request.Name;
                category.Description = request.Description;
                category.Url = request.Url;
                category.DisplayOrder = request.DisplayOrder;
                category.Status = request.Status;
                category.ShowHome = request.ShowHome;
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }
    }
}
