//using QuanLyChoThueXe06.Common.Req;
//using QuanLyChoThueXe06.Common.Rsp;
//using QuanLyChoThueXe06.DAL.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace QuanLyChoThueXe06.BLL
//{
//    public class StatisticsSvc
//    {
//        private QuanLyChoThueXe06Context context = new QuanLyChoThueXe06Context();


//        public SingleRsp CalculateRevenue(DateTime startDate, DateTime endDate)
//        {
//            var res = new SingleRsp();
//            var rentals = context.Rentals
//                .Where(r => r.RentalDate >= startDate && r.RentalDate <= endDate)
//                .ToList();

//            var totalRevenue = rentals.Sum(r =>
//            {
//                var rentalDays = (r.ReturnDate.HasValue ? (r.ReturnDate.Value - r.RentalDate).Days : 1);
//                return rentalDays * r.Car.PricePerDay;
//            });

//            res.Data = new { TotalRevenue = totalRevenue };
//            return res;
//        }

//        public SingleRsp CalculateDailyRevenue()
//        {
//            var today = DateTime.Today;
//            return CalculateRevenue(today, today);
//        }

//        //public SingleRsp CalculateMonthlyRevenue(int year, int month)
//        //{
//        //    var startDate = new DateTime(year, month, 1);
//        //    var endDate = startDate.AddMonths(1).AddDays(-1);
//        //    return CalculateRevenue(startDate, endDate);
//        //}

//        //public SingleRsp CalculateYearlyRevenue(int year)
//        //{
//        //    var startDate = new DateTime(year, 1, 1);
//        //    var endDate = new DateTime(year, 12, 31);
//        //    return CalculateRevenue(startDate, endDate);
//        //}

//        public SingleRsp CalculateRentedCarsCount(DateTime date)
//        {
//            var res = new SingleRsp();
//            var rentals = context.Rentals
//                .Where(r => r.RentalDate <= date && (r.ReturnDate == null || r.ReturnDate >= date))
//                .Count();

//            res.Data = new { RentedCarsCount = rentals };
//            return res;
//        }
//    }
//}