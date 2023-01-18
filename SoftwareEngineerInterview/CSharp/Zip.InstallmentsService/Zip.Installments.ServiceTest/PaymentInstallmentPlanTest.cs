namespace Zip.Installments.ServiceTest
{
    using Moq;
    using Zip.Installments.Contract.Request;
    using Zip.Installments.Domain.Entities;
    using Zip.InstallmentsService.Service;

    [TestFixture]
    public class PaymentInstallmentPlanTest
    {
        private PaymentInstallmentPlan paymentInstallmentPlan;

        [SetUp]
        public void Setup()
        {
            this.paymentInstallmentPlan = new PaymentInstallmentPlan();
        }

        [Test]
        public void Should_Create_PaymentPlan()
        {
            var paymentPlanRequest = new PaymentPlanRequest()
            {
                Amount = 1000,
                Frequency = 4,
                NumofInstallement = 4
            };

            var paymentPlan = this.paymentInstallmentPlan.CreatePaymentPlan(paymentPlanRequest);

            Assert.Multiple(() =>
            {
                Assert.That(paymentPlan, !Is.Null);
                Assert.That(paymentPlan.InstallmentPlans.Count, Is.GreaterThan(0));
                Assert.That(paymentPlan.InstallmentPlans?.FirstOrDefault()?.DueAmount, Is.EqualTo(250));
            });
        }

        [Test]
        public void Should_Not_Create_PaymentPlan()
        {

            var paymentPlanRequest = new PaymentPlanRequest() { };

            var paymentPlan = this.paymentInstallmentPlan.CreatePaymentPlan(paymentPlanRequest);

            Assert.That(paymentPlan, Is.Null);
        }
    }
}