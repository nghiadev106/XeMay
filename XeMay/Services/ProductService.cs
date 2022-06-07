using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.Product;
using XeMay.Data;
using XeMay.Models;

namespace XeMay.Services
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetDiscountProduct();
        Task<PaginationViewModel> Pagination(Dictionary<string, object> data);

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
                Description = p.Description,
                Price = p.Price,
                Detail = p.Detail,
                PriceDiscount = p.PriceDiscount,
                IsNew = p.IsNew,
                Url = p.Url,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
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
                Description = p.Description,
                Price = p.Price,
                Detail = p.Detail,
                PriceDiscount = p.PriceDiscount,
                IsNew = p.IsNew,
                Url = p.Url,
                DisplayOrder = p.DisplayOrder,
                Status = p.Status,
                CreateDate = p.CreateDate
            }).ToListAsync();
        }

        public async Task<PaginationViewModel> Pagination(Dictionary<string, object> data)
        {
            PaginationViewModel paginationViewModel = new PaginationViewModel();
            try
            {
                int page = int.Parse(data["page"].ToString());
                int pageSize = int.Parse(data["pageSize"].ToString());
                string nameSearch = "";
                if (data.ContainsKey("nameSearch") && !string.IsNullOrEmpty(data["nameSearch"].ToString().Trim()))
                    nameSearch = data["nameSearch"].ToString().Trim().ToLower();
                paginationViewModel.Page = page;
                paginationViewModel.PageSize = pageSize;
                paginationViewModel.TotalItems = await _context.Products.Where(x => x.Name.ToLower().IndexOf(nameSearch) >= 0).CountAsync();
                var model = from pro in _context.Products
                            select new ProductViewModel
                            {
                                Id = pro.Id,
                                Name = pro.Name,
                                Logo = pro.Logo,
                                CategotyName = pro.Category.Name,
                                Description = pro.Description,
                                Price = pro.Price,
                                Detail = pro.Detail,
                                PriceDiscount = pro.PriceDiscount,
                                IsNew = pro.IsNew,
                                Url = pro.Url,
                                DisplayOrder = pro.DisplayOrder,
                                Status = pro.Status,
                                CreateDate = pro.CreateDate
                            };
                string sortByName = "";
                if (data.ContainsKey("sortByName") && !string.IsNullOrEmpty(data["sortByName"].ToString().Trim()))
                    sortByName = data["sortByName"].ToString().Trim().ToLower();
                switch (sortByName)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Name);
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.Name);
                        break;
                }
                string sortByCreatedDate = "";
                if (data.ContainsKey("sortByCreatedDate") && !string.IsNullOrEmpty(data["sortByCreatedDate"].ToString().Trim()))
                    sortByCreatedDate = data["sortByCreatedDate"].ToString().Trim().ToLower();
                switch (sortByCreatedDate)
                {
                    case "asc":
                        model = model.OrderBy(x => x.CreateDate);
                        break;

                    case "desc":
                        model = model.OrderByDescending(x => x.CreateDate);
                        break;
                }
                string sortByPrice = "";
                if (data.ContainsKey("sortByPrice") && !string.IsNullOrEmpty(data["sortByPrice"].ToString().Trim()))
                    sortByPrice = data["sortByPrice"].ToString().Trim().ToLower();
                switch (sortByPrice)
                {
                    case "asc":
                        model = model.OrderBy(x => x.Price);
                        break;
                    case "desc":
                        model = model.OrderByDescending(x => x.Price);
                        break;
                }
                paginationViewModel.Data = model.Where(x => x.Name.ToLower().IndexOf(nameSearch) >= 0).Skip((page - 1) * pageSize).Take(pageSize);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return paginationViewModel;
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
                    Description = p.Description,
                    Price = p.Price,
                    PriceDiscount=p.PriceDiscount,
                    Detail = p.Detail,
                    Url=p.Url,
                    IsNew = p.IsNew,
                    CategoryId=p.CategoryId,
                    DisplayOrder=p.DisplayOrder,
                    Status=p.Status,
                    CreateDate=p.CreateDate,
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
                    Description = product.Description,
                    Price = product.Price,
                    Detail = product.Detail,
                    PriceDiscount = product.PriceDiscount,
                    IsNew = product.IsNew,
                    Url = product.Url,
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
