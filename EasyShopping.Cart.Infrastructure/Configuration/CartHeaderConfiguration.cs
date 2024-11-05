using EasyShopping.Cart.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyShopping.Cart.Infrastructure.Configuration
{
    public class CartHeaderConfiguration : IEntityTypeConfiguration<CartHeader>
    {
        public void Configure(EntityTypeBuilder<CartHeader> builder)
        {
            builder.HasKey(ch => ch.Id);
            builder.Property(ch => ch.UserId).IsRequired();
            builder.Property(ch => ch.CouponCode).HasMaxLength(30);
        }
    }
}
