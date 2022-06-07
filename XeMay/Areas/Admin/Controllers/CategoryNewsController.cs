using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.CategoryNews;
using XeMay.Services;

namespace XeMay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryNewsController : BaseController
    {
        private readonly ICategoryNewsService _categoryService;

        public CategoryNewsController(ICategoryNewsService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var lstCategories = await _categoryService.GetAll();
            ViewBag.lstCategories = lstCategories;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryNewsRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";
                return View(request);
            }

            var result = await _categoryService.Create(request);

            if (result != -1)
            {
                TempData["success"] = "Thêm mới danh mục bài viết thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm danh mục bài viết thất bại");
            TempData["error"] = "Thêm mới danh mục bài viết thất bại";
            return View(request);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var category = await _categoryService.Edit(id);
            if (category == null)
            {
                TempData["warning"] = "Danh mục không tồn tại";
                return RedirectToAction("Index");
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryNewsRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";
                return View(request);
            }

            var result = await _categoryService.Update(request);

            if (result == 1)
            {
                TempData["success"] = "Cập nhật danh mục bài viết thành công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật danh mục bài viết thất bại");
                TempData["error"] = "Cập nhật danh mục bài viết thất bại";
                return View(request);
            }
        }

        public async Task<IActionResult> Delete(long id)
        {
            var model = await _categoryService.Detail(id);
            if (model == null)
            {
                TempData["warning"] = "Danh mục không tồn tại";
                return RedirectToAction("Index");
            }

            var result = await _categoryService.Delete(id);
            if (result != 1)
            {
                TempData["warning"] = "Danh mục chứa bài viết ko thể xóa";
                ModelState.AddModelError("", "Danh mục chứa bài viết ko thể xóa");
                return RedirectToAction("Index");
            }
            TempData["success"] = "Xóa danh mục thành công";
            return RedirectToAction("Index");
        }
    }
}
