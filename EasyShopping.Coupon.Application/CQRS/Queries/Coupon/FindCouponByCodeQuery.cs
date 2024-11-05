using EasyShopping.Coupon.Application.Abstractions;
using EasyShopping.Coupon.Application.DTOs.Coupon;
using MediatR;

namespace EasyShopping.Coupon.Application.CQRS.Queries
{
    public class FindCouponByCodeQuery: IRequest<Result<CouponViewModel>>
    {
        public string Code { get; set; }
        public FindCouponByCodeQuery(string code)
        {
            this.Code = code;
        }
    }
}
