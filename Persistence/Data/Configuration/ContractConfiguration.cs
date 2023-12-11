using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("contract");

            builder.HasIndex(e => e.IdClient, "contract_idclient_foreign");

            builder.HasIndex(e => e.IdEmployee, "contract_idemployee_foreign");

            builder.HasIndex(e => e.IdState, "contract_idstate_foreign");

            builder.HasOne(d => d.IdClientNavigation).WithMany(p => p.ContractIdClientNavigations)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contract_idclient_foreign");

            builder.HasOne(d => d.IdEmployeeNavigation).WithMany(p => p.ContractIdEmployeeNavigations)
                .HasForeignKey(d => d.IdEmployee)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contract_idemployee_foreign");

            builder.HasOne(d => d.IdStateNavigation).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.IdState)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("contract_idstate_foreign");
        }
    }
}