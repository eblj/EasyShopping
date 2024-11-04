using EasyShopping.Product.Application.Abstractions;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Commands
{
    public class DeleteCategoryByIdCommand: IRequest<Result<int>>
    {
        public Guid Id { get; set; }
        public DeleteCategoryByIdCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
