using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace XeMay.Models
{
    public class OrderViewModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập họ và tên")]
        [StringLength(250, ErrorMessage = "Họ và tên không quá 250 ký tự")]
        public string OrderName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập địa chỉ")]
        [StringLength(500, ErrorMessage = "Địa chỉ không quá 500 ký tự")]
        public string OrderAddress { get; set; }

        public string OrderEmail { get; set; }


        [Required(ErrorMessage = "Bạn phải nhập số điện thoại")]
        public string OrderPhone { get; set; }

        public string OrderNote { get; set; }
        public decimal? TotalMoney { get; set; }
        public int? PaymentStatus { get; set; }
        public DateTime? CreatedDate { get; set; }

        public IEnumerable<OrderDetailViewModel> OrderDetails { set; get; }
    }
}
