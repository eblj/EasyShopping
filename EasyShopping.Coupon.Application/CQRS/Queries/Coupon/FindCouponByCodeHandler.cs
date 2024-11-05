using AutoMapper;
using EasyShopping.Coupon.Application.Abstractions;
using EasyShopping.Coupon.Application.DTOs.Coupon;
using EasyShopping.Coupon.Core.Repositories;
using MediatR;

namespace EasyShopping.Coupon.Application.CQRS.Queries
{
    public class FindCouponByCodeHandler: IRequestHandler<FindCouponByCodeQuery, Result<CouponViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FindCouponByCodeHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<CouponViewModel>> Handle(FindCouponByCodeQuery request, CancellationToken cancellationToken)
        {
            try
            {
                if (request is null || string.IsNullOrEmpty(request.Code))
                    return Result<CouponViewModel>.Failure("The coupon code is required.");

                var coupon = await _unitOfWork.CouponRepository.FindCouponByCodeAsync(request.Code);
                if (coupon is null)
                    return Result<CouponViewModel>.NotFound();

                return Result<CouponViewModel>.Success(_mapper.Map<CouponViewModel>(coupon));
            }
            catch (Exception ex)
            {
                return Result<CouponViewModel>.Failure("The operation failed, more details: " + ex.Message);
            }
        }
    }
}
