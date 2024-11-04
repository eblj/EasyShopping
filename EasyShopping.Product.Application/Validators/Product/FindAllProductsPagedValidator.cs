using EasyShopping.Product.Application.CQRS.Queries;
using FluentValidation;

namespace EasyShopping.Product.Application.Validators
{
    public class FindAllProductsPagedValidator: AbstractValidator<FindAllProductsPagedQuery>
    {
        public FindAllProductsPagedValidator()
        {
            RuleFor(p => p.Filter).NotNull().NotEmpty().WithMessage("The filter is required.");
            RuleFor(p => p.Filter.CurrentPage).NotNull().GreaterThanOrEqualTo(0).WithMessage("The current page must be zero or a positive number.");
            RuleFor(p => p.Filter.RecordsByPage).NotNull().GreaterThanOrEqualTo(0).WithMessage("The records by page must be zero or a positive number.");
        }
    }
}
