using EasyShopping.Product.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShopping.Product.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("ProductConnection"), new MySqlServerVersion(new Version(8,0,30)));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            return services;
        }
    }
}
