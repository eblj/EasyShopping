using AutoMapper;
using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.DTOs;
using EasyShopping.Product.Core.Repositories;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Queries.Product
{
    public class FindProductByIdHandler : IRequestHandler<FindProductByIdQuery, Result<ProductViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FindProductByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<ProductViewModel>> Handle(FindProductByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null || request.Id.Equals(Guid.Empty))
                    return Result<ProductViewModel>.Failure("The id is required.");

                var product = await _unitOfWork.ProductRepository.FindByIdAsync(request.Id);
                if (product is not null)
                    return Result<ProductViewModel>.Success(_mapper.Map<ProductViewModel>(product));
                else
                    return Result<ProductViewModel>.NotFound();
            }
            catch (Exception ex)
            {
                return Result<ProductViewModel>.Failure("The operation failed, more details: " + ex.Message);
            }
        }
    }
}
