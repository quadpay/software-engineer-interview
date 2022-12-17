using System.Collections.Generic;
using System.Threading.Tasks;
using Zip.InstallmentsService.Models;

namespace Zip.InstallmentsService.Interface
{
    /// <summary>
    ///     The Definition of Order Services
    /// </summary>
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrder(Order order);
        Task<List<Order>> GetOrders();
    }
}
