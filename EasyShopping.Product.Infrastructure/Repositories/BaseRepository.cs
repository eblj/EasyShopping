using EasyShopping.Product.Core.Repositories;
using EasyShopping.Product.Infrastructure.Context;

namespace EasyShopping.Product.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly ProductContext _context;

        public BaseRepository(ProductContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public virtual Task<T> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual Task DeleteByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<IList<T>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<T?> FindByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
