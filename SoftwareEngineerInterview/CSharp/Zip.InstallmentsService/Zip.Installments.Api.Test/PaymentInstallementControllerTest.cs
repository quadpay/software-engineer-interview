namespace Zip.Installments.Api.Test
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Moq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Zip.Installments.Api.Controllers;
    using Zip.Installments.Command.Commands;
    using Zip.Installments.Contract.Request;
    using Zip.Installments.Contract.Response;
    using Zip.Installments.Domain.Entities;
    using Zip.Installments.Query.Queries;
    using Zip.InstallmentsService.Interface;

    [TestFixture]
    public class PaymentInstallementControllerTest
    {
        private Mock<IMediator> mediator;
        private Mock<IPaymentInstallementPlan> paymentInstallementPlan;
        private PaymentInstallementController paymentInstallementController = null;

        [SetUp]
        public void Setup()
        {
            this.mediator = new Mock<IMediator>();
            this.paymentInstallementPlan = new Mock<IPaymentInstallementPlan>();
        }

        [Test]
        public async Task Should_Create_PaymentInstallementPlan_WithStatus200Ok()
        {
            var payment = new Payment()
            {
                Id = 1,
                Amount = 2000,
                CreateDateTime = DateTimeOffset.UtcNow,
                InstallementPlans = new List<InstallementPlan>()
                {
                    new InstallementPlan()
                    {
                        Id  = 2,
                        CreateDateTime = DateTimeOffset.UtcNow,
                        DueAmount = 2000,
                        DueDate = DateTimeOffset.UtcNow,
                        PaymentId = 1,
                    }
                }
            };

            var response = new List<InstallementDetailsResponse>()
            { new InstallementDetailsResponse()
                {
                   PaymentId = 1,
                   DueAmount = 2000,
                   DueDate = DateTimeOffset.UtcNow.ToString("MM/dd/yyyy")
                }
            };

            this.paymentInstallementPlan.Setup(x => x.CreatePaymentPlan(It.IsAny<PaymentPlanRequest>()))
                .Returns(payment);

            this.mediator.Setup(x => x.Send(It.IsAny<CreatePaymentInstallementPlanCommand>(), new CancellationToken()));

            this.mediator.Setup(x => x.Send(It.IsAny<GetPaymentInstallementPlanByIdQuery>(), new CancellationToken()))
                .ReturnsAsync(response);

            this.paymentInstallementController = new PaymentInstallementController(this.paymentInstallementPlan.Object,
                this.mediator.Object);

            var result = await this.paymentInstallementController.Post(
                new PaymentPlanRequest()
                {
                    Amount = 2000,
                    Frequency = 1,
                    NumofInstallement = 1
                }
              ) as OkObjectResult;

            var responseResult = result?.Value as List<InstallementDetailsResponse>;
            var paymentId = responseResult?.FirstOrDefault()?.PaymentId;

            Assert.Multiple(() =>
            {
                Assert.That(responseResult?.Count, Is.EqualTo(1));
                Assert.That(result?.StatusCode, Is.EqualTo(200));
                Assert.That(result?.Value, Is.TypeOf<List<InstallementDetailsResponse>>());
                Assert.That(paymentId, Is.EqualTo(1));
                this.mediator.Verify(x => x.Send(It.IsAny<CreatePaymentInstallementPlanCommand>(), new CancellationToken()), Times.Exactly(1));
                this.mediator.Verify(x => x.Send(It.IsAny<GetPaymentInstallementPlanByIdQuery>(), new CancellationToken()), Times.Exactly(1));
                this.paymentInstallementPlan.Verify(x => x.CreatePaymentPlan(It.IsAny<PaymentPlanRequest>()), Times.Once);
            });
        }

        [Test]
        public async Task Should_Not_Create_PaymentInstallementPlan_WithStatus400BadRequest()
        {
            this.paymentInstallementPlan.Setup(x => x.CreatePaymentPlan(It.IsAny<PaymentPlanRequest>()));

            this.mediator.Setup(x => x.Send(It.IsAny<CreatePaymentInstallementPlanCommand>(), new CancellationToken()));

            this.mediator.Setup(x => x.Send(It.IsAny<GetPaymentInstallementPlanByIdQuery>(), new CancellationToken()));

            this.paymentInstallementController = new PaymentInstallementController(this.paymentInstallementPlan.Object,
               this.mediator.Object);

            this.paymentInstallementController.ModelState.AddModelError("Amount", "Amount is required.");
            this.paymentInstallementController.ModelState.AddModelError("Frequency", "Frequency is required.");
            this.paymentInstallementController.ModelState.AddModelError("NumofInstallement", "Number of installement is required.");

            var result = await this.paymentInstallementController.Post(new PaymentPlanRequest() { }) as BadRequestResult;

            Assert.That(result?.StatusCode, Is.EqualTo(400));
        }

        [Test]
        public async Task Should_Get_PaymentInstallementPlan_WithStatus200Ok()
        {
            var response = new List<InstallementDetailsResponse>()
            { new InstallementDetailsResponse()
                {
                   PaymentId = 1,
                   DueAmount = 2000,
                   DueDate = DateTimeOffset.UtcNow.ToString("MM/dd/yyyy")
                }
            };

            this.mediator.Setup(x => x.Send(It.IsAny<GetPaymentInstallementPlanByIdQuery>(), new CancellationToken()))
             .ReturnsAsync(response);

            this.paymentInstallementController = new PaymentInstallementController(this.paymentInstallementPlan.Object,
              this.mediator.Object);

            var result = await this.paymentInstallementController.Get(1) as OkObjectResult;

            var resultResponse = result?.Value as List<InstallementDetailsResponse>;

            var paymentId = resultResponse?.FirstOrDefault()?.PaymentId;

            Assert.Multiple(() =>
            {
                Assert.That(resultResponse?.Count, Is.EqualTo(1));
                Assert.That(paymentId, Is.EqualTo(1));
                Assert.That(result?.StatusCode, Is.EqualTo(200));
                this.mediator.Verify(x => x.Send(It.IsAny<GetPaymentInstallementPlanByIdQuery>(), new CancellationToken()), Times.Exactly(1));
            });
        }

        [Test]
        public async Task Should_Not_Get_PaymentInstallementPlan_WithStatus204NoContent()
        {
            var response = new List<InstallementDetailsResponse>() { };


            this.mediator.Setup(x => x.Send(It.IsAny<GetPaymentInstallementPlanByIdQuery>(), new CancellationToken()))
             .ReturnsAsync(response);

            this.paymentInstallementController = new PaymentInstallementController(this.paymentInstallementPlan.Object,
              this.mediator.Object);

            var result = await this.paymentInstallementController.Get(1) as NoContentResult;

            Assert.Multiple(() =>
                {
                    Assert.That(result?.StatusCode, Is.EqualTo(204));
                    this.mediator.Verify(x => x.Send(It.IsAny<GetPaymentInstallementPlanByIdQuery>(), new CancellationToken()), Times.Exactly(1));
                });
        }
    }
}
