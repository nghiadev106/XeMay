using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.Product;
using XeMay.Model;
using XeMay.Models;

namespace XeMay.Services
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetDiscountProduct();

        Task<List<ProductViewModel>> GetAll();

        Task<int> Create(ProductCreateRequest request);

        Task<ProductViewModel> Detail(long id);

        Task<ProductUpdateRequest> Edit(long id);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(long id);
    }
    public class ProductService:IProductService
    {
        private readonly XeMayContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "uploads";

        public ProductService(XeMayContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            return await _context.Products.Select(p => new ProductViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Logo = p.Logo,
                CategotyName = p.Category.Name,
                BrandName = p.Brand.Name,
                Description = p.Description,
                Price = p.Price,
                Detail = p.Detail,
                PriceDiscount = p.PriceDiscount,
                IsNew = p.IsNew,
                Url = p.Url,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
                Year=p.Year,
                Engine=p.Engine,
                CreateDate = p.CreateDate
            }).OrderByDescending(x=> x.CreateDate).ToListAsync();
        }

        public async Task<List<ProductViewModel>> GetDiscountProduct()
        {

            return await _context.Products.Where(x=>x.Status==1 && x.PriceDiscount!=null).Select(p => new ProductViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Logo = p.Logo,
                CategotyName = p.Category.Name,
                BrandName = p.Brand.Name,
                Description = p.Description,
                Price = p.Price,
                Detail = p.Detail,
                PriceDiscount = p.PriceDiscount,
                IsNew = p.IsNew,
                Url = p.Url,
                Year = p.Year,
                Engine = p.Engine,
                BrandId=p.BrandId,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }

      
         public async Task<int> Create(ProductCreateRequest request)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Product product = new Product()
                    {
                        Name = request.Name,
                        Logo = request.Logo,
                        CategoryId = request.CategoryId,
                        Description = request.Description,
                        Price = request.Price,
                        Detail = request.Detail,
                        PriceDiscount = request.PriceDiscount,
                        IsNew = request.IsNew,
                        Url = request.Url,
                        BrandId=request.BrandId,
                        Year = request.Year,
                        Engine = request.Engine,
                        DisplayOrder = request.DisplayOrder,
                        Status = request.Status,
                        CreateDate = DateTime.Now
                    };
                    if (request.FileUpload != null)
                    {
                        product.Logo = await SaveFile(request.FileUpload);
                    }
                    _context.Products.Add(product);
                    await _context.SaveChangesAsync();

                    if (request.Files!=null)
                    {
                        foreach (var item in request.Files)
                        {
                            ProductImage image = new ProductImage()
                            {
                                ProductId = product.Id,
                                Path = await SaveFile(item)
                            };
                            _context.ProductImages.Add(image);
                        }
                    };

                    int res = await _context.SaveChangesAsync();
                    transaction.Commit();
                    return res;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return -1;
                }
            }
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Product product = await _context.Products.FindAsync(request.Id);
                    if (product == null) return -1;
                    product.Name = request.Name;
                    product.CategoryId = request.CategoryId;
                    product.Description = request.Description;
                    product.Price = request.Price;
                    product.Detail = request.Detail;
                    product.PriceDiscount = request.PriceDiscount;
                    product.IsNew = request.IsNew;
                    product.Url = request.Url;
                    product.Year = request.Year;
                    product.BrandId = request.BrandId;
                    product.Engine = request.Engine;
                    product.DisplayOrder = request.DisplayOrder;
                    product.Status = request.Status;
                    product.EditDate = DateTime.Now;
                    if (request.FileUpload != null)
                    {
                        await _storageService.DeleteFileAsync(product.Logo);
                        product.Logo = await SaveFile(request.FileUpload);
                    }          

                    if (request.Files!=null)
                    {
                        List<ProductImage> images = await _context.ProductImages.Where(x => x.ProductId == product.Id).ToListAsync();
                        if (images.Count() > 0)
                        {
                            foreach (var item in images)
                            {
                                _context.ProductImages.Remove(item);
                                await _storageService.DeleteFileAsync(item.Path);
                            }
                        }

                        foreach (var item in request.Files)
                        {
                            ProductImage image = new ProductImage()
                            {
                                ProductId = product.Id,
                                Path = await SaveFile(item)
                            };
                            _context.ProductImages.Add(image);
                        }
                    };
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return 1;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return -1;
                }
            }
        }

        public async Task<int> Delete(long id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Product product = await _context.Products.FindAsync(id);
                    if (product == null) return -1;
                    if (product.Logo != null)
                    {
                        await _storageService.DeleteFileAsync(product.Logo);
                    }
                    List<ProductImage> images = await _context.ProductImages.Where(x => x.ProductId == id).ToListAsync();
                    if (images.Count() > 0)
                    {
                        foreach (var item in images)
                        {
                            _context.ProductImages.Remove(item);
                            await _storageService.DeleteFileAsync(item.Path);
                        }
                    }
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return 1;
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    return -1;
                }
            }
        }

        public async Task<ProductViewModel> Detail(long id)
        {
            try
            {
                return await _context.Products.Where(x=>x.Id==id).Select(p => new ProductViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Logo = p.Logo,
                    CategotyName = p.Category.Name,
                    BrandName=p.Brand.Name,
                    Description = p.Description,
                    Price = p.Price,
                    PriceDiscount=p.PriceDiscount,
                    Detail = p.Detail,
                    Url=p.Url,
                    IsNew = p.IsNew,
                    CategoryId=p.CategoryId,
                    BrandId=p.BrandId,
                    DisplayOrder=p.DisplayOrder,
                    Status=p.Status,
                    Year = p.Year,
                    Engine = p.Engine,
                    CreateDate =p.CreateDate,
                    Images= _context.ProductImages.Where(x => x.ProductId == id).ToList()
                }).FirstOrDefaultAsync();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<ProductUpdateRequest> Edit(long id)
        {
            try
            {
                Product product = await _context.Products.FindAsync(id);
                if (product == null) return null;
                ProductUpdateRequest updateProductsViewModel = new ProductUpdateRequest()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Logo = product.Logo,
                    CategoryId = product.CategoryId,
                    BrandId=product.BrandId,
                    Description = product.Description,
                    Price = product.Price,
                    Detail = product.Detail,
                    PriceDiscount = product.PriceDiscount,
                    IsNew = product.IsNew,
                    Url = product.Url,
                    Year = product.Year,
                    Engine = product.Engine,
                    DisplayOrder = product.DisplayOrder,
                    Status = product.Status,
                    Images = _context.ProductImages.Where(x => x.ProductId == id).ToList()
                };

                return updateProductsViewModel;
            }
            catch (Exception)
            {
                return null;
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
