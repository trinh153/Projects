using QuanLyChoThueXe06.Common.BLL;
using QuanLyChoThueXe06.Common.Rsp;
using QuanLyChoThueXe06.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebDT.DAL;

using static WebDT.DAL.ThongKeRep;

namespace WebDT.BLL
{
    public class ThongKeSvc : GenericSvc<ThongKeRep, Rental>
    {
        private ThongKeRep thongKe;

        public ThongKeSvc()
        {
            thongKe = new ThongKeRep();
        }

        //public SingleRsp ThongKeDoanhThu(DateTime startDate, DateTime endDate)
        //{
        //    var res = thongKe.GetSaleInDateRange(startDate, endDate);
        //    return res;
        //}

        public SingleRsp ThongKeDoanhThuTheoNgay(DateTime fromDate, DateTime toDate)
        {
            var res = new SingleRsp();
            var total = thongKe.ThongKeDoanhThuTheoNgay(fromDate, toDate);
            var result = new
            {
                startDate = fromDate,
                enDate = toDate,
                TotalSale = total,

            };
            res.Data = result;
            return res;

        }
        public decimal? GetRentalsBySpecificMonth(DateTime month)
        {
            return thongKe.ThongKeXeThueTheoThang(month);
        }
    }
}