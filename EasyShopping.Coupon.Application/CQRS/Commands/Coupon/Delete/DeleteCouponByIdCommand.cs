using EasyShopping.Coupon.Application.Abstractions;
using MediatR;

namespace EasyShopping.Coupon.Application.CQRS.Commands
{
    public class DeleteCouponByIdCommand: IRequest<Result<int>>
    {
        public Guid Id { get; set; }
        public DeleteCouponByIdCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
