using AutoMapper;
using EasyShopping.Cart.Application.Abstractions;
using EasyShopping.Cart.Core.Repositories;
using MediatR;

namespace EasyShopping.Cart.Application.CQRS.Commands
{
    public class ClearCartHandler: IRequestHandler<ClearCartCommand, Result<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClearCartHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<bool>> Handle(ClearCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null || request.UserId.Equals(Guid.Empty))
                    return Result<bool>.Failure("The user id is required");

                var cartHeader = await _unitOfWork.CartHeaderRepository.FindByUserIdAsync(request.UserId);
                if(cartHeader is null)
                    return Result<bool>.NotFound();

                var cartDetails = await _unitOfWork.CartDetailRepository.FindByCartHeaderIdAsync(cartHeader.Id);
                foreach (var cartDetail in cartDetails)
                {
                    await _unitOfWork.CartDetailRepository.DeleteByIdAsync(cartDetail.Id);
                }
                await _unitOfWork.CartHeaderRepository.DeleteByIdAsync(cartHeader.Id);
                var commit = _unitOfWork.Complete();

                return commit > 0 ? Result<bool>.Success(true) : Result<bool>.Failure("Failed to clear cart.");
            }
            catch (Exception ex)
            {
                return Result<bool>.Failure("The operation failed, more details: " + ex.Message);
            }
        }
    }
}
