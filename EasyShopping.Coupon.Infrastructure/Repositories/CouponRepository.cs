using EasyShopping.Coupon.Core.Repositories;
using EasyShopping.Coupon.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace EasyShopping.Coupon.Infrastructure.Repositories
{
    public class CouponRepository : BaseRepository<Core.Entities.Coupon>, ICouponRepository
    {
        public CouponRepository(CouponContext context) : base(context)
        {

        }

        public async override Task<Core.Entities.Coupon> CreateAsync(Core.Entities.Coupon entity)
        {
            await _context.Coupons.AddAsync(entity);
            return entity;
        }

        public override async Task DeleteByIdAsync(Guid id)
        {
            var coupon = await _context.Coupons.FindAsync(id);
            if (coupon is not null)
            {
                _context.Coupons.Remove(coupon);
            }
        }

        public async Task<Core.Entities.Coupon> FindCouponByCodeAsync(string code)
        {
            return await _context.Coupons.FirstOrDefaultAsync(c => c.Code.Equals(code));
        }
    }
}

