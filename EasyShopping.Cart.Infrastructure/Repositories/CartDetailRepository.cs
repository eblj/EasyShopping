using EasyShopping.Cart.Core.Entities;
using EasyShopping.Cart.Core.Repositories;
using EasyShopping.Cart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyShopping.Cart.Infrastructure.Repositories
{
    public class CartDetailRepository : BaseRepository<CartDetail>, ICartDetailRepository
    {
        public CartDetailRepository(CartContext context) : base(context)
        {
            
        }

        public override async Task<CartDetail> CreateAsync(CartDetail entity)
        {
            await _context.CartDetails.AddAsync(entity);
            return entity;
        }

        public override async Task<CartDetail> UpdateAsync(CartDetail entity)
        {
            _context.CartDetails.Update(entity);
            return await Task.FromResult(entity);
        }

        public override async Task DeleteByIdAsync(Guid id)
        {
            var CartDetail = await _context.CartDetails.FindAsync(id);
            if (CartDetail is not null)
            {
                _context.CartDetails.Remove(CartDetail);
            }
        }

        public override async Task<IList<CartDetail>> FindAllAsync()
        {
            return await _context.CartDetails.ToListAsync();
        }

        public override async Task<CartDetail?> FindByIdAsync(Guid id)
        {
            return await _context.CartDetails.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<CartDetail> FindByCartHeaderAndProductAsync(Guid cartHeaderId, Guid productId)
        {
            return await _context.CartDetails.AsNoTracking().FirstOrDefaultAsync(cd => cd.CartHeaderId.Equals(cartHeaderId) && cd.ProductId.Equals(productId));
        }

        public async Task<IList<CartDetail>> FindByCartHeaderIdAsync(Guid cartHeaderId)
        {
            return await _context.CartDetails.Include(ch => ch.CartHeader).Include(p => p.Product).Where(ch => ch.CartHeaderId.Equals(cartHeaderId)).ToListAsync();
        }
    }
}
