using System.Data.SqlClient;

namespace WindowsFormsApp1.database
{
    public sealed class Connection
    {
        static readonly string CONNECTION_INFO =
            @"Data Source=localhost;Initial Catalog=Csharp;User ID=admin;Password=admin";

        readonly SqlConnection SqlConnection;

        public Connection()
        {
            SqlConnection = new SqlConnection(CONNECTION_INFO);
            SqlConnection.Open();
        }

        public void close()
        {
            SqlConnection.Close();        
        }

        public SqlConnection GetSqlConnection()
        {
            return SqlConnection;
        }
    }
}