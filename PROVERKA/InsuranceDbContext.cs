using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkCore.Jet;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PROVERKA.Models;

namespace PROVERKA
{
    public class InsuranceDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        //public DbSet<Client> Clients { get; set; }
        public DbSet<ClientQueue> ClientsQueue { get; set; }
        //public DbSet<Agent> Agents { get; set; }
        //public DbSet<Branch> Branches { get; set; }
        //public DbSet<Agreement> Agreements { get; set; }
        //public DbSet<InsuranceType> InsuranceTypes { get; set; }
        //public DbSet<InsuranceTypeField> InsuranceTypeFields { get; set; }
        //public DbSet<Field> Fields { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseJet("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=cursach_ISD1.mdb;");
        }
    }

    //public class Client
    //{
    //    [Key]
    //    public int IdClient { get; set; }
    //    public string FullName { get; set; }
    //    public string Phone { get; set; }
    //    public int? IdAgent { get; set; }
    //    public string Login { get; set; }
    //    public string Password { get; set; }

    //    //[ForeignKey("IdAgent")]
    //    //public Agent Agent { get; set; }
    //    //public ICollection<Agreement> Agreements { get; set; }
    //}

    //public class ClientQueue
    //{
    //    [Key]
    //    public int id { get; set; }
    //    public int? id_agent { get; set; }
    //    public string FullName { get; set; }
    //    public string Phone { get; set; }
    //    public DateTime Date_ { get; set; }

    //    //[ForeignKey("IdAgent")]
    //    //public Agent Agent { get; set; }
    //}
}
