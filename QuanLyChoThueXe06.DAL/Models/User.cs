using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace QuanLyChoThueXe06.DAL.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; }
    [JsonIgnore]
    public string PasswordHash { get; set; }

    public string Role { get; set; }
}
