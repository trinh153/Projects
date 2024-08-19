using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyChoThueXe06.BLL;
using QuanLyChoThueXe06.Common.Req;
using QuanLyChoThueXe06.Common.Rsp;
using QuanLyChoThueXe06.DAL.Models;

namespace QuanLyChoThueXe06.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevenueController : ControllerBase
    {
        private RevenueSvc revenueSvc;
        public RevenueController()
        {
            revenueSvc = new RevenueSvc();
        }

        [HttpPost]
        [Route("{id}")]
        public IActionResult GetRevenueByID(int id)
        {
            var rsp = new SingleRsp();
            rsp = revenueSvc.Read(id);
            return Ok(rsp);
        }

        [HttpGet("GetAllRevenue")]
        public IActionResult GetRevenueByALL()
        {
            var rsp = new SingleRsp();
            rsp.Data = revenueSvc.All;
            return Ok(rsp);
        }

        [HttpPost("CreateRevenue")]
        public IActionResult CreateRevenue(RevenueReq revenueReq)
        {
            var rsp = new SingleRsp();
            rsp = revenueSvc.CreateRevenue(revenueReq);
            return Ok(rsp);
        }

        [HttpPut("UpdateRevenue/{id}")]
        public IActionResult UpdateRevenue(int id, [FromBody] RevenueReq revenueReq)
        {
            var rsp = new SingleRsp();
            rsp = revenueSvc.UpdateRevenue(id, revenueReq);
            return Ok(rsp);
        }

        [HttpDelete("DeleteRevenue")]
        public IActionResult DeleteRevenue(int id)
        {
            var rsp = new SingleRsp();
            rsp = revenueSvc.DeleteRevenue(id);
            return Ok(rsp);
        }
    }
}

