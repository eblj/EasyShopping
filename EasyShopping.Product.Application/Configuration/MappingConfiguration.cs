using AutoMapper;
using EasyShopping.Product.Application.DTOs;

namespace EasyShopping.Product.Application.Configuration
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductViewModel, Core.Entities.Product>()
                    .ForMember(dest => dest.Category, opt => opt.Ignore())
                    .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
                config.CreateMap<Core.Entities.Product, ProductViewModel>();

                config.CreateMap<CategoryViewModel, Core.Entities.Category>();
                config.CreateMap<Core.Entities.Category, CategoryViewModel>();
            }); 
            return mappingConfiguration;
        }
    }
}
