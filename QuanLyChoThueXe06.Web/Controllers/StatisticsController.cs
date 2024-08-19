using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyChoThueXe06.BLL;
using QuanLyChoThueXe06.Common.Req;
using QuanLyChoThueXe06.DAL.Models;
using WebDT.BLL;

namespace QuanLyChoThueXe06.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private ThongKeSvc statisticsSvc = new ThongKeSvc();


        [HttpGet("daily-revenue")]
        public IActionResult GetDailyRevenue(DateTime fromDate, DateTime toDate)
        {
            var res = statisticsSvc.ThongKeDoanhThuTheoNgay(fromDate, toDate);
            return Ok(res);
        }

        //[HttpGet("monthly-revenue")]
        //public IActionResult GetMonthlyRevenue(int year, int month)
        //{
        //    var res = statisticsSvc.CalculateMonthlyRevenue(year, month);
        //    return Ok(res);
        //}

        //[HttpGet("yearly-revenue")]
        //public IActionResult GetYearlyRevenue(int year)
        //{
        //    var res = statisticsSvc.CalculateYearlyRevenue(year);
        //    return Ok(res);
        //}

        [HttpGet("rented-cars-count")]
        public IActionResult GetRentedCarsCount(DateTime date)
        {
            var res = statisticsSvc.GetRentalsBySpecificMonth(date);
            return Ok(res);
        }
    }
}



