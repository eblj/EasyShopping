using EasyShopping.Cart.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EasyShopping.Cart.Infrastructure.Context
{
    public class CartContext: DbContext
    {
        public CartContext(DbContextOptions<CartContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CartHeader> CartHeaders { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
    }
}
