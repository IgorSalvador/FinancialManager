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
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.CategoryId)
                .IsRequired();

            builder.Property(x => x.BankAccountId)
                .IsRequired();

            builder.Property(x => x.TransactionType)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.PaymentType)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(x => x.Value)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.TransactionDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.CreateOn)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(x => x.CreatedBy)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
