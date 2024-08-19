using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyChoThueXe06.BLL;
using QuanLyChoThueXe06.Common.Req;
using QuanLyChoThueXe06.Common.Rsp;

namespace QuanLyChoThueXe06.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private CarSvc carSvc;
        public CarController()
        {
            carSvc = new CarSvc();
        }

        [HttpGet("get-by-id")]
        public IActionResult GetCarById(int id)
        {
            var res = carSvc.GetCarById(id);
            return Ok(res);
        }


        [HttpGet("get-all")]
        public IActionResult getAllCars()
        {
            var res = new SingleRsp();
            res.Data = carSvc.All;
            return Ok(res);
        }

        [HttpPost("create-car")]
        public IActionResult CreateCar([FromBody] CarReq carReq)
        {
            var res = new SingleRsp();
            res = carSvc.CreateCar(carReq);
            return Ok(res);
        }

        [HttpPost("search-car")]
        public IActionResult SearchCar([FromBody] SearchCarReq searchCarReq) 
        {
            var res = new SingleRsp();
            res.Data = carSvc.SearchCar(searchCarReq);
            return Ok(res);
        }


        [HttpPut("update-car")]
        public IActionResult UpdateCar(int id,[FromBody] CarReq carReq)
        {
            var res = carSvc.UpdateCar(id,carReq);
            return Ok(res);
        }

        [HttpDelete("delete-by-id")]
        public IActionResult DeleteCar(int id)
        {
            var res = carSvc.DeleteCar(id);
            return Ok(res);
        }
    }
}
