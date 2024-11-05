using AutoMapper;
using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.DTOs;
using EasyShopping.Product.Core.Repositories;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Queries
{
    public class FindAllProductsHandler : IRequestHandler<FindAllProductsQuery, Result<List<ProductViewModel>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FindAllProductsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<List<ProductViewModel>>> Handle(FindAllProductsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _unitOfWork.ProductRepository.FindAllAsync();
                if(products is not null)
                    return Result<List<ProductViewModel>>.Success(_mapper.Map<List<ProductViewModel>>(products));
                else
                    return Result<List<ProductViewModel>>.NotFound();

            }
            catch (Exception ex)
            {
                return Result<List<ProductViewModel>>.Failure("The operation failed, more details: " + ex.Message);
            }
        }
    }
}
