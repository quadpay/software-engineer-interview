using ZipPayment.API.DataAccess.Entities;
using ZipPayment.API.DataAccess.Services;

namespace Zip.InstallmentsService.Test.Services
{
    internal class TestDataPaymentRepository : IPaymentRepository
    {
        private readonly List<PaymentPlanEntity> _paymentPlans;
        private readonly List<InstallmentEntity> _installments;

        public TestDataPaymentRepository()
        {
            _paymentPlans = new List<PaymentPlanEntity>();
            _installments = new List<InstallmentEntity>();

            //mimic expensive creation process
            Thread.Sleep(3000);
        }
        public Task AddPaymentPlan(PaymentPlanEntity paymentPlan)
        {
            _paymentPlans.Add(paymentPlan);
            return Task.FromResult(0);
        }

        public Task<InstallmentEntity?> GetInstallmentAsync(Guid id)
        {
            return Task.FromResult(_installments.FirstOrDefault(t => t.Id == id));
        }

        public Task<IEnumerable<InstallmentEntity>> GetInstallmentsAsync()
        {
            return Task.FromResult(_installments.AsEnumerable());
        }

        public Task<PaymentPlanEntity?> GetPaymentPlanAsync(Guid id)
        {
            return Task.FromResult(_paymentPlans.FirstOrDefault(t => t.Id == id));
        }

        public Task<IEnumerable<PaymentPlanEntity>> GetPaymentPlansAsync()
        {
            return Task.FromResult(_paymentPlans.AsEnumerable());
        }

        public Task<bool> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
