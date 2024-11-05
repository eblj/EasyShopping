using AutoMapper;
using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.DTOs;
using EasyShopping.Product.Core.Repositories;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Queries
{
    public class FindCategoryByIdHandler: IRequestHandler<FindCategoryByIdQuery, Result<CategoryViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FindCategoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<CategoryViewModel>> Handle(FindCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null || request.Id.Equals(Guid.Empty))
                    return Result<CategoryViewModel>.Failure("The id is required.");

                var category = await _unitOfWork.CategoryRepository.FindByIdAsync(request.Id);
                if (category is not null)
                    return Result<CategoryViewModel>.Success(_mapper.Map<CategoryViewModel>(category));
                else
                    return Result<CategoryViewModel>.NotFound();
            }
            catch (Exception ex)
            {
                return Result<CategoryViewModel>.Failure("The operation failed, more details: " + ex.Message);
            }
        }
    }
}
