using System.Data.SqlClient;
using Zip.InstallmentsService;

namespace InstallmentCalculationAPI.Repository.RepositoryInterface
{
    /// <summary>
    /// Interface for Query Responsibility Segeregation repository
    /// </summary>
    public interface IQueryDataAccess
    {
        PaymentPlan GetAllPaymentPlan(Guid guid);
    }
}
