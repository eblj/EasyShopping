using EasyShopping.Cart.Core.Entities;
using EasyShopping.Cart.Core.Repositories;
using EasyShopping.Cart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyShopping.Cart.Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(CartContext context) : base(context)
        {

        }

        public override async Task<Product> CreateAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
            return entity;
        }

        public override async Task<Product> UpdateAsync(Product entity)
        {
            _context.Products.Update(entity);
            return await Task.FromResult(entity);
        }

        public override async Task DeleteByIdAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is not null)
            {
                _context.Products.Remove(product);
            }
        }

        public override async Task<IList<Product>> FindAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public override async Task<Product?> FindByIdAsync(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }
    }
}
