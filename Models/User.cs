using System;
using System.Collections.Generic;

namespace Swagriham.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string UserType { get; set; } = null!;

    public virtual ICollection<Agent> Agents { get; set; } = new List<Agent>();

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<Flat> Flats { get; set; } = new List<Flat>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
