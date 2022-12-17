using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Zip.Installments.DAL.Interfaces;
using Zip.Installments.ViewModel.Orders;
using Zip.InstallmentsService.Services;

namespace Zip.Installments.API.Tests.Services
{
    /// <summary>
    ///     The unit test case of serice layer
    /// </summary>
    public class OrderServiceTest
    {
        private readonly OrderService orderService;
        private readonly Mock<IRepositoryWrapper> repository;
        
        /// <summary>
        ///     Initialize the service unit test
        /// </summary>
        public OrderServiceTest()
        {
            this.repository = new Mock<IRepositoryWrapper>();
            this.orderService = new OrderService(this.repository.Object);
        }

        /// <summary>
        ///     TEST: Order has valid installment
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateOrder_Throws_ArgumentException_IfInsallmentInvalid()
        {
            //Arrange
            OrdersViewModel ordersViewModel = new OrdersViewModel { NumberOfInstallments = 0 };
            //Act
            var resp = await Record.ExceptionAsync(() => this.orderService.CreateOrder(ordersViewModel));

            //Assert
            Assert.NotNull(resp);
            Assert.IsType<ArgumentNullException>(resp);
        }
    }
}
