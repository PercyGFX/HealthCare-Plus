using HealthCare_Plus.Services;
using HealthCare_Plus.views.admin;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCare_Plus.views.staff
{
    public partial class allowcate_room : UserControl
    {

        // database object 
        Database dbManager = new Database();

       
        public allowcate_room()
        {
            InitializeComponent();
        }

        //load rooms and patients

        private void LoadPatientsToComboBox()
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT id, name FROM patient";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string formattedEntry = $"{reader["id"]} - {reader["name"]}";
                            combopatient.Items.Add(formattedEntry);
                        }
                    }
                }
            }
        }

        private void LoadRoomsToComboBox()
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT id, room_name FROM rooms WHERE availability = 1"; // Only select rooms where availability is 1

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string formattedEntry = $"{reader["id"]} - {reader["room_name"]}";
                            comboroom.Items.Add(formattedEntry);
                        }
                    }
                }
            }
        }

        private void allowcate_room_Load(object sender, EventArgs e)
        {
            LoadPatientsToComboBox();
            LoadRoomsToComboBox();


        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (RoomAllowcations.IsValidFormFields(combopatient, comboroom, date, txtcost.Text.Trim()))
            {
                using (MySqlConnection connection = dbManager.GetConnection())
                {
                    dbManager.OpenConnection(connection);

                    // Extract patient id and room id from the selected combo box items
                    int patientId = int.Parse(combopatient.SelectedItem.ToString().Split('-')[0].Trim());
                    int roomId = int.Parse(comboroom.SelectedItem.ToString().Split('-')[0].Trim());

                    // Create and execute the database query to insert the data
                    string insertQuery = "INSERT INTO room_allowcation (patient_id, room_id, admit_date, cost, InvoiceStatus) VALUES (@PatientId, @RoomId, @AdmitDate, @Cost, @InvoiceStatus)";
                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@PatientId", patientId);
                        insertCommand.Parameters.AddWithValue("@RoomId", roomId);
                        insertCommand.Parameters.AddWithValue("@AdmitDate", date.Value);
                        insertCommand.Parameters.AddWithValue("@Cost", txtcost.Text.Trim());
                        insertCommand.Parameters.AddWithValue("@InvoiceStatus", 0);

                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Update the availability of the room to 0
                            string updateQuery = "UPDATE rooms SET availability = 0 WHERE id = @RoomId";
                            using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
                            {
                                updateCommand.Parameters.AddWithValue("@RoomId", roomId);
                                updateCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show("Room allocation added successfully.", "Success");

                            // Load back to the main form (adjust form name accordingly)
                            rooms rooms = new rooms();
                            if (ParentForm is staffDashboard staffDashboard)
                            {
                                staffDashboard.loadform(rooms);
                            }


                        }
                        else
                        {
                            MessageBox.Show("Failed to add room allocation.", "Error");
                        }
                    }
                }
            }

        }
    }
}
