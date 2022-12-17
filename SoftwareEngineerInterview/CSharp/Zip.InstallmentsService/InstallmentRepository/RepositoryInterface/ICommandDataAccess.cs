using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService;

namespace InstallmentRepository.RepositoryInterface
{
    public interface ICommandDataAccess
    {
        bool StorePaymentPlan(PaymentPlan paymentPlan, SqlConnection con);
        protected bool StoreInstallmentDetails(List<Installment> installments, Guid paymentPlanId, SqlConnection con);
    }
}
