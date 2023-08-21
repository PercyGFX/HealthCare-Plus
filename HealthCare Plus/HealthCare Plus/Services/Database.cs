using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HealthCare_Plus
{
    internal class Database

    {

        //mysql database connection

        private string connectionString = "server=localhost;database=healthcare;user=root;password=;";

        public MySqlConnection GetConnection()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            return connection;
        }

        public void OpenConnection(MySqlConnection connection)
        {
            try
            {
                connection.Open();
                Console.WriteLine("Database connection established successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }
}
