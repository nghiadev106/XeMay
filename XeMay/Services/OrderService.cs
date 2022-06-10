using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using XeMay.Areas.Admin.Models.Order;
using XeMay.Model;
using XeMay.Models;

namespace XeMay.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll();
        Task<Order> GetDetail(long orderId);
        Task<List<OrderDetailViewModel>> GetOrderDetail(long orderId);
        Task<bool> Create(Order order, List<OrderDetail> orderDetails);
        Task<bool> OrderNow(OrderNowViewModel order);
        Task<int> Delete(long id);
        Task<int> ChangeStatus(StatusRequest request);
        IEnumerable<RevenueStatisticViewModel> GetRevenueStatisticByDate(string fromDate, string toDate);
        IEnumerable<RevenueStatisticMonthViewModel> GetRevenueStatisticByMonth(string fromDate, string toDate);
        IEnumerable<RevenueStatisticYearViewModel> GetRevenueStatisticByYear(string fromDate, string toDate);
    }
    public class OrderService: IOrderService
    {
        private readonly XeMayContext _context;

        public OrderService(XeMayContext context)
        {
            _context = context;
        }
        public async Task<bool> Create(Order order, List<OrderDetail> orderDetails)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var result = _context.Orders.Add(order);
                    await _context.SaveChangesAsync();
                    foreach (var orderDetail in orderDetails)
                    {
                        orderDetail.OrderId = order.Id;
                        _context.OrderDetails.Add(orderDetail);
                    }
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<bool> OrderNow(OrderNowViewModel order)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == order.ProductId);
                    var detail = new OrderDetail();
                    var orderNew = new Order();

                    var total = 0;
                    if (product.PriceDiscount > 0)
                    {
                        total = order.Quantity * Convert.ToInt32(product.PriceDiscount);
                        detail.Price = product.PriceDiscount;
                    }
                    else
                    {
                        total = order.Quantity * Convert.ToInt32(product.Price);
                        detail.Price = product.Price;
                    }
                    orderNew.OrderName = order.OrderName;
                    orderNew.OrderEmail = order.OrderEmail;
                    orderNew.OrderPhone = Convert.ToInt32(order.OrderPhone);
                    orderNew.OrderAddress = order.OrderAddress;
                    orderNew.OrderNote = order.OrderNote;
                    orderNew.CreatedDate = DateTime.Now;
                    orderNew.PaymentStatus = 0;
                    orderNew.TotalMoney = Convert.ToDecimal(total);
                    var result = _context.Orders.Add(orderNew);
                    await _context.SaveChangesAsync();

                    detail.OrderId = orderNew.Id;
                    detail.ProductId = order.ProductId;
                    detail.Quantity = order.Quantity;
                    detail.CreatedDate = DateTime.Now;
                    _context.OrderDetails.Add(detail);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
        }

        public async Task<Order> GetDetail(long orderId)
        {
            var query =await _context.Orders.Where(x => x.Id == orderId).SingleOrDefaultAsync();
            return query;
        }

        public async Task<List<OrderDetailViewModel>> GetOrderDetail(long orderId)
        {
            var model = from od in _context.OrderDetails
                        join p in _context.Products on od.ProductId equals p.Id
                        where od.OrderId==orderId
                        select new OrderDetailViewModel
                        {
                            ProductName = p.Name,
                            Logo = p.Logo,
                            Price = p.Price,
                            PriceDiscount = od.Price,
                            Quantity = od.Quantity
                        };
            return await model.ToListAsync();
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<int> ChangeStatus(StatusRequest request)
        {
            try
            {
                Order order = await _context.Orders.FindAsync(request.Id);
                if (order == null) return -1;
                order.PaymentStatus = request.PaymentStatus;
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public async Task<int> Delete(long id)
        {
            try
            {
                var orderDetails = await _context.OrderDetails.Where(x => x.OrderId == id).ToListAsync();
                if (orderDetails.Count() > 0)
                {
                    foreach(var item in orderDetails)
                    {
                        var detail = await _context.OrderDetails.Where(x => x.Id == item.Id).SingleOrDefaultAsync();
                        _context.OrderDetails.Remove(detail);
                    }
                    await _context.SaveChangesAsync();
                }
                var order = await _context.Orders.FindAsync(id);
                if (order == null) return -1;
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public IEnumerable<RevenueStatisticViewModel> GetRevenueStatisticByDate(string fromDate, string toDate)
        {
            var query = from o in _context.Orders
                        join od in _context.OrderDetails
                        on o.Id equals od.OrderId
                        join p in _context.Products
                        on od.ProductId equals p.Id
                        select new
                        {
                            CreatedDate = o.CreatedDate,
                            Quantity = od.Quantity,
                            Price = od.Price
                        };
            if (!string.IsNullOrEmpty(fromDate))
            {
                DateTime start = DateTime.Parse(fromDate, null);
                query = query.Where(x => x.CreatedDate >= start);
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.Parse(toDate, null);
                query = query.Where(x => x.CreatedDate <= endDate);
            }

            var result = query.GroupBy(x => (x.CreatedDate ?? DateTime.Now).Date)
                .Select(r => new
                {
                    Date = r.Key.Date,
                    TotalSell = r.Sum(x => x.Price * x.Quantity),
                }).Select(x => new RevenueStatisticViewModel()
                {
                    Date = x.Date,
                    Revenues = x.TotalSell
                });
            return result.ToList();
        }

        public IEnumerable<RevenueStatisticMonthViewModel> GetRevenueStatisticByMonth(string fromDate, string toDate)
        {
            var query = from o in _context.Orders
                        join od in _context.OrderDetails
                        on o.Id equals od.OrderId
                        join p in _context.Products
                        on od.ProductId equals p.Id
                        select new
                        {
                            CreatedDate = o.CreatedDate,
                            Quantity = od.Quantity,
                            Price = od.Price,
                        };
            if (!string.IsNullOrEmpty(fromDate))
            {
                DateTime start = DateTime.Parse(fromDate, null);

                query = query.Where(x => x.CreatedDate >= start);
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.Parse(toDate,null);

                query = query.Where(x => x.CreatedDate <= endDate);
            }

            var result = query.OrderByDescending(x=>x.CreatedDate).GroupBy(x => new { x.CreatedDate.Value.Month, x.CreatedDate.Value.Year })
                .Select(r => new
                {
                    Month = r.Key.Month.ToString() + "/" + r.Key.Year.ToString(),
                    TotalSell = r.Sum(x => x.Price * x.Quantity),
                }).Select(x => new RevenueStatisticMonthViewModel()
                {
                    Month = x.Month,
                    Revenues = x.TotalSell
                });
            return result.ToList();
        }

        public IEnumerable<RevenueStatisticYearViewModel> GetRevenueStatisticByYear(string fromDate,string toDate)
        {
            var query = from o in _context.Orders
                        join od in _context.OrderDetails
                        on o.Id equals od.OrderId
                        join p in _context.Products
                        on od.Id equals p.Id
                        select new
                        {
                            CreatedDate = o.CreatedDate,
                            Quantity = od.Quantity,
                            Price = od.Price,
                        };
            if (!string.IsNullOrEmpty(fromDate))
            {
                DateTime start = DateTime.Parse(fromDate, null);
                query = query.Where(x => x.CreatedDate >= start);
            }
            if (!string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.Parse(toDate, null);
                query = query.Where(x => x.CreatedDate <= endDate);
            }

            var result = query.OrderByDescending(x=>x.CreatedDate).GroupBy
                (x => new { x.CreatedDate.Value.Year })
              .Select(r => new
              {
                  Year = r.Key.Year.ToString(),
                  TotalSell = r.Sum(x => x.Price * x.Quantity),
              }).Select(x => new RevenueStatisticYearViewModel()
              {
                  Year = x.Year,
                  Revenues = x.TotalSell
              }).ToList();
            return result;
        }
    }
}
