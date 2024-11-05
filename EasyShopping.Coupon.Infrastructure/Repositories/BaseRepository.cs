
using EasyShopping.Coupon.Core.Repositories;
using EasyShopping.Coupon.Infrastructure.Context;

namespace EasyShopping.Coupon.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly CouponContext _context;

        public BaseRepository(CouponContext context)
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
