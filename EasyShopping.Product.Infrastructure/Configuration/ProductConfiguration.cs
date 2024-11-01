using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyShopping.Product.Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Core.Entities.Product>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Price).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
            builder.Property(p => p.ImageUrl).HasMaxLength(500);
            builder.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
