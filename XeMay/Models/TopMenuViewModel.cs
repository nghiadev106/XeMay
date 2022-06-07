using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace XeMay.Models
{
    public class TopMenuViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Link { get; set; }
        public int? Status { get; set; }
        public int? DisplayOrder { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
