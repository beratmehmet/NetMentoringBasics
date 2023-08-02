using System.Data;
using Microsoft.Data.SqlClient;

namespace ADONETLibrary
{
    public class ProductRepository
    {
        // SqlDataReader
        public List<ProductModel> GetProducts()
        {
            List<ProductModel> products = new();

            using (var connection = new SqlConnection(DBConfig.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT * FROM Product", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new ProductModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Description = reader.GetString(2),
                            Weight = reader.GetDouble(3),
                            Height = reader.GetDouble(4),
                            Width = reader.GetDouble(5),
                            Length = reader.GetDouble(6)
                        });
                    }
                }
            }

            return products;
        }

        // SqlDataAdapter and DataTable
        public DataTable GetAllProducts()
        {
            DataTable products = new();

            using (var connection = new SqlConnection(DBConfig.ConnectionString))
            using (SqlDataAdapter adapter = new("SELECT * FROM Product", connection))
            {
                adapter.Fill(products);
            }

            return products;
        }
    }
}
