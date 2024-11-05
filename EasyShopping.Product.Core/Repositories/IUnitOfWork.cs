namespace EasyShopping.Product.Core.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        int Complete();
    }
}
