using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class PersonCategoryConfiguration : IEntityTypeConfiguration<Personcategory>
    {
        public void Configure(EntityTypeBuilder<Personcategory> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("personcategory");

            builder.Property(e => e.NameCategory).HasMaxLength(255);
        }
    }
}