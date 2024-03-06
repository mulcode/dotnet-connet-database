using Npgsql;

namespace EmployeeData.DataAccessLayer 
{
    public class DataAccess
    {
        string connectionString = "Server=localhost;Port=5432;Database=learning;Username=postgres;Password=root";

        //DML
        //insert/update/delete
        public int ExecuteSql(string sql)
        {
            NpgsqlConnection connection = new NpgsqlConnection();
            connection.ConnectionString = connectionString;

            //opening connection to execute command
            connection.Open();

            NpgsqlCommand command = new NpgsqlCommand();
            command.CommandText = sql;
            command.Connection = connection;

            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            
            return rowAffected;

        }

        //DQL
    }
}