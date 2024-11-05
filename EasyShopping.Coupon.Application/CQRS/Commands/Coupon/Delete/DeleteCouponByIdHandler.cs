using AutoMapper;
using EasyShopping.Coupon.Application.Abstractions;
using EasyShopping.Coupon.Application.Validators.Coupon;
using EasyShopping.Coupon.Core.Repositories;
using MediatR;

namespace EasyShopping.Coupon.Application.CQRS.Commands
{
    public class DeleteCouponByIdHandler: IRequestHandler<DeleteCouponByIdCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCouponByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<int>> Handle(DeleteCouponByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deleteCouponValidator = new DeleteCouponByIdValidator();
                var resultValidate = deleteCouponValidator.Validate(request);
                if (resultValidate.IsValid)
                {
                    await _unitOfWork.CouponRepository.DeleteByIdAsync(request.Id);
                    var commit = _unitOfWork.Complete();
                    return commit > 0 ? Result<int>.Success(commit) : Result<int>.Failure("Failed to delete the coupon.");
                }
                else
                {
                    var erros = string.Join(", ", resultValidate.Errors.Select(e => e.ErrorMessage));
                    return Result<int>.Failure(erros);
                }
            }
            catch (Exception ex)
            {
                return Result<int>.Failure("The operation failed, more details: " + ex.Message);
            }
        }
    }
}
