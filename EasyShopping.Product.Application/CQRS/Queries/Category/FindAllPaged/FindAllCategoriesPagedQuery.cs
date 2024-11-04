using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.DTOs;
using EasyShopping.Product.Application.DTOs.Filter;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Queries
{
    public class FindAllCategoriesPagedQuery: IRequest<Result<PagedResult<CategoryViewModel>>>
    {
        public FilterViewModel Filter { get; set; }
        public FindAllCategoriesPagedQuery(FilterViewModel filter)
        {
            this.Filter = filter;
        }
    }
}
