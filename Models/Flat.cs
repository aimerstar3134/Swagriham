using System;
using System.Collections.Generic;

namespace Swagriham.Models;

public partial class Flat
{
    public int FlatId { get; set; }

    public string ProjectName { get; set; } = null!;

    public int LocationId { get; set; }

    public decimal Price { get; set; }

    public string Bhk { get; set; } = null!;

    public decimal? CarpetArea { get; set; }

    public decimal? SuperBuiltUpArea { get; set; }

    public int? FloorNumber { get; set; }

    public int? TotalFloors { get; set; }

    public string? FurnishingStatus { get; set; }

    public string? Parking { get; set; }

    public int? AgeOfProperty { get; set; }

    public string? FacingDirection { get; set; }

    public string PossessionStatus { get; set; } = null!;

    public string? Reranumber { get; set; }

    public decimal? MaintenanceCharges { get; set; }

    public string? Description { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

    public virtual ICollection<FlatPhoto> FlatPhotos { get; set; } = new List<FlatPhoto>();

    public virtual Location Location { get; set; } = null!;

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual User? User { get; set; }

    public virtual ICollection<Amenity> Amenities { get; set; } = new List<Amenity>();
}
