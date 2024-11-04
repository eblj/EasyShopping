using EasyShopping.Product.Application.CQRS.Commands;
using FluentValidation;

namespace EasyShopping.Product.Application.Validators
{
    public class DeleteProductByIdValidator: AbstractValidator<DeleteProductByIdCommand>
    {
        public DeleteProductByIdValidator()
        {
            RuleFor(p => p.Id).NotNull().NotEqual(Guid.Empty).WithMessage("The id is required.");
        }
    }
}
