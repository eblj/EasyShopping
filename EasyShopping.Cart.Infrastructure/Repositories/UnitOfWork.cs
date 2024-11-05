using EasyShopping.Cart.Core.Repositories;
using EasyShopping.Cart.Infrastructure.Context;

namespace EasyShopping.Cart.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CartContext _context;
        public UnitOfWork(CartContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            ProductRepository = new ProductRepository(_context);
            CategoryRepository = new CategoryRepository(_context);
            CartHeaderRepository = new CartHeaderRepository(_context);
            CartDetailRepository = new CartDetailRepository(_context);
            CartRepository = new CartRepository(_context);
        }

        public IProductRepository ProductRepository { get; private set; }
        public ICategoryRepository CategoryRepository { get; private set; }
        public ICartHeaderRepository CartHeaderRepository { get; private set; }
        public ICartDetailRepository CartDetailRepository { get; private set; }
        public ICartRepository CartRepository { get; set; }

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
