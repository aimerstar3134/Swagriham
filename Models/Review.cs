using System;
using System.Collections.Generic;

namespace Swagriham.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int? FlatId { get; set; }

    public int? UserId { get; set; }

    public int? Rating { get; set; }

    public string? ReviewText { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Flat? Flat { get; set; }

    public virtual User? User { get; set; }
}
