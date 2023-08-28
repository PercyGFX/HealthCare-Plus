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
    public partial class discharge : UserControl
    {
        // database object 
        Database dbManager = new Database();

        private int _allocationid;
        private string _room;

        public discharge(int allocationid, string room)
        {
            InitializeComponent();
            _allocationid = allocationid;
            _room = room;

            // You can perform any additional setup or loading of data based on the room ID and value here
        }

        private void discharge_Load(object sender, EventArgs e)
        {
            lbldischarge.Text = "Do you want to discharge the patient in room " + _room;

        }

        private void btndischarge_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                // Update discharge_date in room_allowcation
                string updateDischargeQuery = "UPDATE room_allowcation SET discharge_date = @DischargeDate WHERE id = @AllocationId";
                using (MySqlCommand updateDischargeCommand = new MySqlCommand(updateDischargeQuery, connection))
                {
                    updateDischargeCommand.Parameters.AddWithValue("@DischargeDate", date.Value);
                    updateDischargeCommand.Parameters.AddWithValue("@AllocationId", _allocationid);

                    int dischargeRowsAffected = updateDischargeCommand.ExecuteNonQuery();

                    if (dischargeRowsAffected > 0)
                    {
                        // Update availability in rooms table
                        string updateAvailabilityQuery = "UPDATE rooms SET availability = 1 WHERE room_name = @RoomName";
                        using (MySqlCommand updateAvailabilityCommand = new MySqlCommand(updateAvailabilityQuery, connection))
                        {
                            updateAvailabilityCommand.Parameters.AddWithValue("@RoomName", _room);

                            int availabilityRowsAffected = updateAvailabilityCommand.ExecuteNonQuery();

                            if (availabilityRowsAffected > 0)
                            {
                                MessageBox.Show("Discharge successful.", "Success");
                                // Close the form or perform any other necessary actions
                                connection.Close();

                                // Load back to the main form (adjust form name accordingly)
                                booked_rooms booked_rooms = new booked_rooms();
                                if (ParentForm is staffDashboard staffDashboard)
                                {
                                    staffDashboard.loadform(booked_rooms);
                                }

                            }
                            else
                            {
                                MessageBox.Show("Failed to update room availability.", "Error");
                            }
                        }
                    }
                   
                }
            }


        }
    }
}
