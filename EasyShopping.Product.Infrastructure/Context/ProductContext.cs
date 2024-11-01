using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EasyShopping.Product.Infrastructure.Context
{
    public class ProductContext: DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        DbSet<Core.Entities.Product> Products { get; set; }
        DbSet<Core.Entities.Category> Categories { get; set; }
    }
}
