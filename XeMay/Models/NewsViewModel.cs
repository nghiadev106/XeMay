using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XeMay.Models
{
    public class NewsViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public long? CategoryId { get; set; }
        public string CategotyName { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }
        public bool? IsNew { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public string Url { get; set; }
        public int? DisplayOrder { get; set; }
        public int? Status { get; set; }
    }
}
