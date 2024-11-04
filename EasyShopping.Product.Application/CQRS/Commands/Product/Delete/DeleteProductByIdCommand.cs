using EasyShopping.Product.Application.Abstractions;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Commands
{
    public class DeleteProductByIdCommand: IRequest<Result<int>>
    {
        public Guid Id { get; set; }
        public DeleteProductByIdCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
