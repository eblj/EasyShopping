using AutoMapper;
using EasyShopping.Product.Application.Configuration;
using EasyShopping.Product.Application.CQRS.Queries;
using EasyShopping.Product.Application.Validators;
using EasyShopping.Product.Core.Repositories;
using EasyShopping.Product.Infrastructure.Context;
using EasyShopping.Product.Infrastructure.Repositories;
using FluentValidation;
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

            //INFRASTRUCTURE
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //APPLICATION
            IMapper mapper = MappingConfiguration.RegisterMaps().CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddValidatorsFromAssemblyContaining<FindAllProductsPagedValidator>();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(FindProductByIdQuery)));
            return services;
        }
    }
}
