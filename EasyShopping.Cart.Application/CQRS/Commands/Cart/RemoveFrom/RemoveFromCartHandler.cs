using AutoMapper;
using EasyShopping.Cart.Application.Abstractions;
using EasyShopping.Cart.Core.Repositories;
using MediatR;

namespace EasyShopping.Cart.Application.CQRS.Commands
{
    public class RemoveFromCartHandler: IRequestHandler<RemoveFromCartCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RemoveFromCartHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<bool>> Handle(RemoveFromCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null || request.CartDetailsId == Guid.Empty)
                    return Result<bool>.Failure("The cart details id is required.");

                var cartDetails = await _unitOfWork.CartDetailRepository.FindByIdAsync(request.CartDetailsId);
                if(cartDetails is null)
                    return Result<bool>.NotFound();

                var cartDetailsOfCartHeader = await _unitOfWork.CartDetailRepository.FindByCartHeaderIdAsync(cartDetails.CartHeaderId);
                int total = cartDetailsOfCartHeader.Count;

                await _unitOfWork.CartDetailRepository.DeleteByIdAsync(cartDetails.Id);
                if(total.Equals(1))
                    await _unitOfWork.CartHeaderRepository.DeleteByIdAsync(cartDetails.CartHeaderId);

                var commit = _unitOfWork.Complete();
                return commit > 0 ? Result<bool>.Success(true) : Result<bool>.Failure("Failed to remove item from cart.");
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure("The operation failed, more details: " + ex.Message);
            }
        }
    }
}
