using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace ST10038389_CLDV6211_PART2.Controllers
{
    public class TransactionController : Controller
    {
        private readonly string _connectionString = "Server=tcp:st10038389-db.database.windows.net,1433;Initial Catalog=CLDV6211-PART2;Persist Security Info=False;User ID=Luqmaan;Password=Cook123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

        [HttpPost]
        public ActionResult PlaceOrder(int userID, int productID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    string sql = "INSERT INTO transactionTable (userID, productID) VALUES (@UserID, @ProductID)";
                    // User entering details into the transaction table.

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        // Adding Parameters for both UserID and ProductID to pass the data through.
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@ProductID", productID);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery(); // Outputs the Query of data.
                        con.Close();

                        if (rowsAffected > 0) // Checks if the Order was successfully Ordered
                        {
                            return RedirectToAction("Index", "Home"); // Sends the user back to home page.
                        }
                        else
                        {
                            return View("OrderFailed");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (ex) for debugging or auditing purposes.
                return View("Error");
            }
        }
    }
}
