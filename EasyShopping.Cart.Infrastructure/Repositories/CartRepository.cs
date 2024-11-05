using EasyShopping.Cart.Core.Repositories;
using EasyShopping.Cart.Infrastructure.Context;
using System;
using System.Threading.Tasks;

namespace EasyShopping.Cart.Infrastructure.Repositories
{
    public class CartRepository: BaseRepository<Core.Entities.Cart>, ICartRepository
    {
        public CartRepository(CartContext context) : base(context)
        {
            
        }

        public Task<bool> ApplyCoupon(Guid userId, string couponCode)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Clear(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<Core.Entities.Cart> Create(Core.Entities.Cart entity)
        {
            throw new NotImplementedException();
        }

        public Task<Core.Entities.Cart?> FindByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveCoupon(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoveFrom(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Core.Entities.Cart> Update(Core.Entities.Cart entity)
        {
            throw new NotImplementedException();
        }
    }
}
