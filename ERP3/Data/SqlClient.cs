using System.Data.SqlClient;

namespace ERP3.Data
{
    public class SqlClientHelper
    {
        private readonly string _connectionString;

        public SqlClientHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
