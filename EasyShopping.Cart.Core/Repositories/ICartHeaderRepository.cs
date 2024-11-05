using EasyShopping.Cart.Core.Entities;

namespace EasyShopping.Cart.Core.Repositories
{
    public interface ICartHeaderRepository: IBaseRepository<CartHeader>
    {
        Task<CartHeader> FindByUserIdAsync(Guid userId);
    }
}
