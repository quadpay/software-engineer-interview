using System.Collections.Generic;
using System.Threading.Tasks;
using Zip.Installments.DAL.Constants;
using Zip.Installments.DAL.Interfaces;
using Zip.Installments.DAL.Models;
using Zip.InstallmentsService.Interface;

namespace Zip.InstallmentsService.Services
{
    /// <summary>
    ///     The Implemetation of order service
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IRepositoryWrapper repository;

        public OrderService(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }

        public async Task<IList<Order>> GetOrders()
        {
            return await this.repository.OrdersRepository.FindAll();
        }

        public async Task<OrderResponse> CreateOrder(Order order)
        {
            await this.repository.OrdersRepository.Create(order);
            return new OrderResponse
            {
                Id = order.Id,
                Message = AppConstants.OrderCreatedSuccess,
                OrderStatus = OrderStatus.Purchased
            };

        }
    }
}
