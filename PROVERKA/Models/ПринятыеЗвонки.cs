using System;
using System.Collections.Generic;

namespace PROVERKA.Models;

public partial class ПринятыеЗвонки
{
    public int? IdЗвонка { get; set; }

    public int? IdАгента { get; set; }

    public DateTime? Дата { get; set; }

    public DateTime? Время { get; set; }

    public virtual ЗаказНаЗвонок IdЗвонкаNavigation { get; set; } = null!;
}
