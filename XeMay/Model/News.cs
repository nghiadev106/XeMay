using System;
using System.Collections.Generic;

#nullable disable

namespace XeMay.Model
{
    public partial class News
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? CategoryId { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public bool? IsNew { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string Url { get; set; }
        public int? DisplayOrder { get; set; }
        public int? Status { get; set; }

        public virtual CategoriesNew Category { get; set; }
    }
}
