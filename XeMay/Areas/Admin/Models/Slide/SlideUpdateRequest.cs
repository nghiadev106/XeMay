using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace XeMay.Areas.Admin.Models.Slide
{
    public class SlideUpdateRequest
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập tên slide")]
        [StringLength(50, ErrorMessage = "Tên slide không quá 50 ký tự")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "tiêu đề tin tức không quá 250 ký tự")]
        public string Logo { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        [StringLength(250, ErrorMessage = "tiêu đề tin tức không quá 250 ký tự")]
        public string Link { get; set; }
        public int? Status { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? CreateDate { get; set; }
        public IFormFile FileUpload { get; set; }
    }
}
