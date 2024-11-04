using EasyShopping.Product.Core.Repositories;
using EasyShopping.Product.Infrastructure.Context;

namespace EasyShopping.Product.Infrastructure.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ProductContext _context;
        public UnitOfWork(ProductContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Products = new ProductRepository(_context);
            Categories = new CategoryRepository(_context);
        }

        public IProductRepository Products { get; private set; }
        public ICategoryRepository Categories { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
