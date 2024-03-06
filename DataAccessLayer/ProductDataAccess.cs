using Npgsql;
using EmployeeData.Models;
namespace EmployeeData.DataAccessLayer
{
    public class ProductDataAccess
    {
        string connectionString = "Server=localhost;Port=5432;Database=learning;Username=postgres;Password=root";

        public List<Product> GetProducts()
        {
          string sql = "SELECT id,name, country FROM products";
          NpgsqlConnection connection = new NpgsqlConnection();
          connection.ConnectionString = connectionString;

          NpgsqlCommand command = new NpgsqlCommand();
          command.CommandText = sql;
          command.Connection = connection;

          connection.Open();

          NpgsqlDataReader reader = command.ExecuteReader();

          List<Product> products = new List<Product>();
          while(reader.Read())
          {
            Product product = new Product();
            product.Id = Convert.ToInt32(reader["id"]);
            product.Name = reader["name"].ToString();
            product.Country = reader["country"].ToString();

            products.Add(product); 
          }
          connection.Close();
          return products;
        }
    }
}