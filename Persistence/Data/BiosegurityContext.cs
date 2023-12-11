using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Persistence.Entities;

namespace Persistence.Data;

public partial class BiosegurityContext : DbContext
{
    public BiosegurityContext()
    {
    }

    public BiosegurityContext(DbContextOptions<BiosegurityContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Addresstype> Addresstypes { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Contacttype> Contacttypes { get; set; }

    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Personaddress> Personaddresses { get; set; }

    public virtual DbSet<Personcategory> Personcategories { get; set; }

    public virtual DbSet<Personcontact> Personcontacts { get; set; }

    public virtual DbSet<Persontype> Persontypes { get; set; }

    public virtual DbSet<Programming> Programmings { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<State> States { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=campus2024;database=bioseguridad", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Addresstype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("addresstype");

            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("city");

            entity.HasIndex(e => e.IdDepartment, "city_iddepartment_foreign");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.IdDepartment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("city_iddepartment_foreign");
        });

        modelBuilder.Entity<Contacttype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contacttype");

            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contract");

            entity.HasIndex(e => e.IdClient, "contract_idclient_foreign");

            entity.HasIndex(e => e.IdEmployee, "contract_idemployee_foreign");

            entity.HasIndex(e => e.IdState, "contract_idstate_foreign");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.ContractIdClientNavigations)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contract_idclient_foreign");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.ContractIdEmployeeNavigations)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contract_idemployee_foreign");

            entity.HasOne(d => d.IdStateNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdState)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contract_idstate_foreign");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("country");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("department");

            entity.HasIndex(e => e.IdCountry, "department_idcountry_foreign");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.IdCountryNavigation).WithMany(p => p.Departments)
                .HasForeignKey(d => d.IdCountry)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("department_idcountry_foreign");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("person");

            entity.HasIndex(e => e.IdCategory, "person_idcategory_foreign");

            entity.HasIndex(e => e.IdCity, "person_idcity_foreign");

            entity.HasIndex(e => e.IdPerson, "person_idperson_unique").IsUnique();

            entity.HasIndex(e => e.IdPersonType, "person_idpersontype_foreign");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("person_idcategory_foreign");

            entity.HasOne(d => d.IdCityNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdCity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("person_idcity_foreign");

            entity.HasOne(d => d.IdPersonTypeNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdPersonType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("person_idpersontype_foreign");
        });

        modelBuilder.Entity<Personaddress>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("personaddress");

            entity.HasIndex(e => e.IdAddressType, "personaddress_idaddresstype_foreign");

            entity.HasIndex(e => e.IdPerson, "personaddress_idperson_foreign");

            entity.Property(e => e.Address).HasMaxLength(255);

            entity.HasOne(d => d.IdAddressTypeNavigation).WithMany(p => p.Personaddresses)
                .HasForeignKey(d => d.IdAddressType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personaddress_idaddresstype_foreign");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Personaddresses)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personaddress_idperson_foreign");
        });

        modelBuilder.Entity<Personcategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("personcategory");

            entity.Property(e => e.NameCategory).HasMaxLength(255);
        });

        modelBuilder.Entity<Personcontact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("personcontact");

            entity.HasIndex(e => e.Description, "personcontact_description_unique").IsUnique();

            entity.HasIndex(e => e.IdContactType, "personcontact_idcontacttype_foreign");

            entity.HasIndex(e => e.IdPerson, "personcontact_idperson_foreign");

            entity.HasOne(d => d.IdContactTypeNavigation).WithMany(p => p.Personcontacts)
                .HasForeignKey(d => d.IdContactType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personcontact_idcontacttype_foreign");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Personcontacts)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personcontact_idperson_foreign");
        });

        modelBuilder.Entity<Persontype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("persontype");

            entity.Property(e => e.Description).HasMaxLength(255);
        });

        modelBuilder.Entity<Programming>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("programming");

            entity.HasIndex(e => e.IdContract, "programming_idcontract_foreign");

            entity.HasIndex(e => e.IdEmployee, "programming_idemployee_foreign");

            entity.HasIndex(e => e.IdShifts, "programming_idshifts_foreign");

            entity.HasOne(d => d.IdContractNavigation).WithMany(p => p.Programmings)
                .HasForeignKey(d => d.IdContract)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("programming_idcontract_foreign");

            entity.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Programmings)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("programming_idemployee_foreign");

            entity.HasOne(d => d.IdShiftsNavigation).WithMany(p => p.Programmings)
                .HasForeignKey(d => d.IdShifts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("programming_idshifts_foreign");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("shifts");

            entity.Property(e => e.ShiftName).HasMaxLength(50);
            entity.Property(e => e.TimeShiftEnd).HasColumnType("time");
            entity.Property(e => e.TimeShiftStart).HasColumnType("time");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("state");

            entity.Property(e => e.Description).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
