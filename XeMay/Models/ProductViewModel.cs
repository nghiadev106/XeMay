using System;
using System.Collections.Generic;
using XeMay.Model;

namespace XeMay.Models
{
    public class ProductViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? CategoryId { get; set; }
        public long? BrandId { get; set; }
        public string CategotyName { get; set; }
        public string BrandName { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceDiscount { get; set; }
        public bool? IsNew { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public int? Engine { get; set; }
        public int? Year { get; set; }
        public string Url { get; set; }
        public int? DisplayOrder { get; set; }
        public int? Status { get; set; }
        public List<ProductImage> Images { get; set; }
    }
}
