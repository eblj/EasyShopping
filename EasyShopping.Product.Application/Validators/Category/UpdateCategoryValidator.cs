using EasyShopping.Product.Application.CQRS.Commands;
using FluentValidation;

namespace EasyShopping.Product.Application.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(p => p.Category).NotNull().NotEmpty().WithMessage("The product is required.");
            RuleFor(p => p.Category.Id).NotNull().NotEqual(Guid.Empty).WithMessage("The id is required.");
            RuleFor(p => p.Category.Name).NotNull().NotEmpty().WithMessage("The name is required.").
                Length(2, 100).WithMessage("The name must contain between 2 and 100 characters.");           
        }
    }
}
