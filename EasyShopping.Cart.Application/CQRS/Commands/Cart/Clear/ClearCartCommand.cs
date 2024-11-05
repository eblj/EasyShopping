using EasyShopping.Cart.Application.Abstractions;
using MediatR;

namespace EasyShopping.Cart.Application.CQRS.Commands
{
    public class ClearCartCommand: IRequest<Result<bool>>
    {
        public Guid UserId { get; set; }
        public ClearCartCommand(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
