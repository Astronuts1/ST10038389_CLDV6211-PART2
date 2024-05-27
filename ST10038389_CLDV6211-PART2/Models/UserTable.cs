using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ST10038389_CLDV6211_PART2.Models
{
    public class UserTable
    {
        private static readonly string connectionString = "Server=tcp:st10038389-db.database.windows.net,1433;Initial Catalog=CLDV6211-PART2;Persist Security Info=False;User ID=Luqmaan;Password=Cook123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        public int InsertUser(UserTable user)
        {
            try
            {
                string sql = "INSERT INTO userTable (userName, userSurname, userEmail) VALUES (@Name, @Surname, @Email)";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", user.Name);
                        cmd.Parameters.AddWithValue("@Surname", user.Surname);
                        cmd.Parameters.AddWithValue("@Email", user.Email);

                        con.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error inserting user", ex);
            }
        }

        public List<UserTable> GetAllUsers()
        {
            try
            {
                string sql = "SELECT userName, userSurname, userEmail FROM userTable1";
                List<UserTable> users = new List<UserTable>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UserTable user = new UserTable
                                {
                                    Name = reader["userName"].ToString(),
                                    Surname = reader["userSurname"].ToString(),
                                    Email = reader["userEmail"].ToString()
                                };
                                users.Add(user);
                            }
                        }
                    }
                }
                return users;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving users", ex);
            }
        }

        public string Name { get; set; } // Getters + Setters for UserName
        public string Surname { get; set; } // Getters + Setters for UserSurname
        public string Email { get; set; } // Getters + Setters for UserEmail
    }
}
