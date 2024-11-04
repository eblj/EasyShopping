using AutoMapper;
using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.DTOs;
using EasyShopping.Product.Application.Validators;
using EasyShopping.Product.Core.Repositories;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Queries.Product.FindAllPaged
{
    public class FindAllProductsPagedHandler : IRequestHandler<FindAllProductsPagedQuery, Result<PagedResult<ProductViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FindAllProductsPagedHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<PagedResult<ProductViewModel>>> Handle(FindAllProductsPagedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                int totalRecords = 0;
                var findAllProductsPagedValidator = new FindAllProductsPagedValidator();
                var resultValidate = findAllProductsPagedValidator.Validate(request);
                if (resultValidate.IsValid)
                {
                    var productsPaged = _unitOfWork.Products.FindAllPaged(out totalRecords, request.Filter.CurrentPage, request.Filter.RecordsByPage, request.Filter.SearchBy, request.Filter.Search, request.Filter.OrderBy, (int)request.Filter.Direction);
                    if(productsPaged is not null && productsPaged.Count > 0)
                    {
                        request.Filter.TotalRecords = totalRecords;
                        return Result<PagedResult<ProductViewModel>>.Success(new PagedResult<ProductViewModel>(_mapper.Map<List<ProductViewModel>>(productsPaged), request.Filter));
                    }
                    return Result<PagedResult<ProductViewModel>>.NotFound();
                }
                else
                {
                    var erros = string.Join(", ", resultValidate.Errors.Select(e => e.ErrorMessage));
                    return Result<PagedResult<ProductViewModel>>.Failure(erros);
                }
            }
            catch (Exception ex)
            {
                return Result<PagedResult<ProductViewModel>>.Failure("The operation failed, more details: " + ex.Message);
            }
        }
    }
}
