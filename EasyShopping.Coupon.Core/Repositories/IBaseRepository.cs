namespace EasyShopping.Coupon.Core.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IList<T>> FindAllAsync();
        Task<T?> FindByIdAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteByIdAsync(Guid id);
    }
}
