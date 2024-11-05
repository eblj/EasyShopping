namespace EasyShopping.Coupon.Core.Repositories
{
    public interface ICouponRepository: IBaseRepository<Core.Entities.Coupon>
    {
        Task<Core.Entities.Coupon> FindCouponByCodeAsync(string code);
    }
}
