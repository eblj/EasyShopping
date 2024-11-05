using AutoMapper;
using EasyShopping.Cart.Application.DTOs;
using EasyShopping.Cart.Core.Entities;

namespace EasyShopping.Cart.Application.Configuration
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductViewModel, Product>().ReverseMap();
                    //.ForMember(dest => dest.Category, opt => opt.Ignore())
                    //.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId));
                config.CreateMap<Product, ProductViewModel>();

                config.CreateMap<CategoryViewModel, Category>().ReverseMap();
                config.CreateMap<CartHeaderViewModel, CartHeader>().ReverseMap();
                config.CreateMap<CartDetailViewModel, CartDetail>().ReverseMap();
                config.CreateMap<CartViewModel, Core.Entities.Cart>().ReverseMap();


            });
            return mappingConfiguration;
        }
    }
}
