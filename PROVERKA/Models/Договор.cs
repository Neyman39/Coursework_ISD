using System;
using System.Collections.Generic;

namespace PROVERKA.Models;

public partial class Договор
{
    public int? IdДоговора { get; set; }

    public string? Дата { get; set; }

    public decimal? СтраховаяСумма { get; set; }

    public int? IdСтрахования { get; set; }

    public int? IdАгента { get; set; }

    public int? IdКлиента { get; set; }

    public int? IdФилиала { get; set; }

    public virtual Agent? IdАгентаNavigation { get; set; }

    public virtual Client? IdКлиентаNavigation { get; set; }

    public virtual InsuranceType? IdСтрахованияNavigation { get; set; }

    public virtual Филиал? IdФилиалаNavigation { get; set; }
}
