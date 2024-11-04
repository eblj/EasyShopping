namespace EasyShopping.Product.Core.Repositories
{
    public interface IProductRepository: IBaseRepository<Core.Entities.Product>
    {
        IList<Core.Entities.Product> FindAllPaged(out int totalRecords, int currentPage, int recordsByPage, string searchBy, string search, string orderBy, int orderDirection);
    }
}
