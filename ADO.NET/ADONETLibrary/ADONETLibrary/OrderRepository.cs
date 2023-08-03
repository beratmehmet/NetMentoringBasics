using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONETLibrary
{
    public class OrderRepository
    {
        private readonly ProductRepository _productRepository;
        public OrderRepository(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public int CreateOrder(OrderModel order)
        {
            int id = 0;

            using (var connection = new SqlConnection(DBConfig.ConnectionString))
            {
                string queryString = "INSERT INTO \"Order\" " +
                                        "(Status, CreatedDate, UpdatedDate, ProductId) Values(@Status, @CreatedDate, @UpdatedDate, @ProductId);"
                                        + "SELECT CAST(scope_identity() AS int)";
                SqlCommand command = new SqlCommand(queryString, connection);

                SqlParameter sqlParameter = command.Parameters.Add("@Status", SqlDbType.NVarChar, 50);
                sqlParameter.Value = order.Status;

                sqlParameter = command.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                sqlParameter.Value = order.CreatedDate;

                sqlParameter = command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime);
                sqlParameter.Value = order.UpdatedDate;

                sqlParameter = command.Parameters.Add("@ProductId", SqlDbType.Int);
                sqlParameter.Value = order.product.Id;

                try
                {
                    connection.Open();
                    id = (int)command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }


            return id;
        }

        public void UpdateOrder(OrderModel order)
        {
            using (var connection = new SqlConnection(DBConfig.ConnectionString))
            {
                string queryString = "Update \"Order\" SET Status = @Status, CreatedDate = @CreatedDate, UpdatedDate = @UpdatedDate, ProductId = @ProductId " +
                                    "Where Id = @Id";
                SqlCommand command = new SqlCommand(queryString, connection);

                SqlParameter sqlParameter = command.Parameters.Add("@Status", SqlDbType.NVarChar, 50);
                sqlParameter.Value = order.Status;

                sqlParameter = command.Parameters.Add("@CreatedDate", SqlDbType.DateTime);
                sqlParameter.Value = order.CreatedDate;

                sqlParameter = command.Parameters.Add("@UpdatedDate", SqlDbType.DateTime);
                sqlParameter.Value = DateTime.Now;

                sqlParameter = command.Parameters.Add("@ProductId", SqlDbType.Int);
                sqlParameter.Value = order.product.Id;

                sqlParameter = command.Parameters.Add("@Id", SqlDbType.Int);
                sqlParameter.Value = order.Id;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

        public void DeleteOrder(int id)
        {
            string queryString = "DELETE FROM \"Order\" Where Id = @Id";

            using (var connection = new SqlConnection(DBConfig.ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                SqlParameter sqlParameter = command.Parameters.Add("@Id", SqlDbType.Int);
                sqlParameter.Value = id;

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public OrderModel GetOrder(int id)
        {
            OrderModel order;

            string queryString = "SELECT * FROM \"Order\" Where Id = @Id";

            using (var connection = new SqlConnection(DBConfig.ConnectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    SqlParameter sqlParameter = command.Parameters.Add("@Id", SqlDbType.Int);
                    sqlParameter.Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();

                        order = new OrderModel
                        {
                            Id = reader.GetInt32(0),
                            Status = reader.GetString(1),
                            CreatedDate = reader.GetDateTime(2),
                            UpdatedDate = reader.GetDateTime(3),
                            product = _productRepository.GetProduct(reader.GetInt32(4))
                        };

                    }
                }
                return order;
            }
        }
    }
}
