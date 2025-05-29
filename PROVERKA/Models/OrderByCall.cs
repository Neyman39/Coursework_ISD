using System;
using System.Collections.Generic;

namespace PROVERKA.Models;

public partial class OrderByCall
{
    public int? IdCall { get; set; }

    public string? FullName { get; set; }

    public string? Phone { get; set; }

    public DateTime? RegDate { get; set; }

    public virtual ReceivedCall? ReceivedCall { get; set; }
}
