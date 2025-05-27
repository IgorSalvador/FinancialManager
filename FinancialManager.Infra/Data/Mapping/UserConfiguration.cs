using FinancialManager.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FinancialManager.Infra.Data.Mapping
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasColumnType("varchar")
                .HasMaxLength(400)
                .IsRequired();

            builder.Property(x => x.Profile)
                .HasColumnType("int")
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

            builder.ToTable("Users");
        }
    }
}
