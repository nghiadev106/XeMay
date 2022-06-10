using System;
using System.Collections.Generic;

#nullable disable

namespace XeMay.Model
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductImages = new HashSet<ProductImage>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? CategoryId { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceDiscount { get; set; }
        public bool? IsNew { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string Url { get; set; }
        public int? DisplayOrder { get; set; }
        public int? Status { get; set; }
        public int? Engine { get; set; }
        public int? Year { get; set; }
        public long? BrandId { get; set; }

        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
