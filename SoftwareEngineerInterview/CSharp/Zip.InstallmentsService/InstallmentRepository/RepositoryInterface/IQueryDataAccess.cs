using System.Data.SqlClient;

namespace InstallmentRepository.RepositoryInterface
{
    public interface IQueryDataAccess
    {
        SqlDataReader GetAllPaymentPlan(Guid guid, SqlConnection con);
    }
}
