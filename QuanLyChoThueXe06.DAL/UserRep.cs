using QuanLyChoThueXe06.Common.DAL;
using QuanLyChoThueXe06.Common.Rsp;
using QuanLyChoThueXe06.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe06.DAL
{
    public class UserRep : GenericRep<QuanLyChoThueXe06Context, User>
    {
        public SingleRsp CreateUser(User user)
        {
            QuanLyChoThueXe06Context context = new QuanLyChoThueXe06Context();
            var res = new SingleRsp();
            try
            {
                Console.WriteLine(user);
                var tmpuser =context.Users.Add(user);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                res.SetError(ex.Message);
            }
            return res;
        }

        public User GetUserByUsername(string username)
        {
            return Context.Users.FirstOrDefault(u => u.Username == username);
        }
    }
}
