using Microsoft.EntityFrameworkCore;
using Xunit;
using Xunit.Sdk;
using ZipPayment.API.DataAccess.DbContexts;
using ZipPayment.API.DataAccess.Entities;
using ZipPayment.API.DataAccess.Services;

namespace Zip.InstallmentsService.Test
{
    public class PaymentRepositoryTests : IClassFixture<DatabaseFixture>
    {
        private DbContextOptionsBuilder<PaymentPlanContext> _optionBuilder;
        private DatabaseFixture _databaseFixture;
        private SQLitePaymentRepository _sqlRepository;
        private PaymentPlanContext _paymentPlanContext;

        public PaymentRepositoryTests(DatabaseFixture databaseFixture)
        {
            _databaseFixture = databaseFixture;
            _optionBuilder = new DbContextOptionsBuilder<PaymentPlanContext>().UseSqlite(_databaseFixture.SqlConnection);

            _paymentPlanContext = new PaymentPlanContext(_optionBuilder.Options);
            _paymentPlanContext.Database.Migrate();

            _sqlRepository = new SQLitePaymentRepository(_paymentPlanContext);
        }

        private async Task RemoveObjectFromInMemoryDatabase(PaymentPlanEntity paymentPlanEntity)
        {
            _paymentPlanContext.Remove(paymentPlanEntity);
            await _paymentPlanContext.SaveChangesAsync();
        }

        private async Task AddObjectInDatabase(PaymentPlanEntity paymentPlanEntity)
        {
            _paymentPlanContext.Add(paymentPlanEntity);
            await _paymentPlanContext.SaveChangesAsync();
        }

        [Fact]
        public async Task Given_SqlPaymentRepository_And_PaymentPlan_When_GetPaymentPlan_Retruns_PaymentPlan_FromInMemoryDatabase()
        {
            //Arrange

            var paymentPlanEntity = new PaymentPlanEntity(100M)
            {
                Installments = new InstallmentEntity[] { new InstallmentEntity(25M) }
            };
            //add entity in to database
            await AddObjectInDatabase(paymentPlanEntity);

            //Act
            var payments = await _sqlRepository.GetPaymentPlansAsync();
            if (payments == null)
            {
                throw new XunitException("Arranging the test failed.");
            }

            var paymentPlan = payments.FirstOrDefault();

            //Assert
            Assert.NotNull(paymentPlan);
            Assert.True(paymentPlan.Id == paymentPlanEntity.Id);
            Assert.True(paymentPlan.PurchaseAmount == paymentPlanEntity.PurchaseAmount);
            Assert.All(paymentPlan.Installments, t => Assert.True(t.Amount == 25M));
            Assert.All(paymentPlan.Installments, t => Assert.True(t.DueDate.Date == DateTime.Now.Date));

            await RemoveObjectFromInMemoryDatabase(paymentPlan);
        }

        [Fact]
        public async Task Given_SqlPaymentRepository_And_InvalidPaymentPlan_When_GetPaymentPlan_Retruns_PaymentPlan_FromInMemoryDatabase()
        {
            //Arrange

            var paymentPlanEntity = new PaymentPlanEntity(0M)
            {
                Installments = new InstallmentEntity[] { new InstallmentEntity(0M) }
            };

            //add entity in to database
            await AddObjectInDatabase(paymentPlanEntity);

            //Act
            var payments = await _sqlRepository.GetPaymentPlansAsync();
            if (payments == null)
            {
                throw new XunitException("Arranging the test failed.");
            }

            var paymentPlan = payments.SingleOrDefault();

            //Assert
            Assert.NotNull(paymentPlan);
            Assert.True(paymentPlan.Id == paymentPlanEntity.Id);
            Assert.True(paymentPlan.PurchaseAmount == paymentPlanEntity.PurchaseAmount);
            Assert.All(paymentPlan.Installments, t => Assert.True(t.Amount == 0M));
            Assert.All(paymentPlan.Installments, t => Assert.True(t.DueDate.Date == DateTime.Now.Date));

            await RemoveObjectFromInMemoryDatabase(paymentPlan);
        }
    }
}
