using System;
using System.Collections.Generic;

namespace Swagriham.Models;

public partial class Contact
{
    public int InquiryId { get; set; }

    public int? FlatId { get; set; }

    public int? UserId { get; set; }

    public string Message { get; set; } = null!;

    public DateTime? ContactDate { get; set; }

    public string ResponseStatus { get; set; } = null!;

    public virtual Flat? Flat { get; set; }

    public virtual User? User { get; set; }
}
