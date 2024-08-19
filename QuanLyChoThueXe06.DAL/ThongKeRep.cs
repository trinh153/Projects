using Microsoft.EntityFrameworkCore;
using QuanLyChoThueXe06.Common.DAL;
using QuanLyChoThueXe06.Common.Req;
using QuanLyChoThueXe06.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace WebDT.DAL
{
    public class ThongKeRep : GenericRep<QuanLyChoThueXe06Context, Rental>
    {
        private QuanLyChoThueXe06Context context;

        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int? TotalSale { get; set; }

        public class ProductStatistics
        {
            public int ProductId { get; set; }
            public int TotalOrders { get; set; }
            public int TotalQuantity { get; set; }
            public decimal TotalRevenue { get; set; }
        }


        public ThongKeRep()
        {
            context = new QuanLyChoThueXe06Context();
        }


        //public SingleRsp GetSaleInDateRange(DateTime fromDate, DateTime toDate)
        //{
        //    var result = context.OrderDetails
        //        .Join(context.Orders,
        //            od => od.OrderId,
        //            o => o.OrderId,
        //            (od, o) => new
        //            {
        //                OrderDate = o.OrderDate,
        //                TotalPrice = od.Quantity * od.UnitPrice
        //            })
        //        .Where(x => x.OrderDate >= fromDate && x.OrderDate <= toDate)
        //        .GroupBy(x => x.OrderDate)
        //        .Select(g => new ThongKe
        //        {
        //            OrderDate = g.Key,
        //            Total = g.Sum(x => x.TotalPrice)
        //        })
        //        .ToList();

        //}
        public decimal? ThongKeDoanhThuTheoNgay(DateTime fromDate, DateTime toDate)
        {
            var totalRevenue = context.Rentals
               .Where(r => r.ReturnDate >= fromDate && r.ReturnDate <= toDate)
               .Join(context.Revenues,
                     rental => rental.RentalId,
                     revenue => revenue.RentalId,
                     (rental, revenue) => revenue.Amount)
               .Sum();

            return totalRevenue;

        }
        public decimal? ThongKeXeThueTheoThang(DateTime month)
        {
            var year = month.Year;
            var monthValue = month.Month;

            var result = context.Rentals
                .Where(r => r.ReturnDate != null && r.ReturnDate.Value.Year == year && r.ReturnDate.Value.Month == monthValue)
                .GroupBy(r => new { r.ReturnDate.Value.Year, r.ReturnDate.Value.Month })
                .Select(g => new RentalStatisticsDto
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    RentalCount = g.Count()
                })
                .FirstOrDefault(); // We're only interested in one month

            return result?.RentalCount;
        }

    }
}