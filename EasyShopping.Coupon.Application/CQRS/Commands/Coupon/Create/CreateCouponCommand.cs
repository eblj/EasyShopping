using EasyShopping.Coupon.Application.Abstractions;
using EasyShopping.Coupon.Application.DTOs.Coupon;
using MediatR;

namespace EasyShopping.Coupon.Application.CQRS.Commands
{
    public class CreateCouponCommand: IRequest<Result<Guid>>
    {
        public CouponViewModel Coupon { get; set; }
        public CreateCouponCommand(CouponViewModel model)
        {
            this.Coupon = model;
        }
    }
}
