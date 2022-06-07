using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.Slide;
using XeMay.Services;

namespace XeMay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlideController : BaseController
    {
        private readonly ISlideService _slideService;

        public SlideController(ISlideService slideService)
        {
            _slideService = slideService;
        }
        public async Task<IActionResult> Index()
        {
            var lstSlide = await _slideService.GetAll();
            ViewBag.lstSlide = lstSlide;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create(SlideCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";
                return View(request);
            }

            var result = await _slideService.Create(request);

            if (result != -1)
            {
                TempData["success"] = "Thêm mới slide thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm slide thất bại");
            TempData["error"] = "Thêm mới slide thất bại";
            return View(request);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var slide = await _slideService.Edit(id);
            if (slide == null)
            {
                TempData["warning"] = "slide không tồn tại";
                return RedirectToAction("Index");
            }

            return View(slide);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(SlideUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";
                return View(request);
            }

            var result = await _slideService.Update(request);

            if (result == 1)
            {
                TempData["success"] = "Cập nhật slide thành công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật slide thất bại");
                TempData["error"] = "Cập nhật slide thất bại";
                return View(request);
            }
        }

        public async Task<IActionResult> Delete(long id)
        {
            var model = await _slideService.Detail(id);
            if (model == null)
            {
                TempData["warning"] = "Slide không tồn tại";
                return RedirectToAction("Index");
            }
            var result = await _slideService.Delete(id);
            if (result == 1)
            {
                TempData["success"] = "Xóa Slide thành công";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Xóa Slide thất bại";
            return RedirectToAction("Index");
        }
    }
}
