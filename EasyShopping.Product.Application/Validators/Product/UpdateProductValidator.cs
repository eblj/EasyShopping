using EasyShopping.Product.Application.CQRS.Commands;
using FluentValidation;

namespace EasyShopping.Product.Application.Validators
{
    public class UpdateProductValidator: AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(p => p.Product).NotNull().NotEmpty().WithMessage("The product is required.");
            RuleFor(p => p.Product.Id).NotNull().NotEqual(Guid.Empty).WithMessage("The id is required.");
            RuleFor(p => p.Product.Name).NotNull().NotEmpty().WithMessage("The name is required.").
                Length(5, 150).WithMessage("The name must contain between 5 and 150 characters.");
            RuleFor(p => p.Product.Price).NotNull().GreaterThan(0).WithMessage("The value must be greater than zero.");
            RuleFor(p => p.Product.Description).NotNull().NotEmpty().WithMessage("The description is required.").
                Length(10, 500).WithMessage("The description must contain between 5 and 500 characters.");
            RuleFor(p => p.Product.CategoryId).NotNull().NotEqual(Guid.Empty).WithMessage("The category id is required.");
            RuleFor(p => p.Product.ImageUrl).NotNull().NotEmpty().WithMessage("The image url is required.");
        }
    }
}
