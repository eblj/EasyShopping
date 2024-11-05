using AutoMapper;
using EasyShopping.Coupon.Application.DTOs.Coupon;

namespace EasyShopping.Coupon.Application.Configuration
{
    public class MappingConfiguration
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfiguration = new MapperConfiguration(config =>
            {
                config.CreateMap<CouponViewModel, Core.Entities.Coupon>().ReverseMap();
            });
            return mappingConfiguration;
        }
    }
}
