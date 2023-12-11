using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PersonContactConfiguration : IEntityTypeConfiguration<Personcontact>
    {
        public void Configure(EntityTypeBuilder<Personcontact> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("personcontact");

            builder.HasIndex(e => e.Description, "personcontact_description_unique").IsUnique();

            builder.HasIndex(e => e.IdContactType, "personcontact_idcontacttype_foreign");

            builder.HasIndex(e => e.IdPerson, "personcontact_idperson_foreign");

            builder.HasOne(d => d.IdContactTypeNavigation).WithMany(p => p.Personcontacts)
                .HasForeignKey(d => d.IdContactType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personcontact_idcontacttype_foreign");

            builder.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Personcontacts)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personcontact_idperson_foreign");
        }
    }
}