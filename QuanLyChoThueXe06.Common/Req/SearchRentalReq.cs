using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe06.Common.Req
{
    public class SearchRentalReq
    {
        public string CustomerName { get; set; }
        public string CarBrand { get; set; }
        public DateTime? RentalDate { get; set; }
    }
}
