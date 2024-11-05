using EasyShopping.Coupon.Core.Repositories;
using EasyShopping.Coupon.Infrastructure.Context;

namespace EasyShopping.Coupon.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CouponContext _context;
        public UnitOfWork(CouponContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            CouponRepository = new CouponRepository(_context);
        }

        public ICouponRepository CouponRepository { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
