using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zip.Installments.DAL.Constants;
using Zip.Installments.DAL.Interfaces;
using Zip.Installments.DAL.Models;
using Zip.Installments.ViewModel.Orders;
using Zip.InstallmentsService.Interface;

namespace Zip.InstallmentsService.Services
{
    /// <summary>
    ///     The Implemetation of order service
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IRepositoryWrapper repository;

        /// <summary>
        ///     Initialize an instance of <see cref="OrderService"/>
        /// </summary>
        /// <param name="repository"></param>
        public OrderService(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }

        /// <summary>
        ///     Get the list of orders
        /// </summary>
        /// <returns>Returns list of orders</returns>
        public async Task<IList<Order>> GetOrders()
        {
            var response = await this.repository.OrdersRepository.FindAll();
            return response.OrderByDescending(n => n.FirstName).ToList();
        }

        /// <summary>
        ///     Create the order of payment with instalments
        /// </summary>
        /// <param name="order">An view model of order</param>
        /// <returns>Return created order</returns>
        public async Task<OrderResponse> CreateOrder(OrdersViewModel order)
        {
            if (order == null || order.NumberOfInstallments <= 0)
            {
                throw new ArgumentNullException("Invalid Instalments");
            }
            var newOrder = new Order
            {
                Id = order.Id,
                ProductId = order.ProductId,
                Description = order.Description,
                Email = order.Email,
                FirstName = order.FirstName,
                LastName = order.LastName,
                NumberOfInstallments = order.NumberOfInstallments,
                Payment = this.CreateInstallments(order)

            };
            await this.repository.OrdersRepository.Create(newOrder);
            await this.repository.Save();


            return new OrderResponse
            {
                Id = order.Id,
                Message = AppConstants.OrderCreatedSuccess,
                OrderStatus = OrderStatus.Purchased
            };

        }

        private PaymentPlan CreateInstallments(OrdersViewModel payment)
        {
            PaymentPlan paymentPlan = new PaymentPlan();

            if (payment == null)
            {
                throw new InvalidOperationException("Invalid payment plan");
            }

            if (payment.NumberOfInstallments == 0)
            {
                throw new InvalidOperationException("No valid installments found");
            }
            paymentPlan.Id = Guid.NewGuid();
            paymentPlan.PurchaseAmount = payment.PurchaseAmount;
            paymentPlan.Installments = this.CalculateInstallments(
                payment.PurchaseAmount,
                payment.NumberOfInstallments,
                payment.Frequency,
                payment.FirstPaymentDate);

            return paymentPlan;
        }

        private Installment[] CalculateInstallments(decimal purchaseAmount, int numberOfInstallments, int frequency, DateTime firstPaymentDate)
        {
            var installments = new List<Installment>();
            var oneInstallmentAmount = purchaseAmount / numberOfInstallments;
            if (firstPaymentDate.Date < DateTime.Now.Date)
            {
                throw new InvalidOperationException("Invalid payment date");
            }
            installments.Add(new Installment
            {
                Id = Guid.NewGuid(),
                Amount = oneInstallmentAmount,
                DueDate = firstPaymentDate,
            });

            for (int term = 1; term < numberOfInstallments; term++)
            {
                installments.Add(new Installment
                {
                    Id = Guid.NewGuid(),
                    Amount = oneInstallmentAmount,
                    DueDate = firstPaymentDate.AddDays(frequency),
                });
            }

            return installments.ToArray();
        }
    }
}
