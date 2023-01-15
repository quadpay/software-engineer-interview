using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zip.Installements.Command.Commands;
using Zip.Installements.Contract.Request;
using Zip.Installements.Contract.Response;
using Zip.Installements.Query.Queries;
using Zip.InstallmentsService.Interface;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Zip.Installements.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("v{v:apiVersion}/paymentinstallement")]
    [ApiController]
    public class PaymentInstallementController : ControllerBase
    {
        private readonly IPaymentInstallementPlan paymentInstallementPlan;
        private readonly IMediator mediator;

        public PaymentInstallementController(IPaymentInstallementPlan paymentInstallementPlan,
            IMediator mediator)
        {
            this.paymentInstallementPlan = paymentInstallementPlan;
            this.mediator = mediator;
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(List<InstallementDetailsResponse>), Status200OK)]
        [ProducesResponseType(Status204NoContent)]
        [ProducesResponseType(Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var data = await this.mediator.Send(new GetPaymentInstallementPlanByIdQuery() { Id = id });

            if (!data.Any())
            {
                return this.NoContent();
            }

            else
            {
                return this.Ok(data);
            }
        }

        [HttpPost]
        [ProducesResponseType(Status400BadRequest)]
        [ProducesResponseType(Status200OK)]
        [ProducesResponseType(Status500InternalServerError)]
        public async Task<IActionResult> Post([FromBody] PaymentPlanRequest paymentPlanRequest)
        {
            if (!ModelState.IsValid)
            {
                //Sending bad request status to client when request model validation failed
                return this.BadRequest();
            }

            else
            {
                var paymentPlan = this.paymentInstallementPlan.CreatePaymentPlan(paymentPlanRequest);

                var id = await this.mediator.Send(new CreatePaymentInstallementPlanCommand() { payment = paymentPlan });

                return this.Ok(id);
            }
        }
    }
}
