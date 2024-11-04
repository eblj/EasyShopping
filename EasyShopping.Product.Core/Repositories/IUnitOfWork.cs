namespace EasyShopping.Product.Core.Repositories
{
    public interface IUnitOfWork: IDisposable
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        int Complete();
    }
}
