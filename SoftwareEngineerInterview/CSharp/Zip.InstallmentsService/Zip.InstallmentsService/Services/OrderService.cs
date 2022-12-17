using System.Collections.Generic;
using System.Threading.Tasks;
using Zip.InstallmentsService.Interface;
using Zip.InstallmentsService.Models;

namespace Zip.InstallmentsService.Services
{
    /// <summary>
    ///     The Implemetation of order service
    /// </summary>
    public class OrderService: IOrderService
    {
        public OrderService()
        {

        }

        public async Task<List<Order>> GetOrders()
        {
            return new List<Order>();
        }

        public async Task<OrderResponse> CreateOrder(Order order)
        {

            return new OrderResponse();
            
        }
    }
}
