using EasyShopping.Cart.Core.Repositories;
using EasyShopping.Cart.Infrastructure.Context;

namespace EasyShopping.Cart.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly CartContext _context;

        public BaseRepository(CartContext context)
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
