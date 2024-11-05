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

        public async Task<Core.Entities.Coupon> FindCouponByCodeAsync(string code)
        {
            return await _context.Coupons.FirstOrDefaultAsync(c => c.Code.Equals(code));
        }
    }
}

