using System;
using System.Collections.Generic;

namespace Swagriham.Models;

public partial class Location
{
    public int LocationId { get; set; }

    public string CityName { get; set; } = null!;

    public string StateName { get; set; } = null!;

    public string? LocalityName { get; set; }

    public int? Pincode { get; set; }

    public virtual ICollection<Flat> Flats { get; set; } = new List<Flat>();
}
