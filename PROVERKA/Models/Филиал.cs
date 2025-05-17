using System;
using System.Collections.Generic;

namespace PROVERKA.Models;

public partial class Филиал
{
    public int? IdФилиала { get; set; }

    public string? Наименование { get; set; }

    public string? Адрес { get; set; }

    public string? Телефон { get; set; }

    public virtual ICollection<Договор> Договорs { get; set; } = new List<Договор>();
}
