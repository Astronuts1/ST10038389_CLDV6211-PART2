using System;
using System.Data.SqlClient;

namespace ST10038389_CLDV6211_PART2.Models
{
    public class LoginModel
    {
        private readonly string _connectionString = "Server=tcp:st10038389-db.database.windows.net,1433;Initial Catalog=CLDV6211-PART2;Persist Security Info=False;User ID=Luqmaan;Password=Cook123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        // Method to select user from database
        public int SelectUser(string email, string name)
        {
            int userId = -1;
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                string sql = "SELECT userID FROM userTable WHERE userEmail = @Email AND userName = @Name";

                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Name", name);

                    try
                    {
                        con.Open();
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            userId = Convert.ToInt32(result);
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"An error occurred: {ex.Message}");
                        throw;
                    }
                }
            }
            return userId;
        }
    }
}
