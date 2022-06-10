using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.Order;
using XeMay.Model;
using XeMay.Models;
using XeMay.Services;

namespace XeMay.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        const string SessionOrder = "order";

        public OrderController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            var lstOrder = await _orderService.GetAll();
            ViewBag.ListOrder = lstOrder;
            return View();
        }

        public async Task<IActionResult> Detail(long id)
        {
            var order =await  _orderService.GetDetail(id);
            ViewBag.order = order;
            var orderDetails = await _orderService.GetOrderDetail(id);
            ViewBag.orderDetails = orderDetails;
            return View();
        }

        public IActionResult RevenueStatistic(string fromDate,string toDate)
        {
            var revenuesDate =  _orderService.GetRevenueStatisticByDate( fromDate, toDate);
            ViewBag.revenuesDate = revenuesDate;
            var revenuesMonth = _orderService.GetRevenueStatisticByMonth(fromDate, toDate);
            ViewBag.revenuesMonth = revenuesMonth;
            var revenuesYear= _orderService.GetRevenueStatisticByYear(fromDate,toDate);
            ViewBag.revenuesYear = revenuesYear;
            return View();
        }

        public async Task<IActionResult> Delete(long id)
        {
            var model = await _orderService.GetDetail(id);
            if (model == null)
            {
                TempData["warning"] = "Hóa đơn không tồn tại";
                return RedirectToAction("Index");
            }
            var result = await _orderService.Delete(id);
            if (result == 1)
            {
                TempData["success"] = "Xóa hóa đơn thành công";
                return RedirectToAction("Index");
            }
            TempData["error"] = "Xóa hóa đơn thất bại";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ChangeStatus(StatusRequest request)
        {
            var result = await _orderService.ChangeStatus(request);

            if (result == 1)
            {
                TempData["success"] = "Cập nhật trạng thái đơn hàng thành công";
                return RedirectToAction("Detail", new { id = request.Id });
            }
            else
            {
                TempData["error"] = "Cập nhật trạng thái đơn hàng thất bại";
                return RedirectToAction("Detail", new { id = request.Id });
            }
        }

        public async Task<SelectList> loadProduct()
        {
            List<ProductViewModel> products = await _productService.GetAll();
            products.Insert(0, new ProductViewModel { Id = -1, Name = "-- Chọn sản phẩm --" });
            SelectList ListProducts = new SelectList(products, "Id", "Name");
            ViewBag.ListProducts = ListProducts;
            return ListProducts;
        }

        public async Task<IActionResult> Create()
        {
            List<CartItemViewModel> currentOrder = new List<CartItemViewModel>();
            HttpContext.Session.SetString(SessionOrder, JsonConvert.SerializeObject(currentOrder));
            await loadProduct();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel order)
        {
            await loadProduct();
            if (ModelState.IsValid)
            {
                var session = HttpContext.Session.GetString(SessionOrder);
                List<CartItemViewModel> cart = new List<CartItemViewModel>();
                if (session != null)
                {
                    cart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
                }
                if (cart.Count() <= 0)
                {
                    TempData["error"] = "Chưa có sản phẩm nào trong đơn hàng";
                    return View();
                }
                ViewBag.currentOrder = cart;
                var total = 0;
                List<OrderDetail> orderDetails = new List<OrderDetail>();
                foreach (var item in cart)
                {
                    total += item.Quantity * Convert.ToInt32(item.Price);
                    var detail = new OrderDetail();
                    detail.ProductId = item.ProductId;
                    detail.Price = item.Price;
                    detail.Quantity = item.Quantity;
                    detail.CreatedDate = DateTime.Now;
                    orderDetails.Add(detail);
                }
                var orderNew = new Order();
                orderNew.OrderName = order.OrderName;
                orderNew.OrderEmail = order.OrderEmail;
                orderNew.OrderPhone = Convert.ToInt32(order.OrderPhone);
                orderNew.OrderAddress = order.OrderAddress;
                orderNew.OrderNote = order.OrderNote;
                orderNew.CreatedDate = DateTime.Now;
                orderNew.PaymentStatus = order.PaymentStatus;
                orderNew.TotalMoney = Convert.ToDecimal(total);

                var result = await _orderService.Create(orderNew, orderDetails);
                if (result)
                {
                    List<CartItemViewModel> currentOrder = new List<CartItemViewModel>();
                    HttpContext.Session.SetString(SessionOrder, JsonConvert.SerializeObject(currentOrder));
                    TempData["success"] = "Thêm mới hóa đơn thành công";
                    return RedirectToAction("Index");
                }
            }
            return View(order);
        }

        [HttpGet]
        public IActionResult GetListItems()
        {
            var session = HttpContext.Session.GetString(SessionOrder);
            List<CartItemViewModel> currentOrder = new List<CartItemViewModel>();
            if (session != null)
                currentOrder = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            return Ok(currentOrder);
        }

        public async Task<IActionResult> AddToCart(long id, int quantity)
        {
            var session = HttpContext.Session.GetString(SessionOrder);
            List<CartItemViewModel> currentOrder = new List<CartItemViewModel>();
            if (session != null)
                currentOrder = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            if (currentOrder.Any(x => x.ProductId == id))
            {
                foreach (var item in currentOrder)
                {
                    if (item.ProductId == id)
                    {
                        item.Quantity += quantity;
                    }
                }
            }
            else
            {
                CartItemViewModel newItem = new CartItemViewModel();
                newItem.ProductId = id;
                var product = await _productService.Detail(id);
                newItem.Logo = product.Logo;
                newItem.Url = product.Url;
                newItem.Name = product.Name;
                if (product.PriceDiscount != null)
                {
                    newItem.Price = product.PriceDiscount;
                }
                else
                {
                    newItem.Price = product.Price;
                }
                newItem.Quantity = quantity;
                currentOrder.Add(newItem);
            }

            HttpContext.Session.SetString(SessionOrder, JsonConvert.SerializeObject(currentOrder));
            return Ok(currentOrder);
        }

        public IActionResult UpdateCart(int id, int quantity)
        {
            var session = HttpContext.Session.GetString(SessionOrder);
            List<CartItemViewModel> currentOrder = new List<CartItemViewModel>();
            if (session != null)
                currentOrder = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            foreach (var item in currentOrder)
            {
                if (item.ProductId == id)
                {
                    if (quantity == 0)
                    {
                        currentOrder.Remove(item);
                        break;
                    }
                    item.Quantity = quantity;
                }
            }

            HttpContext.Session.SetString(SessionOrder, JsonConvert.SerializeObject(currentOrder));
            return Ok(currentOrder);
        }
    }
}
