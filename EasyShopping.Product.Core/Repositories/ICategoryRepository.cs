namespace EasyShopping.Product.Core.Repositories
{
    public interface ICategoryRepository: IBaseRepository<Core.Entities.Category>
    {
        IList<Core.Entities.Category> FindAllPaged(out int totalRecords, int currentPage, int recordsByPage, string searchBy, string search, string orderBy, int orderDirection);
        Task<bool> CheckIfExistsProductsInCategoryById(Guid id);
    }
}
