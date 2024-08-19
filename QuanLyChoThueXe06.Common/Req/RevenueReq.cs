using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe06.Common.Req
{
    public partial class RevenueReq
    {
        public int RevenueId { get; set; }

        public int RentalId { get; set; }

        public DateTime RevenueDate { get; set; }

        public decimal Amount { get; set; }

    }
}