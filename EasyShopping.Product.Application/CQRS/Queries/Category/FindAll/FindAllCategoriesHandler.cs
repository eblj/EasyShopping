using AutoMapper;
using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.DTOs;
using EasyShopping.Product.Core.Repositories;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Queries
{
    public class FindAllCategoriesHandler : IRequestHandler<FindAllCategoriesQuery, Result<List<CategoryViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FindAllCategoriesHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<List<CategoryViewModel>>> Handle(FindAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categories = await _unitOfWork.Categories.FindAllAsync();
                if (categories is not null)
                    return Result<List<CategoryViewModel>>.Success(_mapper.Map<List<CategoryViewModel>>(categories));
                else
                    return Result<List<CategoryViewModel>>.NotFound();

            }
            catch (Exception ex)
            {
                return Result<List<CategoryViewModel>>.Failure("The operation failed, more details: " + ex.Message);
            }
        }
    }
}
