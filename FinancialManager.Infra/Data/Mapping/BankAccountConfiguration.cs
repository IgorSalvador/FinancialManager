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
    public class BankAccountConfiguration : IEntityTypeConfiguration<BankAccount>
    {
        public void Configure(EntityTypeBuilder<BankAccount> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.UserId)
                .IsRequired();

            builder.Property(x => x.BankId)
                .IsRequired();

            builder.Property(x => x.Balance)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            builder.Property(x => x.CreatedOn)
                .HasColumnType("datetime")
                .HasDefaultValue(DateTime.Now)
                .IsRequired();

            builder.Property(x => x.CreatedBy)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.HasOne(x => x.User)
                    .WithMany(x => x.BankAccounts)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Bank)
                    .WithMany(x => x.BankAccounts)
                    .HasForeignKey(x => x.BankId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.ToTable("BankAccounts");
        }
    }
}
