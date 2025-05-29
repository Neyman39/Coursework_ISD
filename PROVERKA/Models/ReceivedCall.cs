using System;
using System.Collections.Generic;

namespace PROVERKA.Models;

public partial class ReceivedCall
{
    public int? IdCall { get; set; }

    public int? IdAgent { get; set; }

    public DateTime? RegDate { get; set; }

    public DateTime? RegTime { get; set; }

    public virtual OrderByCall IdCallNavigation { get; set; } = null!;
}
