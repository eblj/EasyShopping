using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.DTOs;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Queries
{
    public class FindCategoryByIdQuery: IRequest<Result<CategoryViewModel>>
    {
        public Guid Id { get; set; }
        public FindCategoryByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
