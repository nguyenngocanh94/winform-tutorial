using System.Data;
using System.Data.SqlClient;
using WindowsFormsApp1.database;
using WindowsFormsApp1.IoC;

namespace WindowsFormsApp1.Authentication
{
    public class Shield
    {    
        public bool auth(Credential credential)
        {
            var Container = DependencyContainer.getInstance();
            Connection connection = Container.Resolve<Connection>("WindowsFormsApp1.database.Connection");

            string sql = "SELECT count(id) FROM users WHERE username= @username and password=@password";
            using (SqlCommand sqlCommand = new SqlCommand(sql,connection.GetSqlConnection()))
            {
                sqlCommand.Parameters
                    .AddWithValue("@username", credential.getUsername());
                sqlCommand.Parameters.AddWithValue("@password", credential.getPassword());
                SqlDataAdapter ad = new SqlDataAdapter(sqlCommand); 
                DataTable dt = new DataTable();  
                ad.Fill(dt);
                if (dt.Rows.Count > 0 )
                {
                    return true;
                }

                return false;
            }
        }
    }
}