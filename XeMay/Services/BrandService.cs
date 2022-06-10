using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.Brand;
using XeMay.Model;
using XeMay.Models;

namespace XeMay.Services
{
    public interface IBrandService
    {

        Task<List<BrandViewModel>> GetAll();
        Task<List<BrandViewModel>> GetEdit(long id);

        Task<int> Create(BrandRequest request);

        Task<BrandViewModel> Detail(long id);

        Task<BrandRequest> Edit(long id);

        Task<int> Update(BrandRequest request);

        Task<int> Delete(long id);
    }
    public class BrandService : IBrandService
    {
        private readonly XeMayContext _context;

        public BrandService(XeMayContext context)
        {
            _context = context;
        }

        public async Task<int> Create(BrandRequest request)
        {
            try
            {
                Brand brand = new Brand()
                {
                    Name = request.Name,                  
                    Description = request.Description,   
                    Url = request.Url,
                    Status = request.Status,
                    CreateDate = DateTime.Now
                };
                _context.Brands.Add(brand);
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
                Brand brand = await _context.Brands.FindAsync(id);
                if (brand == null) return -1;
                _context.Brands.Remove(brand);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<BrandViewModel> Detail(long id)
        {
            try
            {
                Brand brand = await _context.Brands.FindAsync(id);
                BrandViewModel detailBrandViewModel = new BrandViewModel()
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    Description = brand.Description,
                    Url = brand.Url,
                    Status = brand.Status
                };
                return detailBrandViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<BrandRequest> Edit(long id)
        {
            try
            {
                Brand brand = await _context.Brands.FindAsync(id);
                if (brand == null) return null;
                BrandRequest updateBrandsViewModel = new BrandRequest()
                {
                    Id = brand.Id,
                    Name = brand.Name,
                    Description = brand.Description, 
                    Url = brand.Url,
                    Status = brand.Status
                };

                return updateBrandsViewModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<BrandViewModel>> GetAll()
        {

            return await _context.Brands.Select(p => new BrandViewModel()
            {

                Id = p.Id,
                Name = p.Name,               
                Description = p.Description,
                Url = p.Url,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }

        public async Task<List<BrandViewModel>> GetEdit(long id)
        {

            return await _context.Brands.Where(x=>x.Id!=id).Select(p => new BrandViewModel()
            {

                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Url = p.Url,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }



        public async Task<int> Update(BrandRequest request)
        {
            try
            {
                Brand brand = await _context.Brands.FindAsync(request.Id);
                if (brand == null) return -1;
                brand.Name = request.Name;
                brand.Description = request.Description;           
                brand.Url = request.Url;
                brand.Status = request.Status;
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
