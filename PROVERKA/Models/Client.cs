using System;
using System.Collections.Generic;

namespace PROVERKA.Models;

public partial class Client
{
    public int? IdClient { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public int? IdAgent { get; set; }

    public string? Login { get; set; }

    public string? Passwd { get; set; }

    public virtual ICollection<Agreement> Agreements { get; set; } = new List<Agreement>();

    public virtual Agent? IdAgentNavigation { get; set; }
}
