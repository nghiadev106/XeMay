using System;

namespace XeMay.Models
{
    public class RevenueStatisticViewModel
    {
        public DateTime Date { set; get; }
        public decimal? Revenues { set; get; }
    }
    public class RevenueStatisticMonthViewModel
    {
        public string Month { set; get; }
        public decimal? Revenues { set; get; }
    }

    public class RevenueStatisticYearViewModel
    {
        public string Year { set; get; }
        public decimal? Revenues { set; get; }
    }
}
