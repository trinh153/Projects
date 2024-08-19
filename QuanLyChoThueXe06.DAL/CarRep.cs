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
    public class CarRep : GenericRep<QuanLyChoThueXe06Context, Car>
    {
        public override Car Read(int id)
        {
            return All.FirstOrDefault(c => c.CarId == id);
        }

        public SingleRsp DeleteCar(Car car)
        {
            var res = new SingleRsp();
            try
            {
                Context.Cars.Remove(car);
                Context.SaveChanges();
                res.Data = car;
            }
            catch (Exception ex)
            {
                res.SetError(ex.StackTrace);
            }
            return res;
        }

        #region --Methods -- 
        public SingleRsp CreateCar (Car car)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyChoThueXe06Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Cars.Add(car);
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

        public List<Car> SearchCar(string keyword)
        {
            return All.Where(x=>x.Brand.Contains(keyword)).ToList();
        }

        public SingleRsp UpdateCar(Car car)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyChoThueXe06Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Cars.Update(car);
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
