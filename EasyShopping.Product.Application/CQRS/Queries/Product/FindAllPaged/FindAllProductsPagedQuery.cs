using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.DTOs;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Queries
{
    public class FindAllProductsPagedQuery: IRequest<Result<PagedResult<ProductViewModel>>>
    {
        public FilterViewModel Filter { get; set; }
        public FindAllProductsPagedQuery(FilterViewModel filter)
        {
            this.Filter = filter;
        }
    }
}
