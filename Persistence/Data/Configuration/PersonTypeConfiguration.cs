using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PersonTypeConfiguration : IEntityTypeConfiguration<Persontype>
    {
        public void Configure(EntityTypeBuilder<Persontype> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("persontype");

            builder.Property(e => e.Description).HasMaxLength(255);
        }
    }
}