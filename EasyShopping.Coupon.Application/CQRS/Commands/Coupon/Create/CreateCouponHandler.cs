using AutoMapper;
using EasyShopping.Coupon.Application.Abstractions;
using EasyShopping.Coupon.Application.Validators.Coupon;
using EasyShopping.Coupon.Core.Repositories;
using MediatR;

namespace EasyShopping.Coupon.Application.CQRS.Commands
{
    public class CreateCouponHandler: IRequestHandler<CreateCouponCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCouponHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<Guid>> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var createCouponValidator = new CreateCouponValidator();
                var resultValidate = createCouponValidator.Validate(request);
                if (resultValidate.IsValid)
                {
                    var createdCoupon = await _unitOfWork.CouponRepository.CreateAsync(_mapper.Map<Core.Entities.Coupon>(request.Coupon));
                    var commit = _unitOfWork.Complete();
                    return commit > 0 ? Result<Guid>.Success(createdCoupon.Id) : Result<Guid>.Failure("Failed to create the coupon.");
                }
                else
                {
                    var erros = string.Join(", ", resultValidate.Errors.Select(e => e.ErrorMessage));
                    return Result<Guid>.Failure(erros);
                }

            }
            catch (Exception ex)
            {
                return Result<Guid>.Failure("The operation failed, more details: " + ex.Message);
            }
        }
    }
}
