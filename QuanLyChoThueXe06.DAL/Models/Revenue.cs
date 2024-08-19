using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe06.DAL.Models
{
    public partial class Revenue
    {
        public int RevenueId { get; set; }

        public int RentalId { get; set; }

        public DateTime RevenueDate { get; set; }

        public decimal Amount { get; set; }

        public virtual Rental Rental { get; set; } = null!;
    }
}