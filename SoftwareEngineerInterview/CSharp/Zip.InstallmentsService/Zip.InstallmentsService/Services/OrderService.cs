using System.Collections.Generic;
using Zip.InstallmentsService.Interface;
using Zip.InstallmentsService.Models;

namespace Zip.InstallmentsService.Services
{
    /// <summary>
    ///     The Implemet
    /// </summary>
    public class OrderService: IOrderService
    {
        public OrderService()
        {

        }

        public List<Order> GetOrders()
        {
            return new List<Order>();
        }
        public OrderResponse CreateOrder(Order order)
        {

            return new OrderResponse();
            
        }
    }
}
