using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zip.InstallmentsService
{
    /// <summary>
    /// Interface for payment plan factory
    /// </summary>
    public interface IPaymentPlanFactory
    {
        PaymentPlan CreatePaymentPlan(InstallmentRequest installmentRequest);
    }
}
