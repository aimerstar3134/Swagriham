using System;
using System.Collections.Generic;

namespace Swagriham.Models;

public partial class Amenity
{
    public int AmenityId { get; set; }

    public string AmenityName { get; set; } = null!;

    public virtual ICollection<Flat> Flats { get; set; } = new List<Flat>();
}
