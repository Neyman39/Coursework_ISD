using System;
using System.Collections.Generic;

namespace PROVERKA.Models;

public partial class ПолеВидаСтрахования
{
    public int? IdПоле { get; set; }

    public int? IdСтрахование { get; set; }

    public virtual Поле? IdПолеNavigation { get; set; }

    public virtual InsuranceType? IdСтрахованиеNavigation { get; set; }
}
