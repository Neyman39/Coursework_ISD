using System;
using System.Collections.Generic;

namespace PROVERKA.Models;

public partial class InsuranceType
{
    public int? IdInsurance { get; set; }

    public string? Name { get; set; }

    public int? TariffRate { get; set; }

    public virtual ICollection<Договор> Договорs { get; set; } = new List<Договор>();
}
