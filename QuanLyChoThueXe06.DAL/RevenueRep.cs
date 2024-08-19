using QuanLyChoThueXe06.Common.DAL;
using QuanLyChoThueXe06.Common.Rsp;
using QuanLyChoThueXe06.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe06.DAL
{
    public class RevenueRep : GenericRep<QuanLyChoThueXe06Context, Revenue>
    {
        #region -- Overrides --


        public override Revenue Read(int id)
        {
            var res = All.FirstOrDefault(c => c.RevenueId == id);
            return res;
        }

        #endregion

        #region -- Methods --

        public SingleRsp CreateRevenue(Revenue revenue)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyChoThueXe06Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var e = context.Revenues.Add(revenue);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Tao Revenue thanh cong");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Tao Revenue that bai");
                    }
                }
            }
            return res;
        }
        public SingleRsp UpdateRevenue(Revenue revenue)
        {
            var res = new SingleRsp();

            using (var context = new QuanLyChoThueXe06Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Revenues.Update(revenue);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Update Revenue thanh cong");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Update Revenue that bai");
                    }
                }
            }
            return res;
        }
        public SingleRsp DeleteRevenue(Revenue revenue)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyChoThueXe06Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Revenues.Remove(revenue);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Da xoa revenue");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Xoa that bai");
                    }
                }
            }
            return res;
        }

        public Revenue GetRevenueByID(int id)
        {
            var revenue = All.FirstOrDefault(c => c.RevenueId == id);
            return revenue;
        }
        #endregion
    }
}
    

