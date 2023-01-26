using AutoMapper;
using Zip.InstallmentsService.DomainObjects;
using Zip.InstallmentsService.Interface;
using ZipPayment.API.DataAccess.Entities;
using ZipPayment.API.DataAccess.Services;
using ZipPayment.API.Models;

namespace ZipPayment.API.Business.Services
{
    /// <summary>
    /// Payment service encapsulate the business logic and call repository to save object in to database
    /// </summary>
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentFactory _paymentFactory;
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor: Payment service encapsulate the business logic and call repository to save object in to database
        /// </summary>
        /// <param name="paymentFactory">paymentFactory</param>
        /// <param name="paymentRepository">paymentRepository</param>
        /// <param name="mapper">Imap business object to Dto object</param>
        public PaymentService(IPaymentFactory paymentFactory, IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentFactory = paymentFactory?? throw new ArgumentNullException(nameof(paymentFactory));
            _paymentRepository = paymentRepository ?? throw new ArgumentNullException(nameof(paymentRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// CreatePaymentPlan
        /// </summary>
        /// <param name="amount">amount</param>
        /// <param name="noOfInstalments">noOfInstalments</param>
        /// <param name="frequencyInWeeks">frequencyInWeeks</param>
        /// <returns>Task</returns>
        public async Task<PaymentPlanDto?> CreatePaymentPlan(decimal amount, int noOfInstalments, int frequencyInWeeks)
        {
            IPaymentPlanner paymentPlanner = _paymentFactory.CreatePaymentPlan(amount);
            IEnumerable<Installment> installments = paymentPlanner.GetPaymentPlan(noOfInstalments, frequencyInWeeks);

            var newPlanId = Guid.NewGuid();
            var installmentEntity = _mapper.Map<IEnumerable<Installment>, IEnumerable<InstallmentEntity>>(installments);
            var paymentPlanEntity = new PaymentPlanEntity(amount)
            {
                Id = newPlanId,
                PurchaseAmount = amount,
                Installments = (ICollection<InstallmentEntity>)installmentEntity
            };

            await _paymentRepository.AddPaymentPlan(paymentPlanEntity);
            if (!await _paymentRepository.SaveChangesAsync())
            {
                return null;
            }

            var newPaymentPlan = _mapper.Map<PaymentPlanEntity, PaymentPlanDto>(paymentPlanEntity);

            return newPaymentPlan;
        }

        /// <summary>
        /// GetAllPaymentPlansAsync
        /// </summary>
        /// <returns>List of PaymentPlanEntity</returns>
        public async Task<IEnumerable<PaymentPlanDto>> GetAllPaymentPlansAsync()
        {
            var paymentPlanEntities = await _paymentRepository.GetPaymentPlansAsync();
            var paymentPlans = _mapper.Map<IEnumerable<PaymentPlanEntity>, IEnumerable<PaymentPlanDto>>(paymentPlanEntities);
            return paymentPlans;
        }

        /// <summary>
        /// GetPaymentPlanAsync
        /// </summary>
        /// <param name="id">Guid</param>
        /// <returns>PaymentPlanEntity</returns>
        public async Task<PaymentPlanDto?> GetPaymentPlanAsync(Guid id)
        {
            var paymentPlanEntity = await _paymentRepository.GetPaymentPlanAsync(id);
            if (paymentPlanEntity == null)
                return null;

            var paymentPlan = _mapper.Map<PaymentPlanEntity, PaymentPlanDto>(paymentPlanEntity);
            return paymentPlan;
        }
    }
}
