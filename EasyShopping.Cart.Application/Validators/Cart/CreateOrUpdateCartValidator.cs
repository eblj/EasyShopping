using EasyShopping.Cart.Application.CQRS.Commands;
using FluentValidation;

namespace EasyShopping.Cart.Application.Validators.Cart
{
    public class CreateOrUpdateCartValidator: AbstractValidator<CreateOrUpdateCartCommand>
    {
        public CreateOrUpdateCartValidator()
        {
            RuleFor(c => c.Cart).NotNull().NotEmpty().WithMessage("The cart is required.");
            RuleFor(c => c.Cart.CartHeader).NotNull().NotEmpty().WithMessage("The header of cart is required.");
            RuleFor(c => c.Cart.CartDetails).NotNull().NotEmpty().WithMessage("The details of cart are is required.");
            RuleFor(c => c.Cart.CartHeader.UserId).NotNull().NotEqual(Guid.Empty).WithMessage("Cart header UserId is required.");
            RuleForEach(c => c.Cart.CartDetails).ChildRules(cd =>
            {
                cd.RuleFor(d => d.ProductId).NotNull().NotEqual(Guid.Empty).WithMessage("The product id is required.");
                cd.RuleFor(d => d.Count).NotNull().GreaterThan(0).WithMessage("The count is required.");
            });
        }
    }
}
