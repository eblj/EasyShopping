using EasyShopping.Coupon.Application.CQRS.Commands;
using FluentValidation;

namespace EasyShopping.Coupon.Application.Validators.Coupon
{
    public class DeleteCouponByIdValidator: AbstractValidator<DeleteCouponByIdCommand>
    {
        public DeleteCouponByIdValidator()
        {
            RuleFor(c => c.Id).NotNull().NotEqual(Guid.Empty).WithMessage("The coupon id is required.");
        }
    }
}
