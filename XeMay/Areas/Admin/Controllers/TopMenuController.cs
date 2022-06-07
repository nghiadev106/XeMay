using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.TopMenu;
using XeMay.Services;

namespace XeMay.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class TopMenuController : BaseController
    {
        private readonly ITopMenuService _topMenuService;

        public TopMenuController(ITopMenuService topMenuService)
        {
            _topMenuService = topMenuService;
        }
        public async Task<IActionResult> Index()
        {
            var lstTopMenu = await _topMenuService.GetAll();
            ViewBag.lstTopMenu = lstTopMenu;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create(TopMenuCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";
                return View(request);
            }

            var result = await _topMenuService.Create(request);

            if (result != -1)
            {
                TempData["success"] = "Thêm mới Menu thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm Menu thất bại");
            TempData["error"] = "Thêm mới Menu thất bại";
            return View(request);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var topMenu = await _topMenuService.Edit(id);
            if (topMenu == null)
            {
                TempData["warning"] = "Menu không tồn tại";
                return RedirectToAction("Index");
            }

            return View(topMenu);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(TopMenuUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";
                return View(request);
            }

            var result = await _topMenuService.Update(request);

            if (result == 1)
            {
                TempData["success"] = "Cập nhật Menu thành công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật Menu thất bại");
                TempData["error"] = "Cập nhật Menu thất bại";
                return View(request);
            }
        }

        public async Task<IActionResult> Delete(long id)
        {
            var model = await _topMenuService.Detail(id);
            if (model == null)
            {
                TempData["warning"] = "Menu không tồn tại";
                return RedirectToAction("Index");
            }
            var result = await _topMenuService.Delete(id);
            if (result == 1)
            {
                TempData["success"] = "Xóa Menu thành công";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Xóa Menu thất bại";
            return RedirectToAction("Index");
        }
    }
}
