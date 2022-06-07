using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.Product;
using XeMay.Models;
using XeMay.Services;

namespace XeMay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private IHostingEnvironment _env;

        public ProductController(IProductService productService, ICategoryService categoryService, IHostingEnvironment env)
        {
            _productService = productService;
            _categoryService = categoryService;
            _env=env;
        }
        public async Task<IActionResult> Index()
        {
            var lstProduct = await _productService.GetAll();
            ViewBag.lstProduct = lstProduct;
            return View();
        }


        public async Task<SelectList> loadCategory()
        {
            List<CategoryViewModel> categories = await _categoryService.GetAll();
            categories.Insert(0, new CategoryViewModel { Id=-1 , Name="-- Chọn danh mục --"});
            SelectList categoryList = new SelectList(categories, "Id", "Name");
            ViewBag.categoryList = categoryList;
            return categoryList;
        }


        public async Task<IActionResult> Create()
        {
            await loadCategory();
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create(ProductCreateRequest request)
        {
            await loadCategory();
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";               
                return View(request);
            }


            if (request.CategoryId == -1)
            {
                ModelState.AddModelError("", "Bạn chưa chọn danh mục");
                TempData["warning"] = "Bạn chưa chọn danh mục";
                return View(request);
            }

            var result = await _productService.Create(request);

            if (result !=-1)
            {
                TempData["success"] = "Thêm mới sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm sản phẩm thất bại");
            TempData["error"] = "Thêm mới sản phẩm thất bại";
            return View(request);         
        }

        public async Task<IActionResult> Edit(long id)
        {
            var product = await _productService.Edit(id);
            if (product == null)
            {
                TempData["warning"] = "Sản phẩm không tồn tại";
                return RedirectToAction("Index");
            }

            await loadCategory();            
            return View(product);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(ProductUpdateRequest request)
        {
            await loadCategory();
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";
              
                return View(request);
            }

            if (request.CategoryId == -1)
            {
                ModelState.AddModelError("", "Bạn chưa chọn danh mục");
                TempData["warning"] = "Bạn chưa chọn danh mục";
                return View(request);
            }

            var result = await _productService.Update(request);

            if (result == 1)
            {
                TempData["success"] = "Cập nhật sản phẩm thành công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật sản phẩm thất bại");
                TempData["error"] = "Cập nhật sản phẩm thất bại";
                return View(request);
            }
        }

        public async Task<IActionResult> Delete(long id)
        {
            var model = await _productService.Detail(id);
            if (model == null)
            {
                TempData["warning"] = "Sản phẩm không tồn tại";
                return RedirectToAction("Index");
            }
            var result=await _productService.Delete(id);
            if (result == 1)
            {
                TempData["success"] = "Xóa sản phẩm thành công";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Sản phẩm có hóa đơn không thể xóa";
            return RedirectToAction("Index");
        }
    }
}
