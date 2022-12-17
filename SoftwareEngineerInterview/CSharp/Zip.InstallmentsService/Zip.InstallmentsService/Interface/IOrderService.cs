using System.Collections.Generic;
using System.Threading.Tasks;
using Zip.Installments.DAL.Models;
using Zip.Installments.ViewModel.Orders;

namespace Zip.InstallmentsService.Interface
{
    /// <summary>
    ///     The Definition of Order Services
    /// </summary>
    public interface IOrderService
    {
        Task<OrderResponse> CreateOrder(OrdersViewModel order);
        Task<IList<Order>> GetOrders();
    }
}
