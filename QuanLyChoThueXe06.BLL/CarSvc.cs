using QuanLyChoThueXe06.Common.BLL;
using QuanLyChoThueXe06.Common.DAL;
using QuanLyChoThueXe06.Common.Req;
using QuanLyChoThueXe06.Common.Rsp;
using QuanLyChoThueXe06.DAL;
using QuanLyChoThueXe06.DAL.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe06.BLL
{
    public class CarSvc : GenericSvc<CarRep, Car>
    {
        private CarRep carRep;

        #region -- Overrides --

        public SingleRsp GetCarById(int id)
        {
            var res = new SingleRsp();
            var car = carRep.Read(id);
            if (car != null)
            {
                var carRsp = new CarReq
                {
                    CarId = car.CarId,
                    Brand = car.Brand,
                    Model = car.Model,
                    Color = car.Color,
                    PricePerDay = car.PricePerDay,
                    Status = car.Status
                };
                res.Data = carRsp;
            }
            else
            {
                res.SetError("No data");
            }
            return res;
        }

        public SingleRsp DeleteCar(int id)
        {
            var res = new SingleRsp();
            var car = carRep.Read(id);
            if (car != null)
            {
                res = carRep.DeleteCar(car);
                res.SetMessage("Xoa thanh cong");
            }
            else
            {
                res.SetError("No Data");
            }
            return res;
        }


        public CarSvc()
        {
            carRep = new CarRep();
        }

        public SingleRsp UpdateCar(int id,CarReq c)
        {
            var res = new SingleRsp();
            var cx = carRep.Read(id);
            if (cx != null)
            {
                try
                {
                    //cx.CarId = c.CarId,
                    cx.Brand = c.Brand;
                    cx.Model = c.Model;
                    cx.Color = c.Color;
                    cx.PricePerDay = c.PricePerDay;
                    cx.Status = c.Status;
                    res = carRep.UpdateCar(cx);
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
        #endregion

        public SingleRsp CreateCar (CarReq carReq)
        {
            var res = new SingleRsp();
            Car car = new Car();
            try
            {
                car.CarId = carReq.CarId;
                car.Brand = carReq.Brand;
                car.Model = carReq.Model;
                car.Color = carReq.Color;
                car.PricePerDay = carReq.PricePerDay;
                car.Status = carReq.Status;
                res = carRep.CreateCar(car);
                res.SetMessage("Tao thanh cong");
            }
            catch (Exception ex)
            {

                res.SetError("Tao that bai");
            }
            return res;
        }


        public SingleRsp SearchCar(SearchCarReq searchCarReq)
        {
            var res = new SingleRsp();
            //Lấy DSXe theo từ khóa
            var cars = carRep.SearchCar(searchCarReq.Keyword);
            //Xử lý phân trang
            int cCount, totalPages, offset;
            offset = searchCarReq.Size * (searchCarReq.Page - 1);
            cCount = cars.Count;
            totalPages = (cCount%searchCarReq.Size)==0?  cCount / searchCarReq.Size: 1 + (cCount / searchCarReq.Size);
            var c = new
            {
                Data = cars.Skip(offset).Take(searchCarReq.Size).ToList(),
                Page = searchCarReq.Page,
                Size = searchCarReq.Size
            };
            res.Data = c;
            return res;
        }

        public SingleRsp UpdateCar(CarReq carReq)
        {
            var res = new SingleRsp();
            Car car = new Car();
            try
            {
                car.CarId = carReq.CarId;
                car.Brand = carReq.Brand;
                car.Model = carReq.Model;
                car.Color = carReq.Color;
                car.PricePerDay = carReq.PricePerDay;
                car.Status = carReq.Status;
                res = carRep.UpdateCar(car);
                res.SetMessage("Cap nhat thanh cong");
            }
            catch (Exception ex)
            {

                res.SetError("Not Data");
            }
            return res;
        }
    }
}
