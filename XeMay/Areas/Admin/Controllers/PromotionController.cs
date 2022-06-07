using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.Promotion;
using XeMay.Services;

namespace XeMay.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PromotionController : BaseController
    {
        private readonly IPromotionService _promotionService;

        public PromotionController(IPromotionService promotionService)
        {
            _promotionService = promotionService;
        }
        public async Task<IActionResult> Index()
        {
            var lstPromotion = await _promotionService.GetAll();
            ViewBag.lstPromotion = lstPromotion;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create(PromotionCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";
                return View(request);
            }

            var result = await _promotionService.Create(request);

            if (result != -1)
            {
                TempData["success"] = "Thêm mới khuyến mãi thành công";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Thêm khuyến mãi thất bại");
            TempData["error"] = "Thêm mới promotion thất bại";
            return View(request);
        }

        public async Task<IActionResult> Edit(long id)
        {
            var promotion = await _promotionService.Edit(id);
            if (promotion == null)
            {
                TempData["warning"] = "khuyến mãi không tồn tại";
                return RedirectToAction("Index");
            }

            return View(promotion);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Edit(PromotionUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                TempData["warning"] = "Bạn nhập thiếu dữ liệu";
                return View(request);
            }

            var result = await _promotionService.Update(request);

            if (result == 1)
            {
                TempData["success"] = "Cập nhật khuyến mãi thành công";
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Cập nhật khuyến mãi thất bại");
                TempData["error"] = "Cập nhật khuyến mãi thất bại";
                return View(request);
            }
        }

        public async Task<IActionResult> Delete(long id)
        {
            var model = await _promotionService.Detail(id);
            if (model == null)
            {
                TempData["warning"] = "khuyến mãi không tồn tại";
                return RedirectToAction("Index");
            }
            var result = await _promotionService.Delete(id);
            if (result == 1)
            {
                TempData["success"] = "Xóa khuyến mãi thành công";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Xóa khuyến mãi thất bại";
            return RedirectToAction("Index");
        }
    }
}
