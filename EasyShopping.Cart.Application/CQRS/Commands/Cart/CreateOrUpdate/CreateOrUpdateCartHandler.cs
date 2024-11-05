using AutoMapper;
using EasyShopping.Cart.Application.Abstractions;
using EasyShopping.Cart.Application.Validators.Cart;
using EasyShopping.Cart.Core.Entities;
using EasyShopping.Cart.Core.Repositories;
using MediatR;

namespace EasyShopping.Cart.Application.CQRS.Commands
{
    public class CreateOrUpdateCartHandler: IRequestHandler<CreateOrUpdateCartCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrUpdateCartHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Result<Guid>> Handle(CreateOrUpdateCartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cartValidator = new CreateOrUpdateCartValidator();
                var resultValidate = cartValidator.Validate(request);
                if (resultValidate.IsValid)
                {
                    Core.Entities.Cart cart = _mapper.Map<Core.Entities.Cart>(request.Cart);

                    //Check if category exists
                    var category = await _unitOfWork.CategoryRepository.FindByIdAsync(cart.CartDetails.First().Product.CategoryId);
                    if (category is null)
                        category = await _unitOfWork.CategoryRepository.CreateAsync(cart.CartDetails.First().Product.Category);

                    cart.CartDetails.First().Product.CategoryId = category.Id;
                    cart.CartDetails.First().Product.Category = category;

                    //Check if category exists
                    var product = await _unitOfWork.ProductRepository.FindByIdAsync(cart.CartDetails.First().ProductId);
                    if(product is null)
                        product = await _unitOfWork.ProductRepository.CreateAsync(_mapper.Map<Product>(cart.CartDetails.First().Product));

                    cart.CartDetails.First().ProductId = product.Id;
                    cart.CartDetails.First().Product = product;

                    //Check if cart header exists
                    var cartHeader = await _unitOfWork.CartHeaderRepository.FindByUserIdAsync(cart.CartHeader.UserId);
                    if (cartHeader is null)
                        cartHeader = await _unitOfWork.CartHeaderRepository.CreateAsync(_mapper.Map<CartHeader>(cart.CartHeader));

                    cart.CartHeader = cartHeader;
                    cart.CartDetails.First().CartHeaderId = cartHeader.Id;
                    

                    //Check if cart detail exists
                    var cartDetails = await _unitOfWork.CartDetailRepository.FindByCartHeaderAndProductAsync(cartHeader.Id, cart.CartDetails.First().ProductId);
                    if(cartDetails is null)
                    {
                        cart.CartDetails.First().Product = null;
                        cart.CartDetails.First().CartHeader = null;
                        cart.CartDetails.First().Count = cart.CartDetails.First().Count;
                        cartDetails = await _unitOfWork.CartDetailRepository.CreateAsync(_mapper.Map<CartDetail>(cart.CartDetails.First()));
                    }
                    else
                    {
                        cartDetails.Count += cart.CartDetails.First().Count;
                        await _unitOfWork.CartDetailRepository.UpdateAsync(cartDetails);
                    }
                    
                    var commit = _unitOfWork.Complete();
                    return commit > 0 ? Result<Guid>.Success(cart.CartHeader.Id) : Result<Guid>.Failure("Failed to create cart.");
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
