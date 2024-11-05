using AutoMapper;
using EasyShopping.Cart.Application.Abstractions;
using EasyShopping.Cart.Application.DTOs;
using EasyShopping.Cart.Core.Repositories;
using MediatR;

namespace EasyShopping.Cart.Application.CQRS.Queries
{
    public class FindCartByUserIdHandler: IRequestHandler<FindCartByUserIdQuery, Result<CartViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FindCartByUserIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<CartViewModel>> Handle(FindCartByUserIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null || request.UserId.Equals(Guid.Empty))
                    return Result<CartViewModel>.Failure("The user id is required.");

                var cartHeader = await _unitOfWork.CartHeaderRepository.FindByUserIdAsync(request.UserId);
                if(cartHeader is null)
                    return Result<CartViewModel>.NotFound();

                var cartDetails = await _unitOfWork.CartDetailRepository.FindByCartHeaderIdAsync(cartHeader.Id);
                Core.Entities.Cart cart = new Core.Entities.Cart()
                {
                    CartHeader = cartHeader,
                    CartDetails = cartDetails
                };
                
                return Result<CartViewModel>.Success(_mapper.Map<CartViewModel>(cart));
                
            }
            catch (Exception ex)
            {
                return Result<CartViewModel>.Failure("The operation failed, more details: " + ex.Message);
            }
        }
    }
}
