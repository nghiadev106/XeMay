using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XeMay.Models
{
    public class CategoryViewModel
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? ShowHome { get; set; }
        public int? Status { get; set; }
    }
}
