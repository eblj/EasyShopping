using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.DTOs;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Commands
{
    public class UpdateProductCommand: IRequest<Result<Guid>>
    {
        public ProductViewModel Product { get; set; }
        public UpdateProductCommand(ProductViewModel model)
        {
            this.Product = model;
        }
    }
}
