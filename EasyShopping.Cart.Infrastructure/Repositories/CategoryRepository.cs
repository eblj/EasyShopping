using EasyShopping.Cart.Core.Entities;
using EasyShopping.Cart.Core.Repositories;
using EasyShopping.Cart.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyShopping.Cart.Infrastructure.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CartContext context) : base(context)
        {
            
        }

        public override async Task<Category> CreateAsync(Category entity)
        {
            await _context.Categories.AddAsync(entity);
            return entity;
        }

        public override async Task<Category> UpdateAsync(Category entity)
        {
            _context.Categories.Update(entity);
            return await Task.FromResult(entity);
        }

        public override async Task DeleteByIdAsync(Guid id)
        {
            var category = await _context.Categories.FindAsync(id);
            if (category is not null)
            {
                _context.Categories.Remove(category);
            }
        }

        public override async Task<IList<Category>> FindAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public override async Task<Category?> FindByIdAsync(Guid id)
        {
            return await _context.Categories.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }
    }
}
