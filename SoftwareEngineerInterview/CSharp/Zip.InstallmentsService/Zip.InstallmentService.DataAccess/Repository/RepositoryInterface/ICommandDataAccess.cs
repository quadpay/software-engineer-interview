using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zip.InstallmentsService;

namespace InstallmentCalculationAPI.Repository.RepositoryInterface
{
    /// <summary>
    /// Interface for Command Responsibility segeregation
    /// </summary>
    public interface ICommandDataAccess
    {
        bool StorePaymentPlan(PaymentPlan paymentPlan);
    }
}
