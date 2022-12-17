using Zip.Installments.DAL.Interfaces;

namespace Zip.Installments.DAL.AppContext
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private OrdersDbContext _context;
        private IOrdersRepository _ordersRepository;

        public RepositoryWrapper(OrdersDbContext ordersDbContext)
        {
            _context = ordersDbContext;
        }
        public IOrdersRepository OrdersRepository
        {
            get
            {
                if (_ordersRepository == null)
                {
                    _ordersRepository = new OrdersRepository(_context);
                }
                return _ordersRepository;
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

    }
}
