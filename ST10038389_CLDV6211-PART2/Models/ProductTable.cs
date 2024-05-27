using System.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace ST10038389_CLDV6211_PART2.Models
{
    public class ProductTable
    {
        private static readonly string connectionString = "Server=tcp:st10038389-db.database.windows.net,1433;Initial Catalog=CLDV6211-PART2;Persist Security Info=False;User ID=Luqmaan;Password=Cook123@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
        internal static string con_string;

        public int InsertProduct(ProductTable product)
        {
            try
            {
                string sql = "INSERT INTO productTable (productName, productPrice, productCategory, productAvailability) VALUES (@Name, @Price, @Category, @Availability)";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", product.Name);
                        cmd.Parameters.AddWithValue("@Price", product.Price);
                        cmd.Parameters.AddWithValue("@Category", product.Category);
                        cmd.Parameters.AddWithValue("@Availability", product.Availability);

                        con.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error inserting product", ex);
            }
        }

        public static List<ProductTable> GetAllProducts()
        {
            try
            {
                List<ProductTable> products = new List<ProductTable>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sql = "SELECT * FROM productTable";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        con.Open();

                        using (SqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                ProductTable product = new ProductTable
                                {
                                    ProductID = Convert.ToInt32(rdr["productID"]),
                                    Name = rdr["productName"].ToString(),
                                    Price = rdr["productPrice"].ToString(),
                                    Category = rdr["productCategory"].ToString(),
                                    Availability = rdr["productAvailability"].ToString()
                                };
                                products.Add(product);
                            }
                        }
                    }
                }
                return products;
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving products", ex);
            }
        }

        internal int InsertProduct()
        {
            throw new NotImplementedException();
        }

        public int ProductID { get; set; } // Getters + Setters for ProductID
        public string Name { get; set; } // Getters + Setters for Name (Product Name)
        public string Price { get; set; } // Getters + Setters for Price
        public string Category { get; set; } // Getters + Setters for Category
        public string Availability { get; set; } // Getters + Setters for Availability
    }

}
