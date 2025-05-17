using System;
using System.Collections.Generic;

namespace PROVERKA.Models;

public partial class ЗаказНаЗвонок
{
    public int? IdЗвонка { get; set; }

    public string? Фио { get; set; }

    public string? Телефон { get; set; }

    public DateTime? Дата { get; set; }

    public virtual ПринятыеЗвонки? ПринятыеЗвонки { get; set; }
}
