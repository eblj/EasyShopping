using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.DTOs;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Queries
{
    public class FindProductByIdQuery: IRequest<Result<ProductViewModel>>
    {
        public Guid Id { get; set; }
        public FindProductByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
