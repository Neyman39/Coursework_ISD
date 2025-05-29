using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PROVERKA.Models;

public partial class INDbContext : DbContext
{
    public INDbContext()
    {
    }

    public INDbContext(DbContextOptions<INDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Agent> Agents { get; set; }

    public virtual DbSet<Agreement> Agreements { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientQueue> ClientsQueues { get; set; }

    public virtual DbSet<Field> Fields { get; set; }

    public virtual DbSet<InsuranceType> InsuranceTypes { get; set; }

    public virtual DbSet<InsuranceTypeField> InsuranceTypeFields { get; set; }

    public virtual DbSet<OrderByCall> OrderByCalls { get; set; }

    public virtual DbSet<ReceivedCall> ReceivedCalls { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseJet("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=cursach_ISD1.mdb");


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Agent>(entity =>
        {
            entity.HasKey(e => e.IdAgent).HasName("PrimaryKey");

            entity.ToTable("agents");

            entity.Property(e => e.IdAgent)
                .HasColumnType("counter")
                .HasColumnName("id_agent");
            entity.Property(e => e.Adress)
                .HasMaxLength(255)
                .HasColumnName("adress");
            entity.Property(e => e.Experience)
                .HasDefaultValue(0)
                .HasColumnName("experience");
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.IdBranch)
                .HasDefaultValue(0)
                .HasColumnName("id_branch");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Passwd)
                .HasMaxLength(255)
                .HasColumnName("passwd");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.Salary)
                .HasDefaultValue(0m)
                .HasColumnType("currency")
                .HasColumnName("salary");
        });

