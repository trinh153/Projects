using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe06.Common.Req
{

    public class CarReq 
    {
      
        public int CarId { get; set; }

        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

        public string Color { get; set; } = null!;

        public decimal PricePerDay { get; set; }

        public string Status { get; set; } = null!;

    }
}
