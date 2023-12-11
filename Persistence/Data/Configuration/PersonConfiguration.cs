using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("person");

            builder.HasIndex(e => e.IdCategory, "person_idcategory_foreign");

            builder.HasIndex(e => e.IdCity, "person_idcity_foreign");

            builder.HasIndex(e => e.IdPerson, "person_idperson_unique").IsUnique();

            builder.HasIndex(e => e.IdPersonType, "person_idpersontype_foreign");

            builder.Property(e => e.Name).HasMaxLength(50);

            builder.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdCategory)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("person_idcategory_foreign");

            builder.HasOne(d => d.IdCityNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdCity)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("person_idcity_foreign");

            builder.HasOne(d => d.IdPersonTypeNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.IdPersonType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("person_idpersontype_foreign");
        }
    }
}