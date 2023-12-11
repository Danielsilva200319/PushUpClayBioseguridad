using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.Reflection;

namespace Persistence.Data;

public partial class BiosegurityContext : DbContext
{
/*     public BiosegurityContext()
    {
    } */

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
    public virtual DbSet<Rol> Rols { get; set; }
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
    public virtual DbSet<UserRol> UserRols { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=campus2024;database=bioseguridad", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
