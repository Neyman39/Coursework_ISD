using System;
using System.Collections.Generic;

namespace PROVERKA.Models;

public partial class User
{
    public string Id { get; set; }

    public string? Login { get; set; }

    public string? Passwd { get; set; }
}
