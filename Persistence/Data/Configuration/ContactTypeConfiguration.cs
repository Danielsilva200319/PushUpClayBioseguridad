using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContactTypeConfiguration : IEntityTypeConfiguration<Contacttype>
    {
        public void Configure(EntityTypeBuilder<Contacttype> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contacttype");

            builder.Property(e => e.Description).HasMaxLength(255);
        }
    }
}