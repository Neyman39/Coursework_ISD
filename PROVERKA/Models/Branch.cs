using System;
using System.Collections.Generic;

namespace PROVERKA.Models;

public partial class Branch
{
    public int? IdBranch { get; set; }

    public string? Nomination { get; set; }

    public string? Adress { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Agreement> Agreements { get; set; } = new List<Agreement>();
}
