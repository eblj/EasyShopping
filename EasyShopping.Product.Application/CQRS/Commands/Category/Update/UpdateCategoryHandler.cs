using AutoMapper;
using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.Validators;
using EasyShopping.Product.Core.Repositories;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Commands
{
    public class UpdateCategoryHandler: IRequestHandler<UpdateCategoryCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<Guid>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var updateCategorytValidator = new UpdateCategoryValidator();
                var resultValidate = updateCategorytValidator.Validate(request);
                if (resultValidate.IsValid)
                {
                    var updatedCategory = await _unitOfWork.CategoryRepository.UpdateAsync(_mapper.Map<Core.Entities.Category>(request.Category));
                    var commit = _unitOfWork.Complete();
                    return commit > 0 ? Result<Guid>.Success(updatedCategory.Id) : Result<Guid>.Failure("Failed to update the category.");
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
