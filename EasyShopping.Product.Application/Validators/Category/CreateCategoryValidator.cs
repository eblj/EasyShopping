using EasyShopping.Product.Application.CQRS.Commands;
using FluentValidation;

namespace EasyShopping.Product.Application.Validators
{
    public class CreateCategoryValidator: AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(p => p.Category).NotNull().NotEmpty().WithMessage("The category is required.");
            RuleFor(p => p.Category.Name).NotNull().NotEmpty().WithMessage("The name is required.").
             Length(5, 150).WithMessage("The name must contain between 2 and 100 characters.");
        }
    }
}
