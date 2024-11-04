using AutoMapper;
using EasyShopping.Product.Application.Abstractions;
using EasyShopping.Product.Application.Validators;
using EasyShopping.Product.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyShopping.Product.Application.CQRS.Commands
{
    public class DeleteProductByIdHandler: IRequestHandler<DeleteProductByIdCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteProductByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<int>> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var deleteProductValidator = new DeleteProductByIdValidator();
                var resultValidate = deleteProductValidator.Validate(request);
                if (resultValidate.IsValid)
                {
                    await _unitOfWork.Products.DeleteByIdAsync(request.Id);
                    var commit = _unitOfWork.Complete();
                    return commit > 0 ? Result<int>.Success(commit) : Result<int>.Failure("Failed to delete the product.");
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
