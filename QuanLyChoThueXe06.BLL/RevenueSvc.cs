
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyChoThueXe06.Common.BLL;
using QuanLyChoThueXe06.Common.Req;
using QuanLyChoThueXe06.Common.Rsp;
using QuanLyChoThueXe06.DAL;
using QuanLyChoThueXe06.DAL.Models;


namespace QuanLyChoThueXe06.BLL
{
    public class RevenueSvc : GenericSvc<RevenueRep, Revenue>
    {
        private RevenueRep revenueRep;
        #region -- Overrides --

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            if (res.Data == null)
            {
                res.SetMessage("Khong tim thay revenue");
                res.SetError("404", "Khong tim thay revenue");
            }
            return res;
        }

        #endregion

        #region -- Methods --

        public RevenueSvc()
        {
            revenueRep = new RevenueRep();
        }
        public SingleRsp CreateRevenue(RevenueReq revenueReq)
        {
            var res = new SingleRsp();
            Revenue c = new Revenue();
            try
            {

                c.RentalId = revenueReq.RentalId;
                c.RevenueDate = revenueReq.RevenueDate;
                c.Amount = revenueReq.Amount;

                res = revenueRep.CreateRevenue(c);
                res.SetMessage("Tao thanh cong");
            }
            catch (Exception)
            {

                res.SetError("Tao that bai");
            }
            return res;
        }

        public SingleRsp UpdateRevenue(int id, RevenueReq revenueReq)
        {

            var res = new SingleRsp();
            var cx = revenueRep.Read(id);
            if(cx != null)
            {
                try
                {
                    cx.RentalId = revenueReq.RentalId;
                    cx.RevenueDate = revenueReq.RevenueDate;
                    cx.Amount = revenueReq.Amount;
                    res = revenueRep.UpdateRevenue(cx);
                    res.SetMessage("Cap nhat thanh cong");
                }
                catch (Exception)
                {

                    res.SetError("No data");
                }
            }
            else
            {
                res.SetError("No data");
            }    
            return res;
        }

        public SingleRsp DeleteRevenue(int revenueId)
        {
            var rsp = new SingleRsp();

            try
            {
                // Find the existing employee
                var revenue = revenueRep.Read(revenueId);

                if (revenue == null)
                {
                    rsp.SetError($"revenue with ID {revenueId} not found.");
                    return rsp;
                }
                // Delete the employee from the database
                revenueRep.DeleteRevenue(revenue);
                rsp.SetMessage("Revenue deleted successfully.");
            }
            catch (Exception ex)
            {
                rsp.SetError(ex.StackTrace);
                rsp.SetMessage("Failed to delete revenue.");
            }

            return rsp;
        }

        public Revenue GetRevenueByID(int id)
        {
            Revenue revenue = revenueRep.GetRevenueByID(id);
            if (revenue == null)
            {
                return null;
            }
            return revenue;
        }
        #endregion
    }
}