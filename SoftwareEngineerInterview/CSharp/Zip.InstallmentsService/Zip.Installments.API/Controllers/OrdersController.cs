using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Zip.InstallmentsService.Helpers;
using Zip.InstallmentsService.Interface;

namespace Zip.Installments.API.Controllers
{
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

        [HttpGet("")]
        public IActionResult GetOrders()
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
    }
}
