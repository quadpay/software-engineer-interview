using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;
using System.Threading.Tasks;
using Xunit;
using Zip.Installments.API.Controllers;
using Zip.InstallmentsService.Interface;
using Zip.InstallmentsService.Models;

namespace Zip.Installments.API.Tests.Controllers
{
    public class OrdersControllerTest
    {
        private readonly Mock<IOrderService> orderService;
        private readonly Mock<ILogger<OrdersController>> logger;
        private readonly OrdersController ordersController;
        public OrdersControllerTest()
        {
            this.orderService = new Mock<IOrderService>();
            this.logger = new Mock<ILogger<OrdersController>>();
            this.ordersController = new OrdersController(
                this.orderService.Object,
                this.logger.Object);
        }
        [Fact]
        public async Task CreateOrders_Throws_ArgumentNullExceptions()
        {
            // Arrange
            Order order = null;
            // Act
            var response = await this.ordersController.CreateOrders(order) as ObjectResult;

            //Assert

            Assert.NotNull(response);
            Assert.Equal((int)HttpStatusCode.BadRequest, response?.StatusCode);

        }
    }
}