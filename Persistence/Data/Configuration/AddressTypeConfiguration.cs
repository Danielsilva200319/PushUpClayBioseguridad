using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class AddressTypeConfiguration : IEntityTypeConfiguration<Addresstype>
    {
        public void Configure(EntityTypeBuilder<Addresstype> builder)
        {
            builder.ToTable("addresstype");
            
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.Property(e => e.Description).HasMaxLength(255);
        }
    }
}