using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.Category;
using XeMay.Model;
using XeMay.Models;

namespace XeMay.Services
{
    public interface ICategoryService
    {

        Task<List<CategoryViewModel>> GetAll();
        Task<List<CategoryViewModel>> GetEdit(long id);

        Task<int> Create(CategoryRequest request);

        Task<CategoryViewModel> Detail(long id);

        Task<CategoryRequest> Edit(long id);

        Task<int> Update(CategoryRequest request);

        Task<int> Delete(long id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly XeMayContext _context;

        public CategoryService(XeMayContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CategoryRequest request)
        {
            try
            {
                Category category = new Category()
                {
                    Name = request.Name,                  
                    Description = request.Description,   
                    ParentId=request.ParentId,
                    ShowHome = request.ShowHome,
                    Url = request.Url,
                    DisplayOrder = request.DisplayOrder,
                    Status = request.Status,
                    CreateDate = DateTime.Now
                };
                _context.Categories.Add(category);
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
                Category category = await _context.Categories.FindAsync(id);
                if (category == null) return -1;
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<CategoryViewModel> Detail(long id)
        {
            try
            {
                Category category = await _context.Categories.FindAsync(id);
                CategoryViewModel detailCategoryViewModel = new CategoryViewModel()
                {
                    Id = category.Id,
                    Name = category.Name,
                    ParentId=category.ParentId,
                    ShowHome = category.ShowHome,
                    Description = category.Description,
                    Url = category.Url,
                    DisplayOrder = category.DisplayOrder,
                    Status = category.Status
                };
                return detailCategoryViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<CategoryRequest> Edit(long id)
        {
            try
            {
                Category category = await _context.Categories.FindAsync(id);
                if (category == null) return null;
                CategoryRequest updateCategorysViewModel = new CategoryRequest()
                {
                    Id = category.Id,
                    Name = category.Name,
                    ParentId=category.ParentId,
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

        public async Task<List<CategoryViewModel>> GetAll()
        {

            return await _context.Categories.Select(p => new CategoryViewModel()
            {

                Id = p.Id,
                Name = p.Name,               
                ParentId=p.ParentId,
                Description = p.Description,
                ShowHome = p.ShowHome,
                Url = p.Url,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }

        public async Task<List<CategoryViewModel>> GetEdit(long id)
        {

            return await _context.Categories.Where(x=>x.Id!=id).Select(p => new CategoryViewModel()
            {

                Id = p.Id,
                Name = p.Name,
                ParentId = p.ParentId,
                Description = p.Description,
                ShowHome = p.ShowHome,
                Url = p.Url,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }



        public async Task<int> Update(CategoryRequest request)
        {
            try
            {
                Category category = await _context.Categories.FindAsync(request.Id);
                if (category == null) return -1;
                category.Name = request.Name;
                category.ParentId = request.ParentId;
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
