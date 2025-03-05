using System.Data.SqlClient;
using System.Data;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Student_Registration.Models;

namespace Student_Registration.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly string connectionString;
        public LoginRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("connectionString");
        }

        public int LoginCheck(Logins login)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Logins WHERE Username = @Username AND SPassword = @SPassword";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@Username", login.Username);
                cmd.Parameters.AddWithValue("@SPassword", login.SPassword);

                connection.Open();
                int res = (int)cmd.ExecuteScalar(); // Returns 1 if valid, 0 if invalid

                return res;
            }
        }
    }
}
