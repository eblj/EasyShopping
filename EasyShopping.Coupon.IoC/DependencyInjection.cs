using AutoMapper;
using EasyShopping.Coupon.Application.Configuration;
using EasyShopping.Coupon.Application.CQRS.Queries;
using EasyShopping.Coupon.Core.Repositories;
using EasyShopping.Coupon.Infrastructure.Context;
using EasyShopping.Coupon.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShopping.Coupon.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CouponContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("CartConnection"), new MySqlServerVersion(new Version(8, 0, 30)));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            //INFRASTRUCTURE
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //APPLICATION
            IMapper mapper = MappingConfiguration.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(FindCouponByCodeQuery)));
            return services;
        }
    }
}
