using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.DTOs;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Commands
{
    public class CreateCategoryCommand: IRequest<Result<Guid>>
    {
        public CategoryViewModel Category { get; set; }
        public CreateCategoryCommand(CategoryViewModel model)
        {
            this.Category = model;
        }
    }
}
