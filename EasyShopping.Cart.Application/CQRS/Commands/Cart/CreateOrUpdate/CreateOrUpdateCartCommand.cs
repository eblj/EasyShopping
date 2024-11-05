using EasyShopping.Cart.Application.Abstractions;
using EasyShopping.Cart.Application.DTOs;
using MediatR;

namespace EasyShopping.Cart.Application.CQRS.Commands
{
    public class CreateOrUpdateCartCommand: IRequest<Result<Guid>>
    {
        public CartViewModel Cart { get; set; }

        public CreateOrUpdateCartCommand(CartViewModel model)
        {
            this.Cart = model;
        }
    }
}
