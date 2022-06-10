using System;
using System.Collections.Generic;

#nullable disable

namespace XeMay.Model
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public long Id { get; set; }
        public string OrderName { get; set; }
        public string OrderAddress { get; set; }
        public string OrderEmail { get; set; }
        public int OrderPhone { get; set; }
        public string OrderNote { get; set; }
        public decimal? TotalMoney { get; set; }
        public int? PaymentStatus { get; set; }
        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
