using EasyShopping.Product.Core.Entities;
using EasyShopping.Product.Core.Repositories;
using EasyShopping.Product.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyShopping.Product.Infrastructure.Repositories
{
    public class CategoryRepository: BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductContext context) : base(context)
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

        public IList<Category> FindAllPaged(out int totalRecords, int currentPage, int recordsByPage, string searchBy, string search, string orderBy, int orderDirection)
        {
            var query = _context.Categories.AsQueryable();
            if (!string.IsNullOrEmpty(searchBy))
            {
                if (searchBy.ToLower().Trim().Equals("name"))
                    query = query.Where(p => p.Name.ToLower().Trim().Contains(search.ToLower().Trim()));
            }

            totalRecords = query.Count();

            if (!string.IsNullOrEmpty(orderBy))
            {
                if (orderBy.ToLower().Trim().Equals("name"))
                    query = orderDirection == 1 ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name);
            }

            return query.Skip(currentPage * recordsByPage).Take(recordsByPage).ToList();
        }
    }
}
