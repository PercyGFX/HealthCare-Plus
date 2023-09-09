using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare_Plus.Controllers
{

    internal class patientsClass
    {
        // database object 
        Database dbManager = new Database();


        //////////// add patient //////////////////
        ///

        public bool InsertPatientData(
        string name,
        string age,
        string address,
        string phone,
        string bloodType,
        string description,
        string isActive)
        {

            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string insertQuery = "INSERT INTO patient (name, age, address, phone, blood_type, description, is_active) VALUES (@Name, @Age, @Address, @Phone, @BloodType, @Description, @IsActive)";

                using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                {
                    insertCommand.Parameters.AddWithValue("@Name", name);
                    insertCommand.Parameters.AddWithValue("@Age", age);
                    insertCommand.Parameters.AddWithValue("@Address", address);
                    insertCommand.Parameters.AddWithValue("@Phone", phone);
                    insertCommand.Parameters.AddWithValue("@BloodType", bloodType);
                    insertCommand.Parameters.AddWithValue("@Description", description);
                    insertCommand.Parameters.AddWithValue("@IsActive", isActive);

                    int rowsAffected = insertCommand.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }



    }
}
