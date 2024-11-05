using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace EasyShopping.Coupon.Infrastructure.Context
{
    public class CouponContext: DbContext
    {
        public CouponContext(DbContextOptions<CouponContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Core.Entities.Coupon> Coupons { get; set; }
    }
}
