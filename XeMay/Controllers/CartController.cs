using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XeMay.Data;
using XeMay.Models;
using XeMay.Services;

namespace XeMay.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;

        public CartController(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        const string SessionCart = "Cart";
        public IActionResult Index()
        {
            ViewBag.sessionCart = HttpContext.Session.GetString(SessionCart);
            return View();
        }

        public IActionResult Checkout()
        {
            var session = HttpContext.Session.GetString(SessionCart);
            var totalPrice = 0;
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            foreach (var item in currentCart)
            {
                totalPrice += item.Quantity * Convert.ToInt32(item.Price);
            }
            ViewBag.currentCart = currentCart;
            ViewBag.totalPrice = totalPrice;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> OrderNow(OrderNowViewModel order)
        {
            if (ModelState.IsValid)
            {            
                var result =await _orderService.OrderNow(order);
                if (result)
                {
                    return Redirect("/cart/CheckoutSuccess");
                }
                return BadRequest("Đặt hàng không thành công");
            }
            return BadRequest("Đặt hàng không thành công");
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(OrderViewModel order)
        {
            if (ModelState.IsValid)
            {
                var session = HttpContext.Session.GetString(SessionCart);
                List<CartItemViewModel> cart = new List<CartItemViewModel>();
                if (session != null)
                {
                    cart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
                }
                ViewBag.currentCart = cart;
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
                orderNew.PaymentStatus = 0;
                orderNew.TotalMoney = Convert.ToDecimal(total);

                var result=await _orderService.Create(orderNew, orderDetails);
                if (result)
                {
                    List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
                    HttpContext.Session.SetString(SessionCart, JsonConvert.SerializeObject(currentCart));
                }
                return Redirect("/cart/CheckoutSuccess");
            }
            return View(order);
        }

        public IActionResult CheckoutSuccess()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetListItems()
        {
            var session = HttpContext.Session.GetString(SessionCart);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);
            return Ok(currentCart);
        }

        public async Task<IActionResult> AddToCart(long id,int quantity)
        {
            var session = HttpContext.Session.GetString(SessionCart);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            if (currentCart.Any(x => x.ProductId == id))
            {
                foreach (var item in currentCart)
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
                currentCart.Add(newItem);
            }

            HttpContext.Session.SetString(SessionCart, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }

        public IActionResult UpdateCart(int id, int quantity)
        {
            var session = HttpContext.Session.GetString(SessionCart);
            List<CartItemViewModel> currentCart = new List<CartItemViewModel>();
            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(session);

            foreach (var item in currentCart)
            {
                if (item.ProductId == id)
                {
                    if (quantity == 0)
                    {
                        currentCart.Remove(item);
                        break;
                    }
                    item.Quantity = quantity;
                }
            }

            HttpContext.Session.SetString(SessionCart, JsonConvert.SerializeObject(currentCart));
            return Ok(currentCart);
        }   
    }
}
