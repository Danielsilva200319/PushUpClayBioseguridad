using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ProgrammingConfiguration : IEntityTypeConfiguration<Programming>
    {
        public void Configure(EntityTypeBuilder<Programming> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("programming");

            builder.HasIndex(e => e.IdContract, "programming_idcontract_foreign");

            builder.HasIndex(e => e.IdEmployee, "programming_idemployee_foreign");

            builder.HasIndex(e => e.IdShifts, "programming_idshifts_foreign");

            builder.HasOne(d => d.IdContractNavigation).WithMany(p => p.Programmings)
                .HasForeignKey(d => d.IdContract)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("programming_idcontract_foreign");

            builder.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.Programmings)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("programming_idemployee_foreign");

            builder.HasOne(d => d.IdShiftsNavigation).WithMany(p => p.Programmings)
                .HasForeignKey(d => d.IdShifts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("programming_idshifts_foreign");
        }
    }
}