using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PersonAddressConfiguration : IEntityTypeConfiguration<Personaddress>
    {
        public void Configure(EntityTypeBuilder<Personaddress> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("personaddress");

            builder.HasIndex(e => e.IdAddressType, "personaddress_idaddresstype_foreign");

            builder.HasIndex(e => e.IdPerson, "personaddress_idperson_foreign");

            builder.Property(e => e.Address).HasMaxLength(255);

            builder.HasOne(d => d.IdAddressTypeNavigation).WithMany(p => p.Personaddresses)
                .HasForeignKey(d => d.IdAddressType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personaddress_idaddresstype_foreign");

            builder.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Personaddresses)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("personaddress_idperson_foreign");
        }
    }
}