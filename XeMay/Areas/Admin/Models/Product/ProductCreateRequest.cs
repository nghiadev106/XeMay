using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace XeMay.Areas.Admin.Models.Product
{
    public class ProductCreateRequest
    {
        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        [StringLength(500, ErrorMessage = "Tiêu đề tin tức không quá 500 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn danh mục")]
        public long? CategoryId { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn thương hiệu")]
        public long? BrandId { get; set; }
        public string Logo { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập mô tả sản phẩm")]
        [StringLength(500, ErrorMessage = "Mô tả sản phẩm không quá 500 ký tự")]
        public string Description { get; set; }

        public string Detail { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập giá sản phẩm")]
        public decimal? Price { get; set; }
        public decimal? PriceDiscount { get; set; }
        public bool? IsNew { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EditDate { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập URL")]
        public string Url { get; set; }
        public int? Engine { get; set; }
        public int? Year { get; set; }
        public int? DisplayOrder { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn trạng thái")]
        public int? Status { get; set; }

        public bool IsNewInput
        {
            get => this.IsNew.GetValueOrDefault();
            set { this.IsNew = value; }
        }

        [Required(ErrorMessage = "Chọn một file")]
        [Display(Name = "Chọn file upload")]
        public IFormFile FileUpload { get; set; }

        public List<IFormFile> Files { get; set; }
    }
}
