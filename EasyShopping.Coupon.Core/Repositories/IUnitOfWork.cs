namespace EasyShopping.Coupon.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICouponRepository CouponRepository { get; }
        int Complete();
    }
}
