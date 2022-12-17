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
        /// <summary>
        ///     Create the order of payment with instalments
        /// </summary>
        /// <param name="order">An view model of order</param>
        /// <returns>Return created order</returns>
        Task<OrderResponse> CreateOrder(OrdersViewModel order);

        /// <summary>
        ///     Get the list of orders
        /// </summary>
        /// <returns>Returns list of orders</returns>
        Task<IList<Order>> GetOrders();
    }
}
