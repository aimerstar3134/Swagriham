using System;
using System.Collections.Generic;

namespace Swagriham.Models;

public partial class FlatPhoto
{
    public int PhotoId { get; set; }

    public int? FlatId { get; set; }

    public string PhotoUrl { get; set; } = null!;

    public bool? IsPrimary { get; set; }

    public virtual Flat? Flat { get; set; }
}
