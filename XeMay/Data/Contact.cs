using System;
using System.Collections.Generic;

#nullable disable

namespace XeMay.Data
{
    public partial class Contact
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Content { get; set; }
        public int? Status { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
