using EasyShopping.Cart.Application.Abstractions;
using EasyShopping.Cart.Application.DTOs;
using MediatR;

namespace EasyShopping.Cart.Application.CQRS.Queries
{
    public class FindCartByUserIdQuery: IRequest<Result<CartViewModel>>
    {
        public Guid UserId { get; set; }
        public FindCartByUserIdQuery(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
