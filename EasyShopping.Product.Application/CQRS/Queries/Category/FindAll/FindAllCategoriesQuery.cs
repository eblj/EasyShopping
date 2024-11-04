using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.DTOs;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Queries
{
    public class FindAllCategoriesQuery: IRequest<Result<List<CategoryViewModel>>>
    {
        public FindAllCategoriesQuery()
        {
            
        }
    }
}
