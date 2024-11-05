namespace EasyShopping.Cart.Core.Repositories
{
    public interface ICartRepository
    {
        Task<Core.Entities.Cart?> FindByUserId(Guid userId);
        Task<Core.Entities.Cart> Create(Core.Entities.Cart entity);
        Task<Core.Entities.Cart> Update(Core.Entities.Cart entity);
        Task<bool> RemoveFrom(Guid id);
        Task<bool> ApplyCoupon(Guid userId, string couponCode);
        Task<bool> RemoveCoupon(Guid userId);
        Task<bool> Clear(Guid userId);
    }
}
