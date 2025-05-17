using System;
using System.Collections.Generic;

namespace PROVERKA.Models;

public partial class ClientQueue
{
    public int? Id { get; set; }

    public int? IdAgent { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public DateTime? RegDate { get; set; }

    //public virtual Agent? IdAgentNavigation { get; set; }
}
