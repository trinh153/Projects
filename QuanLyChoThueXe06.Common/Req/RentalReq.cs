using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe06.Common.Req
{
    public class RentalReq
    {
        //public int RentalId { get; set; }
        public int CustomerId { get; set; }

        public int CarId { get; set; }

        public DateTime RentalDate { get; set; }

        public DateTime? ReturnDate { get; set; }
        public string? Issues { get; set; }


    }
}
