using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ST10038389_CLDV6211_PART2.Models
{
    public class ProductDisplayModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public bool ProductAvailability { get; set; }

        public ProductDisplayModel()
        {
        }

        public ProductDisplayModel(int id, string name, decimal price, string category, bool availability)
        {
            ProductID = id;
            ProductName = name;
            ProductPrice = price;
            ProductCategory = category;
            ProductAvailability = availability;
        }

        public static List<ProductDisplayModel> SelectProducts()
        {
            List<ProductDisplayModel> products = new List<ProductDisplayModel>();

            // Connection string to your SQL Server
            string connectionString = "Server=tcp:st10038389-db.database.windows.net,1433;Initial Catalog=CLDV6211-PART2;Persist Security Info=False;User ID=Luqmaan;Password=Cook123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";

            // SQL query to select products from the database
            string sqlQuery = "SELECT ProductID, ProductName, ProductPrice, ProductCategory, ProductAvailability FROM productTabel1";

            // Creating SqlConnection and SqlCommand objects
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                // Opening the connection
                connection.Open();

                // Executing the query
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Loop through the result set and populate products list
                    while (reader.Read())
                    {
                        ProductDisplayModel product = new ProductDisplayModel();
                        product.ProductID = Convert.ToInt32(reader["ProductID"]);
                        product.ProductName = Convert.ToString(reader["ProductName"]);
                        product.ProductPrice = Convert.ToDecimal(reader["ProductPrice"]);
                        product.ProductCategory = Convert.ToString(reader["ProductCategory"]);
                        product.ProductAvailability = Convert.ToBoolean(reader["ProductAvailability"]);
                        products.Add(product);
                    }
                }
            }

            return products;
        }
    }
}
