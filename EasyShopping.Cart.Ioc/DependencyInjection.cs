using AutoMapper;
using EasyShopping.Cart.Application.Configuration;
using EasyShopping.Cart.Application.CQRS.Commands;
using EasyShopping.Cart.Application.Validators.Cart;
using EasyShopping.Cart.Core.Repositories;
using EasyShopping.Cart.Infrastructure.Context;
using EasyShopping.Cart.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EasyShopping.Cart.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CartContext>(options =>
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
            services.AddValidatorsFromAssemblyContaining<CreateOrUpdateCartValidator>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateOrUpdateCartCommand)));
            return services;
        }
    }
}
