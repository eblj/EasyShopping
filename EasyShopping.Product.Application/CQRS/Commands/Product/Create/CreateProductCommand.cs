using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.DTOs;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Commands
{
    public class CreateProductCommand: IRequest<Result<Guid>>
    {
        public ProductViewModel Product { get; set; }
        public CreateProductCommand(ProductViewModel model)
        {
            this.Product = model;
        }
    }
}
