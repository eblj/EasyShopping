using AutoMapper;
using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.DTOs;
using EasyShopping.Product.Application.Validators;
using EasyShopping.Product.Core.Repositories;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Queries
{
    public class FindAllCategoriesPagedHandler: IRequestHandler<FindAllCategoriesPagedQuery, Result<PagedResult<CategoryViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FindAllCategoriesPagedHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<PagedResult<CategoryViewModel>>> Handle(FindAllCategoriesPagedQuery request, CancellationToken cancellationToken)
        {
            try
            {
                int totalRecords = 0;
                var findAllCategoriesPagedValidator = new FindAllCategoriesPagedValidator();
                var resultValidate = findAllCategoriesPagedValidator.Validate(request);
                if (resultValidate.IsValid)
                {
                    var categoriesPaged = _unitOfWork.Categories.FindAllPaged(out totalRecords, request.Filter.CurrentPage, request.Filter.RecordsByPage, request.Filter.SearchBy, request.Filter.Search, request.Filter.OrderBy, (int)request.Filter.Direction);
                    if (categoriesPaged is not null && categoriesPaged.Count > 0)
                    {
                        request.Filter.TotalRecords = totalRecords;
                        return Result<PagedResult<CategoryViewModel>>.Success(new PagedResult<CategoryViewModel>(_mapper.Map<List<CategoryViewModel>>(categoriesPaged), request.Filter));
                    }
                    return Result<PagedResult<CategoryViewModel>>.NotFound();
                }
                else
                {
                    var erros = string.Join(", ", resultValidate.Errors.Select(e => e.ErrorMessage));
                    return Result<PagedResult<CategoryViewModel>>.Failure(erros);
                }
            }
            catch (Exception ex)
            {
                return Result<PagedResult<CategoryViewModel>>.Failure("The operation failed, more details: " + ex.Message);
            }
        }
    }
}
