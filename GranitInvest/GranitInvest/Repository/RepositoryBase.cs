using System.Data.SqlClient;
using System.Data.SQLite;

namespace GranitInvest.Repository
{
    public abstract class RepositoryBase
    {
        private const string DatabasePath = "../../Resources/Data/user_data.sqlite3";
        private const string ConnectionString = $"Data Source={DatabasePath}";

        protected SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }
    }
}
