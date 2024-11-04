using EasyShopping.Product.Core.Repositories;
using EasyShopping.Product.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyShopping.Product.Infrastructure.Repositories
{
    public class ProductRepository: BaseRepository<Core.Entities.Product>, IProductRepository
    {
        public ProductRepository(ProductContext context) : base(context)
        {
            
        }

        public override async Task<Core.Entities.Product> CreateAsync(Core.Entities.Product entity)
        {
            await _context.Products.AddAsync(entity);
            return entity;
        }

        public override async Task<Core.Entities.Product> UpdateAsync(Core.Entities.Product entity)
        {
            _context.Products.Update(entity);
            return await Task.FromResult(entity);
        }

        public override async Task DeleteByIdAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is not null) { 
                _context.Products.Remove(product);
            }
        }

        public override async Task<IList<Core.Entities.Product>> FindAllAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public override async Task<Core.Entities.Product?> FindByIdAsync(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        public IList<Core.Entities.Product> FindAllPaged(out int totalRecords, int currentPage, int recordsByPage, string searchBy, string search, string orderBy, int orderDirection)
        {
            var query = _context.Products.AsQueryable();
            if (!string.IsNullOrEmpty(searchBy)) { 
                if(searchBy.ToLower().Trim().Equals("name"))
                    query = query.Where(p => p.Name.ToLower().Trim().Contains(search.ToLower().Trim()));
                else if(searchBy.ToLower().Trim().Equals("price"))
                    query = query.Where(p => p.Price == Convert.ToDecimal(search));
                else if (searchBy.ToLower().Trim().Equals("description"))
                    query = query.Where(p => p.Description.ToLower().Trim().Contains(search.ToLower().Trim()));
            }            

            totalRecords = query.Count();

            if (!string.IsNullOrEmpty(orderBy))
            {
                if(orderBy.ToLower().Trim().Equals("name"))
                    query = orderDirection == 1 ? query.OrderBy(p => p.Name) : query.OrderByDescending(p => p.Name);
                else if (orderBy.ToLower().Trim().Equals("price"))
                    query = orderDirection == 1 ? query.OrderBy(p => p.Price) : query.OrderByDescending(p => p.Price);
                else if (orderBy.ToLower().Trim().Equals("description"))
                    query = orderDirection == 1 ? query.OrderBy(p => p.Description) : query.OrderByDescending(p => p.Description);
            }

            return query.Skip(currentPage * recordsByPage).Take(recordsByPage).ToList();
        }
    }
}
