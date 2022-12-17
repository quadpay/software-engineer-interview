using Zip.Installments.DAL.Interfaces;
using Zip.Installments.DAL.Models;

namespace Zip.Installments.DAL.AppContext
{
    public class OrdersRepository : RepositoryBase<Order>, IOrdersRepository
    {
        public OrdersRepository(OrdersDbContext dbContext) : base(dbContext)
        {
        }      

    }
}
