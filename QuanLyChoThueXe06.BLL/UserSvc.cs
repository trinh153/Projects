using QuanLyChoThueXe06.Common.Req;
using QuanLyChoThueXe06.Common.Rsp;
using QuanLyChoThueXe06.DAL.Models;
using QuanLyChoThueXe06.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace QuanLyChoThueXe06.BLL
{
    public class UserSvc
    {
        private UserRep userRep = new UserRep();


        public SingleRsp Register(UserReq req)
        {
            var res = new SingleRsp();
            var user = new User();
            user.Username = req.Username;
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(req.Password); ;
            user.Role = "user";
            res = userRep.CreateUser(user);
            res.SetMessage("Tao thanh cong");
            return res;
        }

        public SingleRsp Login(LoginReq req)
        {
            var res = new SingleRsp();
            var user = userRep.GetUserByUsername(req.Username);

            if (user != null)
            {
                if (BCrypt.Net.BCrypt.Verify(req.Password, user.PasswordHash))
                {
                    res.SetData("200",user);
                    return res;
                }
                // Generate token
                res.SetError("Error");
            }
            else
            {
                res.SetError("Invalid username or password");
            }

            return res;
        }

        private string GenerateToken(User user)
        {
            // Generate a JWT token
            // This is a placeholder, replace with actual JWT token generation logic
            return "generated-jwt-token";
        }


    }
}
