using Microsoft.AspNetCore.Mvc;
using System.Net;
using Zip.Installments.DAL.Models;
using Zip.Installments.Validations.Controllers;
using Zip.InstallmentsService.Helpers;
using Zip.InstallmentsService.Interface;

namespace Zip.Installments.API.Controllers
{
    /// <summary>
    ///     The Definition of user orders controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly ILogger<OrdersController> logger;

        public OrdersController(
            IOrderService orderService,
            ILogger<OrdersController> logger)
        {
            this.orderService = orderService;
            this.logger = logger;
        }


        /// <summary>
        ///     GET: To get the list of user orders 
        /// </summary>
        /// <param name="order">An instance of <see cref="Order"/></param>
        /// <returns>Returns an instance of <see cref="OrderResponse"/></returns>
        [HttpGet("")]
        public async Task<IActionResult> GetOrders()
        {

            try
            {
                var response = this.orderService.GetOrders();
                return response == null ? this.NotFound() :
                    Ok(response);
            }
            catch (UnauthorizedAccessException ex)
            {
                return ObjectResponse.GetResults(HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (AccessViolationException ex)
            {
                return ObjectResponse.GetResults(HttpStatusCode.Forbidden, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return ObjectResponse.GetResults(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (InvalidDataException ex)
            {
                return ObjectResponse.GetResults(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                return ObjectResponse.GetResults(HttpStatusCode.Conflict, ex.Message, true);
            }

        }

        /// <summary>
        ///     POST: Create user order 
        /// </summary>
        /// <param name="order">An instance of <see cref="Order"/></param>
        /// <returns>Returns an instance of <see cref="OrderResponse"/></returns>
        [HttpPost("")]
        public async Task<IActionResult> CreateOrders(
            [FromBody] Order order)
        {

            try
            {
                if (order == null)
                {
                    throw new ArgumentNullException("Invalid Order");
                }
                var validator = new CreateOrdersValidator();
                var validationResult = validator.Validate(order);
                if (validationResult.IsValid)
                {
                    var response = await this.orderService.CreateOrder(order);

                    return response == null ? this.NotFound() :
                        Ok(response);
                }
                else
                {
                    return this.NotFound();
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                return ObjectResponse.GetResults(HttpStatusCode.Unauthorized, ex.Message);
            }
            catch (AccessViolationException ex)
            {
                return ObjectResponse.GetResults(HttpStatusCode.Forbidden, ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return ObjectResponse.GetResults(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return ObjectResponse.GetResults(HttpStatusCode.BadRequest, ex.Message);
            }
            catch (InvalidDataException ex)
            {
                return ObjectResponse.GetResults(HttpStatusCode.Conflict, ex.Message);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message, ex);
                return ObjectResponse.GetResults(HttpStatusCode.Conflict, ex.Message, true);
            }

        }
    }
}
