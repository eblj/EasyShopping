using AutoMapper;
using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.Validators;
using EasyShopping.Product.Core.Repositories;
using MediatR;

namespace EasyShopping.Product.Application.CQRS.Commands
{
    public class CreateProductHandler: IRequestHandler<CreateProductCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var createProductValidator = new CreateProductValidator();
                var resultValidate = createProductValidator.Validate(request);
                if (resultValidate.IsValid)
                {
                    var createdProduct = await _unitOfWork.ProductRepository.CreateAsync(_mapper.Map<Core.Entities.Product>(request.Product));
                    var commit = _unitOfWork.Complete();
                    return commit > 0 ? Result<Guid>.Success(createdProduct.Id) : Result<Guid>.Failure("Failed to create the product.");
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
