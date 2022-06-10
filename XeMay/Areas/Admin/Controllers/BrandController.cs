using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.Brand;
using XeMay.Services;

namespace XeMay.Areas.Admin.Controllers
{
    public class BrandController : BaseController
    {
        private readonly IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public async Task<IActionResult> Index()
        {
            var brands = await _brandService.GetAll();
            ViewBag.brands = brands;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BrandRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";
                return View(request);
            }

            var result = await _brandService.Create(request);

            if (result != -1)
            {
                TempData["success"] = "Thêm mới thương hiệu sản phẩm thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm thương hiệu sản phẩm thất bại");
            TempData["error"] = "Thêm mới thương hiệu sản phẩm thất bại";
            return View(request);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var brand = await _brandService.Edit(id);
            if (brand == null)
            {
                TempData["warning"] = "thương hiệu không tồn tại";
                return RedirectToAction("Index");
            }

            return View(brand);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BrandRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";
                return View(request);
            }

            var result = await _brandService.Update(request);

            if (result == 1)
            {
                TempData["success"] = "Cập nhật thương hiệu sản phẩm thành công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật thương hiệu sản phẩm thất bại");
                TempData["error"] = "Cập nhật thương hiệu sản phẩm thất bại";
                return View(request);
            }
        }

        public async Task<IActionResult> Delete(long id)
        {
            var model = await _brandService.Detail(id);
            if (model == null)
            {
                TempData["warning"] = "thương hiệu không tồn tại";
                return RedirectToAction("Index");
            }
            
            var result=await _brandService.Delete(id);
            if (result != 1)
            {
                TempData["warning"] = "thương hiệu chứa sản phẩm ko thể xóa";
                ModelState.AddModelError("", "thương hiệu chứa sản phẩm ko thể xóa");
                return RedirectToAction("Index");
            }
            TempData["success"] = "Xóa thương hiệu thành công";
            return RedirectToAction("Index");
        }
    }
}
