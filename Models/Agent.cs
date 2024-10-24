using System;
using System.Collections.Generic;

namespace Swagriham.Models;

public partial class Agent
{
    public int AgentId { get; set; }

    public int? UserId { get; set; }

    public string AgencyName { get; set; } = null!;

    public int? Experience { get; set; }

    public virtual User? User { get; set; }
}
