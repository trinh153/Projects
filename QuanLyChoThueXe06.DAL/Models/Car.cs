using System;
using System.Collections.Generic;

namespace QuanLyChoThueXe06.DAL.Models;

public partial class Car
{
    public Car()
    {
        Rentals = new HashSet<Rental>();
    }
    public int CarId { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public string Color { get; set; } = null!;

    public decimal PricePerDay { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
