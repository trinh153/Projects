﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyChoThueXe06.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuanLyChoThueXe06.Common.Rsp;
using QuanLyChoThueXe06.Common.Req;
using QuanLyChoThueXe06.DAL;



namespace QuanLyChoThueXe06.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private CustomerSvc customerSvc;
        public CustomerController()
        {
            customerSvc = new CustomerSvc();
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult GetCustomerByID(int id)
        {
            var rsp = new SingleRsp();
            rsp = customerSvc.Read(id);
            return Ok(rsp);
        }

        [HttpGet("GetAllCustomer")]
        public IActionResult GetCustomerByALL()
        {
            var rsp = new SingleRsp();
            rsp.Data = customerSvc.All;
            return Ok(rsp);
        }

        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer(CustomerReq customerReq)
        {
            var rsp = new SingleRsp();
            rsp = customerSvc.CreateCustomer(customerReq);
            return Ok(rsp);
        }

        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer(int id,[FromBody]CustomerReq customerReq)
        {
            //var rsp = new SingleRsp();
            var res = customerSvc.UpdateCustomer(id,customerReq);
            return Ok(res);
        }

        [HttpDelete("DeleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            var rsp = new SingleRsp();
            rsp = customerSvc.DeleteCustomer(id);
            return Ok(rsp);
        }
    }
}
