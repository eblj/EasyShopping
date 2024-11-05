using EasyShopping.Cart.Core.Entities;

namespace EasyShopping.Cart.Core.Repositories
{
    public interface ICartDetailRepository : IBaseRepository<CartDetail>
    {
        Task<CartDetail> FindByCartHeaderAndProductAsync(Guid cartHeaderId, Guid productId);
        Task<IList<CartDetail>> FindByCartHeaderIdAsync(Guid cartHeaderId);
    }
}
