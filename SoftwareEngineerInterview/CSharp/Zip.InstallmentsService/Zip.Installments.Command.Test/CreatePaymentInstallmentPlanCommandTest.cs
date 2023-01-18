namespace Zip.Installments.Command.Test
{
    using AutoFixture;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Zip.Installments.Command.Commands;
    using Zip.Installments.Domain.Entities;
    using Zip.Installments.Infrastructure.Context;
    using static Zip.Installments.Command.Commands.CreatePaymentInstallmentPlanCommand;

    [TestFixture]
    public class CreatePaymentInstallmentPlanCommandTest
    {
        private Mock<ZipPayContext> zipPayContext;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture() { OmitAutoProperties = true };
            var param = fixture.Build<DbContextOptions<ZipPayContext>>().Create();
            this.zipPayContext = new Mock<ZipPayContext>(param);
            this.zipPayContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()));
        }

        [Test]
        public async Task Should_Create_Payment_InstallementPlan()
        {
            var paymentDbSet = new Mock<DbSet<Payment>>();
            this.zipPayContext.Setup(x => x.Payment).Returns(paymentDbSet.Object);

            var payment = new Payment()
            {
                Id = 1,
                Amount = 2000,
                CreateDateTime = DateTimeOffset.UtcNow,
                InstallmentPlans = new List<InstallmentPlan>()
                {
                    new InstallmentPlan()
                    {
                        Id  = 2,
                        CreateDateTime = DateTimeOffset.UtcNow,
                        DueAmount = 2000,
                        DueDate = DateTimeOffset.UtcNow,
                        PaymentId = 1,
                    }
                }
            };

            var command = new CreatePaymentInstallmentPlanCommand(payment);

            var handler = new CreatePaymentInstallementPlanCommandHandler(this.zipPayContext.Object);

            var result = await handler.Handle(command, new CancellationToken());

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(1));
                this.zipPayContext.Verify(x => x.Payment.Add(It.IsAny<Payment>()), Times.Once());
                this.zipPayContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
            });
        }

        [Test]
        public async Task Should_Not_Create_Payment_InstallementPlan()
        {
            var paymentDbSet = new Mock<DbSet<Payment>>();

            this.zipPayContext.Setup(x => x.Payment).Returns(paymentDbSet.Object);

            var command = new CreatePaymentInstallmentPlanCommand(new Payment());

            var handler = new CreatePaymentInstallementPlanCommandHandler(this.zipPayContext.Object);

            var result = await handler.Handle(command, new CancellationToken());

            Assert.That(result, Is.EqualTo(0));
        }
    }
}