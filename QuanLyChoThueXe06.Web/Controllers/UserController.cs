using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyChoThueXe06.BLL;
using QuanLyChoThueXe06.Common.Req;

namespace QuanLyChoThueXe06.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserSvc userSvc = new UserSvc();


        [HttpPost("register")]
        public IActionResult Register([FromBody] UserReq req)
        {
            var res = userSvc.Register(req);
            return Ok(res);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginReq req)
        {
            var res = userSvc.Login(req);
            return Ok(res);
        }

    }
}
    

    

