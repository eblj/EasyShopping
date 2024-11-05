using EasyShopping.Cart.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EasyShopping.Cart.Infrastructure.Configuration
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.HasKey(ch => ch.Id);
            builder.HasOne(ch => ch.CartHeader).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(ch => ch.Product).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.Property(ch => ch.Count);
        }
    }
}

