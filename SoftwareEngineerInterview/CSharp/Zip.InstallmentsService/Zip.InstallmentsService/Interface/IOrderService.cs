using System.Collections.Generic;
using Zip.InstallmentsService.Models;

namespace Zip.InstallmentsService.Interface
{
    /// <summary>
    ///     The Definition of Order Services
    /// </summary>
    public interface IOrderService
    {
        OrderResponse CreateOrder(Order order);
        List<Order> GetOrders();
    }
}
