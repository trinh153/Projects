﻿using QuanLyChoThueXe06.Common.DAL;
using QuanLyChoThueXe06.Common.Rsp;
using QuanLyChoThueXe06.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuanLyChoThueXe06.DAL
{
    public class CustomerRep : GenericRep<QuanLyChoThueXe06Context, Customer>
    {
        #region -- Overrides --


        public override Customer Read(int id)
        {
            var res = All.FirstOrDefault(c => c.CustomerId == id);
            return res;
        }

        #endregion

        #region -- Methods --

        public SingleRsp CreateCustomer(Customer customer)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyChoThueXe06Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var e = context.Customers.Add(customer);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Tao Customer thanh cong");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Tao Customer that bai");
                    }
                }
            }
            return res;
        }
        public SingleRsp UpdateCustomer(Customer customer)
        {
            var res = new SingleRsp();

            using (var context = new QuanLyChoThueXe06Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Customers.Update(customer);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Update Customer thanh cong");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                        res.SetMessage("Update Customer that bai");
                    }
                }
            }
            return res;
        }
        public SingleRsp DeleteCustomer(Customer customer)
        {
            var res = new SingleRsp();
            using (var context = new QuanLyChoThueXe06Context())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Customers.Remove(customer);
                        context.SaveChanges();
                        tran.Commit();
                        res.SetMessage("Da xoa Customer");
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

        public Customer GetCustomerByID(int id)
        {
            var customer = All.FirstOrDefault(c => c.CustomerId == id);
            return customer;
        }
        #endregion
    }
}