using System;
using System.Collections.Generic;

namespace QuanLyChoThueXe06.DAL.Models;

public partial class Customer
{
    public Customer()
    {
        Rentals = new HashSet<Rental>();
    }
    public int CustomerId { get; set; }

    public string FullName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}
