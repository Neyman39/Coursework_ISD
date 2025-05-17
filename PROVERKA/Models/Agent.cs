using System;
using System.Collections.Generic;

namespace PROVERKA.Models;

public partial class Agent
{
    public int? IdAgent { get; set; }

    public string? FullName { get; set; }

    public string? Adress { get; set; }

    public string? Phone { get; set; }

    public int? IdBranch { get; set; }

    public decimal? Salary { get; set; }

    public int? Experience { get; set; }

    public string? Login { get; set; }

    public string? Passwd { get; set; }

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();

    public virtual ICollection<ClientQueue> ClientsQueues { get; set; } = new List<ClientQueue>();

    public virtual ICollection<Договор> Договорs { get; set; } = new List<Договор>();
}
