using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PROVERKA.Models;

public partial class INDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public INDbContext()
    {
    }

    public INDbContext(DbContextOptions<INDbContext> options)
        : base(options)
    {
    }

    //public virtual DbSet<Agent> Agents { get; set; }

    //public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<ClientQueue> ClientsQueues { get; set; }

    //public virtual DbSet<InsuranceType> InsuranceTypes { get; set; }

    //public virtual DbSet<Договор> Договорs { get; set; }

    //public virtual DbSet<ЗаказНаЗвонок> ЗаказНаЗвонокs { get; set; }

    //public virtual DbSet<ПолеВидаСтрахования> ПолеВидаСтрахованияs { get; set; }

    //public virtual DbSet<ПринятыеЗвонки> ПринятыеЗвонкиs { get; set; }

    //public virtual DbSet<Филиал> Филиалs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseJet("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=cursach_ISD1.mdb;");
    }
    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseJet("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=bin\\Debug\\net8.0-windows\\cursach_ISD1.mdb");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Agent>(entity =>
        //{
        //    entity.HasKey(e => e.IdAgent).HasName("PrimaryKey");

        //    entity.ToTable("agents");

        //    entity.Property(e => e.IdAgent)
        //        .HasColumnType("counter")
        //        .HasColumnName("id_agent");
        //    entity.Property(e => e.Adress)
        //        .HasMaxLength(255)
        //        .HasColumnName("adress");
        //    entity.Property(e => e.Experience)
        //        .HasDefaultValue(0)
        //        .HasColumnName("experience");
        //    entity.Property(e => e.FullName).HasMaxLength(255);
        //    entity.Property(e => e.IdBranch)
        //        .HasDefaultValue(0)
        //        .HasColumnName("id_branch");
        //    entity.Property(e => e.Login)
        //        .HasMaxLength(255)
        //        .HasColumnName("login");
        //    entity.Property(e => e.Passwd)
        //        .HasMaxLength(255)
        //        .HasColumnName("passwd");
        //    entity.Property(e => e.Phone)
        //        .HasMaxLength(255)
        //        .HasColumnName("phone");
        //    entity.Property(e => e.Salary)
        //        .HasDefaultValue(0m)
        //        .HasColumnType("currency")
        //        .HasColumnName("salary");
        //});

        //modelBuilder.Entity<Client>(entity =>
        //{
        //    entity.HasKey(e => e.IdClient).HasName("PrimaryKey");

        //    entity.ToTable("clients");

        //    entity.HasIndex(e => e.IdAgent, "Клиентыid_агента");

        //    entity.Property(e => e.IdClient)
        //        .HasColumnType("counter")
        //        .HasColumnName("id_клиента");
        //    entity.Property(e => e.IdAgent)
        //        .HasDefaultValue(0)
        //        .HasColumnName("id_агента");
        //    entity.Property(e => e.Login)
        //        .HasMaxLength(255)
        //        .HasColumnName("логин");
        //    entity.Property(e => e.Passwd)
        //        .HasMaxLength(255)
        //        .HasColumnName("пароль");
        //    entity.Property(e => e.Phone).HasMaxLength(255);
        //    entity.Property(e => e.FullName)
        //        .HasMaxLength(255)
        //        .HasColumnName("ФИО");

        //    entity.HasOne(d => d.IdАгентаNavigation).WithMany(p => p.Clients)
        //        .HasForeignKey(d => d.IdAgent)
        //        .OnDelete(DeleteBehavior.Cascade)
        //        .HasConstraintName("АгентыКлиенты");
        //});

        modelBuilder.Entity<ClientQueue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PrimaryKey");

            entity.ToTable("ClientsQueue");

            entity.Property(e => e.Id)
                .HasColumnType("counter")
                .HasColumnName("id");
            entity.Property(e => e.RegDate).HasColumnName("RegDate");
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.IdAgent)
                .HasDefaultValue(0)
                .HasColumnName("id_agent");
            entity.Property(e => e.Phone).HasMaxLength(255);

            //entity.HasOne(d => d.IdAgentNavigation).WithMany(p => p.ClientsQueues)
            //    .HasForeignKey(d => d.IdAgent)
            //    .HasConstraintName("agentsClientsQueue");
        });

        //modelBuilder.Entity<InsuranceType>(entity =>
        //{
        //    entity.HasKey(e => e.IdInsurance).HasName("PrimaryKey");

        //    entity.ToTable("insurance_types");

        //    entity.Property(e => e.IdInsurance)
        //        .HasColumnType("counter")
        //        .HasColumnName("id_insurance");
        //    entity.Property(e => e.Name)
        //        .HasMaxLength(255)
        //        .HasColumnName("name");
        //    entity.Property(e => e.TariffRate)
        //        .HasDefaultValue(0)
        //        .HasColumnName("tariff_rate");
        //});

        //modelBuilder.Entity<Договор>(entity =>
        //{
        //    entity.HasKey(e => e.IdДоговора).HasName("PrimaryKey");

        //    entity.ToTable("Договор");

        //    entity.HasIndex(e => e.IdАгента, "Договорid_агента");

        //    entity.HasIndex(e => e.IdКлиента, "Договорid_клиента");

        //    entity.HasIndex(e => e.IdСтрахования, "Договорid_страхования");

        //    entity.HasIndex(e => e.IdФилиала, "Договорid_филиала");

        //    entity.Property(e => e.IdДоговора)
        //        .HasColumnType("counter")
        //        .HasColumnName("id_договора");
        //    entity.Property(e => e.IdАгента)
        //        .HasDefaultValue(0)
        //        .HasColumnName("id_агента");
        //    entity.Property(e => e.IdКлиента)
        //        .HasDefaultValue(0)
        //        .HasColumnName("id_клиента");
        //    entity.Property(e => e.IdСтрахования)
        //        .HasDefaultValue(0)
        //        .HasColumnName("id_страхования");
        //    entity.Property(e => e.IdФилиала)
        //        .HasDefaultValue(0)
        //        .HasColumnName("id_филиала");
        //    entity.Property(e => e.Дата)
        //        .HasMaxLength(255)
        //        .HasColumnName("дата");
        //    entity.Property(e => e.СтраховаяСумма)
        //        .HasDefaultValue(0m)
        //        .HasColumnType("currency")
        //        .HasColumnName("страховая_сумма");

        //    entity.HasOne(d => d.IdАгентаNavigation).WithMany(p => p.Договорs)
        //        .HasForeignKey(d => d.IdАгента)
        //        .HasConstraintName("АгентыДоговор");

        //    entity.HasOne(d => d.IdКлиентаNavigation).WithMany(p => p.Договорs)
        //        .HasForeignKey(d => d.IdКлиента)
        //        .HasConstraintName("КлиентыДоговор");

        //    entity.HasOne(d => d.IdСтрахованияNavigation).WithMany(p => p.Договорs)
        //        .HasForeignKey(d => d.IdСтрахования)
        //        .HasConstraintName("Виды_страхованияДоговор");

        //    entity.HasOne(d => d.IdФилиалаNavigation).WithMany(p => p.Договорs)
        //        .HasForeignKey(d => d.IdФилиала)
        //        .HasConstraintName("ФилиалДоговор");
        //});

        //modelBuilder.Entity<ЗаказНаЗвонок>(entity =>
        //{
        //    entity.HasKey(e => e.IdЗвонка).HasName("PrimaryKey");

        //    entity.ToTable("Заказ_на_звонок");

        //    entity.Property(e => e.IdЗвонка)
        //        .HasColumnType("counter")
        //        .HasColumnName("id_звонка");
        //    entity.Property(e => e.Дата).HasColumnName("дата");
        //    entity.Property(e => e.Телефон)
        //        .HasMaxLength(255)
        //        .HasColumnName("телефон");
        //    entity.Property(e => e.Фио)
        //        .HasMaxLength(255)
        //        .HasColumnName("ФИО");
        //});

        //modelBuilder.Entity<Поле>(entity =>
        //{
        //    entity.HasKey(e => e.IdПоле).HasName("PrimaryKey");

        //    entity.ToTable("Поле");

        //    entity.Property(e => e.IdПоле)
        //        .HasColumnType("counter")
        //        .HasColumnName("id_поле");
        //    entity.Property(e => e.Название)
        //        .HasMaxLength(255)
        //        .HasColumnName("название");
        //    entity.Property(e => e.Тип)
        //        .HasMaxLength(255)
        //        .HasColumnName("тип");
        //});

        //modelBuilder.Entity<ПолеВидаСтрахования>(entity =>
        //{
        //    entity
        //        .HasNoKey()
        //        .ToTable("Поле_вида_страхования");

        //    entity.Property(e => e.IdПоле)
        //        .ValueGeneratedOnAdd()
        //        .HasColumnType("counter")
        //        .HasColumnName("id_поле");
        //    entity.Property(e => e.IdСтрахование)
        //        .HasDefaultValue(0)
        //        .HasColumnName("id_страхование");

        //    entity.HasOne(d => d.IdПолеNavigation).WithMany()
        //        .HasForeignKey(d => d.IdПоле)
        //        .HasConstraintName("ПолеПоле_вида_страхования");

        //    entity.HasOne(d => d.IdСтрахованиеNavigation).WithMany()
        //        .HasForeignKey(d => d.IdСтрахование)
        //        .HasConstraintName("Виды_страхованияПоле_вида_страхования");
        //});

        //modelBuilder.Entity<ПринятыеЗвонки>(entity =>
        //{
        //    entity.HasKey(e => e.IdЗвонка).HasName("PrimaryKey");

        //    entity.ToTable("Принятые_звонки");

        //    entity.Property(e => e.IdЗвонка)
        //        .ValueGeneratedOnAdd()
        //        .HasColumnType("counter")
        //        .HasColumnName("id_звонка");
        //    entity.Property(e => e.IdАгента)
        //        .HasDefaultValue(0)
        //        .HasColumnName("id_агента");
        //    entity.Property(e => e.Время).HasColumnName("время");
        //    entity.Property(e => e.Дата).HasColumnName("дата");

        //    entity.HasOne(d => d.IdЗвонкаNavigation).WithOne(p => p.ПринятыеЗвонки)
        //        .HasForeignKey<ПринятыеЗвонки>(d => d.IdЗвонка)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("Заказ_на_звонокПринятые_звонки");
        //});

        //modelBuilder.Entity<Филиал>(entity =>
        //{
        //    entity.HasKey(e => e.IdФилиала).HasName("PrimaryKey");

        //    entity.ToTable("Филиал");

        //    entity.Property(e => e.IdФилиала)
        //        .HasColumnType("counter")
        //        .HasColumnName("id_филиала");
        //    entity.Property(e => e.Адрес)
        //        .HasMaxLength(255)
        //        .HasColumnName("адрес");
        //    entity.Property(e => e.Наименование)
        //        .HasMaxLength(255)
        //        .HasColumnName("наименование");
        //    entity.Property(e => e.Телефон)
        //        .HasMaxLength(255)
        //        .HasColumnName("телефон");
        //});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
