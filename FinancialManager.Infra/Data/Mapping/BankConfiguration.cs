using FinancialManager.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManager.Infra.Data.Mapping
{
    public class BankConfiguration : IEntityTypeConfiguration<Bank>
    {
        public void Configure(EntityTypeBuilder<Bank> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Agency)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(x => x.Code)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.CreatedOn)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(x => x.CreatedBy)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.ToTable("Banks");
        }
    }
}
