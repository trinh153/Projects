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
    public class RentalRep : GenericRep<QuanLyChoThueXe06Context, Rental>
    {
        public override Rental Read(int id)
        {
            return All.FirstOrDefault(c => c.RentalId == id);
        }

        public SingleRsp DeleteRental(Rental rental)
        {
            var res = new SingleRsp();
            try
            {
                Context.Rentals.Remove(rental);
                Context.SaveChanges();
                res.Data = rental;
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }

        #region --Methods -- 
        public SingleRsp CreateRental(Rental rental)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyChoThueXe06Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Rentals.Add(rental);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }


        public SingleRsp UpdateRental(Rental rental)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyChoThueXe06Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Rentals.Update(rental);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }

        #endregion
    }
}
