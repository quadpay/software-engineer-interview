namespace Zip.Installments.QueryTest
{
    using Microsoft.EntityFrameworkCore;
    using Zip.Installments.Command.Commands;
    using Zip.Installments.Domain.Entities;
    using Zip.Installments.Infrastructure.Context;
    using Zip.Installments.Query.Queries;
    using static Zip.Installments.Command.Commands.CreatePaymentInstallementPlanCommand;
    using static Zip.Installments.Query.Queries.GetPaymentInstallementPlanByIdQuery;

    [TestFixture]
    public class GetPaymentInstallementPlanByIdQueryTest
    {
        private DbContextOptions<ZipPayContext> options;

        [SetUp]
        public void Setup()
        {
            options = new DbContextOptionsBuilder<ZipPayContext>()
           .UseInMemoryDatabase(databaseName: "temp_zippay", b => b.EnableNullChecks(false)).Options;
        }

        private static async Task Init(ZipPayContext zipPayContext)
        {
            zipPayContext.Database.EnsureDeleted();

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

            var command = new CreatePaymentInstallementPlanCommand(payment);
            var commandHandler = new CreatePaymentInstallementPlanCommandHandler(zipPayContext);
            await commandHandler.Handle(command, new CancellationToken());
        }

        [Test]
        [Order(1)]
        public async Task Should_Not_Get_PaymentInstallementPlan()
        {
            using (var context = new ZipPayContext(this.options))
            {
                var query = new GetPaymentInstallementPlanByIdQuery(1);

                var handler = new GetPaymentInstallementPlanByIdQueryHandler(context);

                var result = await handler.Handle(query, new CancellationToken());

                Assert.Multiple(() =>
                {
                    Assert.That(result?.FirstOrDefault()?.PaymentId, Is.Null);
                    Assert.That(result?.Count, Is.EqualTo(0));
                });
            }
        }

        [Test]
        [Order(2)]
        public async Task Should_Get_PaymentInstallementPlan()
        {
            using (var context = new ZipPayContext(this.options))
            {
                await Init(context);

                var query = new GetPaymentInstallementPlanByIdQuery(1);

                var handler = new GetPaymentInstallementPlanByIdQueryHandler(context);

                var result = await handler.Handle(query, new CancellationToken());

                Assert.Multiple(() =>
                {
                    Assert.That(result?.FirstOrDefault()?.PaymentId, Is.EqualTo(1));
                    Assert.That(result?.Count, Is.GreaterThan(0));
                });
            }
        }
    }
}