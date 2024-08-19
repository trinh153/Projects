using QuanLyChoThueXe06.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyChoThueXe06.BLL
{
    public class CarRentalStatisticsSvc
    {
        private readonly QuanLyChoThueXe06Context context;

        public CarRentalStatisticsSvc(QuanLyChoThueXe06Context context)
        {
            context = context;
        }

        public int GetCarRentalsByDay(DateTime date)
        {
            return context.Rentals
                .Count(r => r.RentalDate.Date == date.Date);
        }

        public int GetCarRentalsByMonth(int month, int year)
        {
            return context.Rentals
                .Count(r => r.RentalDate.Month == month && r.RentalDate.Year == year);
        }

        public int GetCarRentalsByYear(int year)
        {
            return context.Rentals
                .Count(r => r.RentalDate.Year == year);
        }
    }
}