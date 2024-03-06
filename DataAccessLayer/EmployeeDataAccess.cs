using EmployeeData.Models;
using Npgsql;

namespace EmployeeData.DataAccessLayer
{
    public class EmployeeDataAccess
    {
        string connectionString = "Server=localhost;Port=5432;Database=learning;Username=postgres;Password=root";

        public int Insert(Employee employee)
        {
            string sql = "INSERT INTO employees (id, name, age) VALUES ("+ employee.Id +", '" + employee.Name +"', "+ employee.Age +")";
            
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = connectionString;

            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandText = sql;
            command.Connection = connection;

            connection.Open();

            int rowAffected = command.ExecuteNonQuery();

            connection.Close();

            return rowAffected;
        }


       // Data Read from Database
        public List<Employee> GetEmployees()
        {
            string sql = "SELECT id, name, age FROM employees";
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = connectionString;

            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandText = sql;
            command.Connection = connection;

            connection.Open();

            NpgsqlDataReader reader = command.ExecuteReader();

            List<Employee> employees = new List<Employee>();

            while(reader.Read())
            {
                Employee employee = new Employee();

                employee.Id = Convert.ToInt32(reader["id"]);
                employee.Name = reader["name"].ToString();
                employee.Age = Convert.ToInt32(reader["age"]);

                employees.Add(employee);
            }

            connection.Close();

            return employees;
        }
    }
}