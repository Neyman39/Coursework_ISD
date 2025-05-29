using System;
using System.Collections.Generic;

namespace PROVERKA.Models;

public partial class Agreement
{
    public int? IdAgreement { get; set; }

    public string? RegDate { get; set; }

    public decimal? SumInsured { get; set; }

    public int? IdInsurance { get; set; }

    public int? IdAgent { get; set; }

    public int? IdClient { get; set; }

    public int? IdBranch { get; set; }

    public virtual Agent? IdAgentNavigation { get; set; }

    public virtual Branch? IdBranchNavigation { get; set; }

    public virtual Client? IdClientNavigation { get; set; }

    public virtual InsuranceType? IdInsuranceNavigation { get; set; }
}
