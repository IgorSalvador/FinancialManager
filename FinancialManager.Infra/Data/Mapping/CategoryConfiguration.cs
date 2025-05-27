using FinancialManager.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace FinancialManager.Infra.Data.Mapping
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(200)
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

            builder.ToTable("Categories");
        }
    }
}
