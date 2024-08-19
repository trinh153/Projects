
using System;
using System.Collections.Generic;
using System.Text;
using QuanLyChoThueXe06.Common.BLL;
using QuanLyChoThueXe06.Common.Req;
using QuanLyChoThueXe06.Common.Rsp;
using QuanLyChoThueXe06.DAL.Models;
using QuanLyChoThueXe06.DAL;

namespace QuanLyChoThueXe06.BLL
{
    public class CustomerSvc : GenericSvc<CustomerRep, Customer>
    {
        private CustomerRep customerRep;
        #region -- Overrides --

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            if (res.Data == null)
            {
                res.SetMessage("Không tìm thấy customer");
                res.SetError("404", "Không tìm thấy customer");
            }
            return res;
        }

        public override SingleRsp Update(Customer c)
        {
            var res = new SingleRsp();

            var c1 = c.CustomerId > 0 ? _rep.Read(c.CustomerId) : _rep.Read(c.CustomerId);
            if (c1 == null)
            {
                res.SetError("No data.");
            }
            else
            {
                res = base.Update(c);
                res.Data = c;

            }

            return res;
        }

        #endregion

        #region -- Methods --

        public CustomerSvc()
        {
            customerRep = new CustomerRep();
        }
        public SingleRsp CreateCustomer(CustomerReq customerReq)
        {
            var res = new SingleRsp();
            Customer c = new Customer();

            try
            {
                c.FullName = customerReq.FullName;
                c.PhoneNumber = customerReq.PhoneNumber;
                c.Email = customerReq.Email;
                c.Address = customerReq.Address;

                res = customerRep.CreateCustomer(c);
                res.SetMessage("Tao thanh cong");
            }
            catch (Exception ex)
            {

                res.SetError("No data");
            }

            return res;
        }

        public SingleRsp UpdateCustomer(int id, CustomerReq customerReq)
        {

            var res = new SingleRsp();
            //Customer cx = new Customer();
            var cx = customerRep.Read(id);
            if(cx == null)
            {
                res.SetError("No data");
            }
            else
            {
                try
                {
                    cx.FullName = customerReq.FullName;
                    cx.PhoneNumber = customerReq.PhoneNumber;
                    cx.Email = customerReq.Email;
                    cx.Address = customerReq.Address;
                    res = customerRep.UpdateCustomer(cx);
                    res.SetMessage("Cap nhat thanh cong");

                }
                catch (Exception ex)
                {
                    res.SetError("No data");
                }
            }
            
            return res;
        }

        public SingleRsp DeleteCustomer(int customerId)
        {
            var rsp = new SingleRsp();

            try
            {
                // Find the existing employee
                var customer = customerRep.Read(customerId);

                if (customer == null)
                {
                    rsp.SetError($"customer with ID {customerId} not found.");
                    return rsp;
                }
                // Delete the employee from the database
                customerRep.DeleteCustomer(customer);
                rsp.SetMessage("Customer deleted successfully.");
            }
            catch (Exception ex)
            {
                rsp.SetError(ex.StackTrace);
                rsp.SetMessage("Failed to delete customer.");
            }

            return rsp;
        }

        public Customer GetCustomerByID(int id)
        {
            Customer customer = customerRep.GetCustomerByID(id);
            if (customer == null)
            {
                return null;
            }
            return customer;
        }
        #endregion
    }
}