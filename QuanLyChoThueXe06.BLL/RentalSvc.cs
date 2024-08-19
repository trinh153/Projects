using QuanLyChoThueXe06.Common.BLL;
using QuanLyChoThueXe06.Common.Rsp;
using QuanLyChoThueXe06.DAL.Models;
using QuanLyChoThueXe06.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyChoThueXe06.Common.Req;

namespace QuanLyChoThueXe06.BLL
{
    public class RentalSvc : GenericSvc<RentalRep, Rental>
    {
        private RentalRep rentalRep;

        private CarRep carRep;

        public RentalSvc()
        {
            rentalRep = new RentalRep();
        }

        #region -- Overrides --

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            if (res.Data == null)
            {
                res.SetMessage("Khong tim thay rental");
                res.SetError("404", "Khong tim thay rental");
            }
            return res;
        }

        #endregion
        public SingleRsp CreateRental(RentalReq req)
        {
            var res = new SingleRsp();
            Rental rental = new Rental();


            try
            {
                rental.CustomerId = req.CustomerId;
                rental.CarId = req.CarId;
                rental.RentalDate = req.RentalDate;
                rental.ReturnDate = req.ReturnDate;
                rental.Issues = req.Issues;

                res = base.Create(rental);
                res.SetMessage("Tao thanh cong");
            }
            catch (Exception ex)
            {

                res.SetError("Tao khong thanh cong");
            }
            return res;
        }

        public SingleRsp DeleteRental(int id)
        {
            var res = new SingleRsp();
            var rental = rentalRep.Read(id);
            if (rental != null)
            {
                res = rentalRep.DeleteRental(rental);
                res.SetMessage("Xoa thanh cong");
            }
            else
            {
                res.SetError("No data");
            }
            return res;
        }
        public SingleRsp UpdateRental(int id,RentalReq rentalReq)
        {
            var res = new SingleRsp();
            //Rental rental = new Rental();
            var rental = rentalRep.Read(id);
            if (rental != null)
            {
                try
                {
                    //rental.RentalId = rentalReq.RentalId;
                    rental.CustomerId = rentalReq.CustomerId;
                    rental.CarId = rentalReq.CarId;
                    rental.RentalDate = rentalReq.RentalDate;
                    rental.ReturnDate = rentalReq.ReturnDate;
                    rental.Issues = rentalReq.Issues;
                    res = rentalRep.UpdateRental(rental);
                    res.SetMessage("Cap nhat thanh cong");
                }
                catch (Exception)
                {

                    res.SetError("No data");
                }
            }
            else { res.SetError("No data"); }
            
            return res;
        }

        public SingleRsp SearchRentals(SearchRentalReq req)
        {
            var res = new SingleRsp();
            var rentals = _rep.Context.Rentals.AsQueryable();

            if (!string.IsNullOrEmpty(req.CustomerName))
            {
                rentals = rentals.Where(r => r.Customer.FullName.Contains(req.CustomerName));
            }

            if (!string.IsNullOrEmpty(req.CarBrand))
            {
                rentals = rentals.Where(r => r.Car.Brand.Contains(req.CarBrand));
            }

            if (req.RentalDate.HasValue)
            {
                rentals = rentals.Where(r => r.RentalDate.Date == req.RentalDate.Value.Date);
            }

            res.Data = rentals;
            return res;
        }
    }
}
