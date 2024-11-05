using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyShopping.Coupon.Infrastructure.Configuration
{
    public class CouponConfiguration : IEntityTypeConfiguration<Core.Entities.Coupon>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Coupon> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Code).HasMaxLength(50).IsRequired();
            builder.Property(c => c.DiscountAmount).IsRequired();
        }
    }
}