        modelBuilder.Entity<Agreement>(entity =>
        {
            entity.HasKey(e => e.IdAgreement).HasName("PrimaryKey");

            entity.ToTable("agreements");

            //entity.HasIndex(e => e.IdAgent, "Договорid_агента");

            //entity.HasIndex(e => e.IdClient, "Договорid_клиента");

            //entity.HasIndex(e => e.IdInsurance, "Договорid_страхования");

            //entity.HasIndex(e => e.IdBranch, "Договорid_филиала");

            entity.Property(e => e.IdAgreement)
                .HasColumnType("counter")
                .HasColumnName("id_agreement");
            entity.Property(e => e.IdAgent)
                .HasDefaultValue(0)
                .HasColumnName("id_agent");
            entity.Property(e => e.IdBranch)
                .HasDefaultValue(0)
                .HasColumnName("id_branch");
            entity.Property(e => e.IdClient)
                .HasDefaultValue(0)
                .HasColumnName("id_client");
            entity.Property(e => e.IdInsurance)
                .HasDefaultValue(0)
                .HasColumnName("id_insurance");
            entity.Property(e => e.RegDate).HasMaxLength(255);
            entity.Property(e => e.SumInsured)
                .HasDefaultValue(0m)
                .HasColumnType("currency")
                .HasColumnName("sum_insured");
            entity.Property(e => e.AgentPremium)
                .HasDefaultValue(0m)
                .HasColumnType("currency")
                .HasColumnName("agent_premium");

            //entity.HasOne(d => d.IdAgentNavigation).WithMany(p => p.Agreements)
            //    .HasForeignKey(d => d.IdAgent)
            //    .HasConstraintName("АгентыДоговор");

            //entity.HasOne(d => d.IdBranchNavigation).WithMany(p => p.Agreements)
            //    .HasForeignKey(d => d.IdBranch)
            //    .HasConstraintName("ФилиалДоговор");

            ////entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Agreements)
            ////    .HasForeignKey(d => d.IdClient)
            ////    .HasConstraintName("КлиентыДоговор");

            //entity.HasOne(d => d.IdInsuranceNavigation).WithMany(p => p.Agreements)
            //    .HasForeignKey(d => d.IdInsurance)
            //    .HasConstraintName("Виды_страхованияДоговор");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.IdBranch).HasName("PrimaryKey");

            entity.ToTable("branch");

            entity.Property(e => e.IdBranch)
                .HasColumnType("counter")
                .HasColumnName("id_branch");
            entity.Property(e => e.Adress).HasMaxLength(255);
            entity.Property(e => e.Nomination)
                .HasMaxLength(255)
                .HasColumnName("nomination");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PrimaryKey");

            entity.ToTable("clients");

            //entity.HasIndex(e => e.IdAgent, "Клиентыid_агента");

            entity.Property(e => e.IdClient)
                .HasColumnType("counter")
                .HasColumnName("id_client");
            entity.Property(e => e.FullName)
                .HasMaxLength(255);
            entity.Property(e => e.IdAgent)
                .HasDefaultValue(0)
                .HasColumnName("id_agent");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Passwd)
                .HasMaxLength(255)
                .HasColumnName("passwd");
            entity.Property(e => e.Phone)
                .HasMaxLength(255);

            //entity.HasOne(d => d.IdAgentNavigation).WithMany(p => p.Clients)
            //    .HasForeignKey(d => d.IdAgent)
            //    .OnDelete(DeleteBehavior.Cascade)
            //    .HasConstraintName("АгентыКлиенты");
        });

        modelBuilder.Entity<ClientQueue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PrimaryKey");

            entity.ToTable("ClientsQueue");

            entity.Property(e => e.Id)
                .HasColumnType("counter")
                .HasColumnName("id");
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.IdAgent)
                .HasDefaultValue(0)
                .HasColumnName("id_agent");
            entity.Property(e => e.Phone).HasMaxLength(255);

            //entity.HasOne(d => d.IdAgentNavigation).WithMany(p => p.ClientsQueues)
            //    .HasForeignKey(d => d.IdAgent)
            //    .HasConstraintName("agentsClientsQueue");
        });

        modelBuilder.Entity<Field>(entity =>
        {
            entity.HasKey(e => e.IdField).HasName("PrimaryKey");

            entity.ToTable("field");

            entity.Property(e => e.IdField)
                .HasColumnType("counter")
                .HasColumnName("id_field");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Type)
                .HasMaxLength(255)
                .HasColumnName("type");
        });

        modelBuilder.Entity<InsuranceType>(entity =>
        {
            entity.HasKey(e => e.IdInsurance).HasName("PrimaryKey");

            entity.ToTable("insurance_types");

            entity.Property(e => e.IdInsurance)
                .HasColumnType("counter")
                .HasColumnName("id_insurance");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.TariffRate)
                .HasDefaultValue(0)
                .HasColumnName("tariff_rate");
        });

        modelBuilder.Entity<InsuranceTypeField>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("insurance_type_field");

            entity.Property(e => e.IdField)
                .ValueGeneratedOnAdd()
                .HasColumnType("counter")
                .HasColumnName("id_field");
            entity.Property(e => e.IdInsurance)
                .HasDefaultValue(0)
                .HasColumnName("id_insurance");

            entity.HasOne(d => d.IdFieldNavigation).WithMany()
                .HasForeignKey(d => d.IdField)
                .HasConstraintName("ПолеПоле_вида_страхования");

            entity.HasOne(d => d.IdInsuranceNavigation).WithMany()
                .HasForeignKey(d => d.IdInsurance)
                .HasConstraintName("Виды_страхованияПоле_вида_страхования");
        });

        modelBuilder.Entity<OrderByCall>(entity =>
        {
            entity.HasKey(e => e.IdCall).HasName("PrimaryKey");

            entity.ToTable("order_by_call");

            entity.Property(e => e.IdCall)
                .HasColumnType("counter")
                .HasColumnName("id_call");
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<ReceivedCall>(entity =>
        {
            entity.HasKey(e => e.IdCall).HasName("PrimaryKey");

            entity.ToTable("received_calls");

            entity.Property(e => e.IdCall)
                .ValueGeneratedOnAdd()
                .HasColumnType("counter")
                .HasColumnName("id_call");
            entity.Property(e => e.IdAgent)
                .HasDefaultValue(0)
                .HasColumnName("id_agent");
            entity.Property(e => e.RegTime).HasColumnName("Reg_Time");

            entity.HasOne(d => d.IdCallNavigation).WithOne(p => p.ReceivedCall)
                .HasForeignKey<ReceivedCall>(d => d.IdCall)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Заказ_на_звонокПринятые_звонки");
        });

        modelBuilder.Entity<User>(entity =>
        {
            //entity.HasKey(e => e.Id).HasName("PrimaryKey");

            entity.ToTable("users");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .HasColumnName("login");
            entity.Property(e => e.Passwd)
                .HasMaxLength(255)
                .HasColumnName("passwd");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
