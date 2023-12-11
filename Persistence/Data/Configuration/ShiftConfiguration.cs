using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("shifts");

            builder.Property(e => e.ShiftName).HasMaxLength(50);
            builder.Property(e => e.TimeShiftEnd).HasColumnType("time");
            builder.Property(e => e.TimeShiftStart).HasColumnType("time");
        }
    }
}