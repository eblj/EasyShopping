namespace EasyShopping.Cart.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        ICartHeaderRepository CartHeaderRepository { get; }
        ICartDetailRepository CartDetailRepository { get; }
        ICartRepository CartRepository { get; }
        int Complete();
    }
}
