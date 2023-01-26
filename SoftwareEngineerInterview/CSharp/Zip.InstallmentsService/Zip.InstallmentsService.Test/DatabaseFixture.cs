using Microsoft.Data.Sqlite;

namespace Zip.InstallmentsService.Test
{
    /// <summary>
    /// Database fixture
    /// </summary>
    public class DatabaseFixture : IDisposable
    {
        public DatabaseFixture()
        {
            SqlConnection = new SqliteConnection("Data Source=:memory:");
            SqlConnection.Open();
        }

        public void Dispose()
        {
            if (SqlConnection != null)
                SqlConnection.Dispose();
        }

        public SqliteConnection SqlConnection { get; private set; }
    }
}
