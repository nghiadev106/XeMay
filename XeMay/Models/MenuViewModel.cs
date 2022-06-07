using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XeMay.Data;

namespace XeMay.Models
{
    public class MenuViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> ListProductHot { get; set; }
        public List<Product> ListProductNew { get; set; }
    }
}
