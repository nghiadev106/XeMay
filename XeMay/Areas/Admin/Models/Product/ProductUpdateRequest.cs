using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using XeMay.Data;

namespace XeMay.Areas.Admin.Models.Product
{
    public class ProductUpdateRequest
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        [StringLength(500, ErrorMessage = "Tên sản phẩm không quá 500 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn danh mục")]
        public long? CategoryId { get; set; }
        public string Logo { get; set; }

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
        public int? DisplayOrder { get; set; }

        [Required(ErrorMessage = "Bạn phải chọn trạng thái")]
        public int? Status { get; set; }
        public bool IsNewInput
        {
            get => this.IsNew.GetValueOrDefault();
            set { this.IsNew = value; }
        }
        public IFormFile FileUpload { get; set; }
        public List<IFormFile> Files { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
