using Oracle.ManagedDataAccess.Client;
using WebAppCap7.Helpers;

namespace WebAppCap7.Services
{
    public class UserService
    {
        private readonly OracleDbHelper _dbHelper;

        public UserService(OracleDbHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            const string query = "SELECT COUNT(*) FROM TB_USERS WHERE EMAIL = :Email AND PASSWORD = :Password";

            using (var connection = _dbHelper.GetConnection())
            {
                connection.Open();

                using (var command = new OracleCommand(query, connection as OracleConnection))
                {
                    command.Parameters.Add(new OracleParameter("Email", email));
                    command.Parameters.Add(new OracleParameter("Password", password));

                    var result = await command.ExecuteScalarAsync();
                    return Convert.ToInt32(result) > 0;
                }
            }
        }

        public async Task<string> GetUserRoleAsync(string email, string password)
        {
            const string query = "SELECT ROLE FROM TB_USERS WHERE EMAIL = :Email AND PASSWORD = :Password";

            using (var connection = _dbHelper.GetConnection())
            {
                connection.Open();

                using (var command = new OracleCommand(query, connection as OracleConnection))
                {
                    command.Parameters.Add(new OracleParameter("Email", email));
                    command.Parameters.Add(new OracleParameter("Password", password));

                    var result = await command.ExecuteScalarAsync();
                    return result?.ToString() ?? string.Empty;
                }
            }
        }
    }
}
