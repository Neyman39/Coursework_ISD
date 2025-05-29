using System;
using System.Collections.Generic;

namespace PROVERKA.Models;

public partial class InsuranceTypeField
{
    public int? IdField { get; set; }

    public int? IdInsurance { get; set; }

    public virtual Field? IdFieldNavigation { get; set; }

    public virtual InsuranceType? IdInsuranceNavigation { get; set; }
}
