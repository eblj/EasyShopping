using EasyShopping.Cart.Core.Entities;
using EasyShopping.Cart.Core.Repositories;
using EasyShopping.Cart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyShopping.Cart.Infrastructure.Repositories
{
    public class CartHeaderRepository : BaseRepository<CartHeader>, ICartHeaderRepository
    {
        public CartHeaderRepository(CartContext context) : base(context)
        {
            
        }

        public override async Task<CartHeader> CreateAsync(CartHeader entity)
        {            
            await _context.CartHeaders.AddAsync(entity);
            return entity;
        }

        public override async Task<CartHeader> UpdateAsync(CartHeader entity)
        {
            _context.CartHeaders.Update(entity);
            return await Task.FromResult(entity);
        }

        public override async Task DeleteByIdAsync(Guid id)
        {
            var cartHeader = await _context.CartHeaders.FindAsync(id);
            if (cartHeader is not null)
            {
                _context.CartHeaders.Remove(cartHeader);
            }
        }

        public override async Task<IList<CartHeader>> FindAllAsync()
        {
            return await _context.CartHeaders.ToListAsync();
        }

        public override async Task<CartHeader?> FindByIdAsync(Guid id)
        {
            return await _context.CartHeaders.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<CartHeader> FindByUserIdAsync(Guid userId)
        {
            return await _context.CartHeaders.AsNoTracking().FirstOrDefaultAsync(ch => ch.UserId.Equals(userId));
        }
    }
}
