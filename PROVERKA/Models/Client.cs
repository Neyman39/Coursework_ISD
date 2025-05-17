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

    public virtual Agent? IdАгентаNavigation { get; set; }

    public virtual ICollection<Договор> Договорs { get; set; } = new List<Договор>();
}
