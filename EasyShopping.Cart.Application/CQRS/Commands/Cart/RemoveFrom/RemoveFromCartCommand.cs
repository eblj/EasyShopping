using EasyShopping.Cart.Application.Abstractions;
using MediatR;

namespace EasyShopping.Cart.Application.CQRS.Commands
{
    public class RemoveFromCartCommand: IRequest<Result<bool>>
    {
        public Guid CartDetailsId { get; set; }
        public RemoveFromCartCommand(Guid cartDetailsId)
        {
            this.CartDetailsId = cartDetailsId;
        }
    }
}
