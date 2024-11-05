using EasyShopping.Coupon.Application.CQRS.Commands;
using FluentValidation;

namespace EasyShopping.Coupon.Application.Validators.Coupon
{
    public class CreateCouponValidator: AbstractValidator<CreateCouponCommand>
    {
        public CreateCouponValidator()
        {
            RuleFor(c => c.Coupon).NotNull().NotEmpty().WithMessage("The coupon is required.");
            RuleFor(c => c.Coupon.Code).NotNull().NotEmpty().WithMessage("The code is required.")
                .Length(1, 50).WithMessage("The code must contain between 1 and 50 characters.");
            RuleFor(c => c.Coupon.Validate).NotNull().GreaterThan(DateTime.Now).WithMessage("The expiration date must be in the future.");
        }
    }
}
