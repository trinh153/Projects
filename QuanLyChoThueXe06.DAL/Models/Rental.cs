using System;
using System.Collections.Generic;

namespace QuanLyChoThueXe06.DAL.Models;

public partial class Rental
{
    public int RentalId { get; set; }

    public int CustomerId { get; set; }

    public int CarId { get; set; }

    public DateTime RentalDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string? Issues { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Revenue> Revenues { get; set; } = new List<Revenue>();
}
