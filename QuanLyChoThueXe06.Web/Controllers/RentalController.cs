using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyChoThueXe06.BLL;
using QuanLyChoThueXe06.Common.Req;
using QuanLyChoThueXe06.Common.Rsp;

namespace QuanLyChoThueXe06.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private RentalSvc rentalSvc;
        public RentalController()
        {
            rentalSvc = new RentalSvc();
        }

        [HttpPost]
        [Route("get-by-id")]
        public IActionResult GetRentalByID(int id)
        {
            var rsp = new SingleRsp();
            rsp = rentalSvc.Read(id);
            return Ok(rsp);
        }


        [HttpGet("get-all")]
        public IActionResult getAllRentals()
        {
            var res = new SingleRsp();
            res.Data = rentalSvc.All;
            return Ok(res);
        }

        [HttpPost("create-rental")]
        public IActionResult CreateRental([FromBody] RentalReq rentalReq)
        {
            var res = new SingleRsp();
            res = rentalSvc.CreateRental(rentalReq);
            return Ok(res);
        }

        [HttpPost("search-rental")]
        public IActionResult SearchRental([FromBody] SearchRentalReq searchRentalReq)
        {
            var res = new SingleRsp();
            res.Data = rentalSvc.SearchRentals(searchRentalReq);
            return Ok(res);
        }


        [HttpPut("update-rental")]
        public IActionResult UpdateRental(int id,[FromBody] RentalReq rentalReq)
        {
            var res = rentalSvc.UpdateRental(id,rentalReq);
            return Ok(res);
        }

        [HttpDelete("delete-by-id")]
        public IActionResult DeleteRental(int id)
        {
            var res = rentalSvc.DeleteRental(id);
            return Ok(res);
        }
    }
}
