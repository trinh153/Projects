using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe06.Common.Req
{
    public class ThongKeReq
    {
        public DateTime Date { get; set; }
        public decimal TotalRevenue { get; set; }
    }
    public class RentalStatisticsDto
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int RentalCount { get; set; }
    }
}
