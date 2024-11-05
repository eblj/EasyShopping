using AutoMapper;
using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.Validators;
using EasyShopping.Product.Core.Repositories;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Commands
{
    public class DeleteCategoryByIdHandler: IRequestHandler<DeleteCategoryByIdCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCategoryByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<int>> Handle(DeleteCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deleteCategoryValidator = new DeleteCategoryByIdValidator();
                var resultValidate = deleteCategoryValidator.Validate(request);
                if (resultValidate.IsValid)
                {
                    var existsProductsInCategory = await _unitOfWork.CategoryRepository.CheckIfExistsProductsInCategoryById(request.Id);
                    if (existsProductsInCategory)
                        return Result<int>.Failure("Not allowed, there are products in this category.");

                    await _unitOfWork.CategoryRepository.DeleteByIdAsync(request.Id);
                    var commit = _unitOfWork.Complete();
                    return commit > 0 ? Result<int>.Success(commit) : Result<int>.Failure("Failed to delete the category.");
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
