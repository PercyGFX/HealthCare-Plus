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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace HealthCare_Plus.views.admin
{
    public partial class add_room : UserControl
    {
        public add_room()
        {
            InitializeComponent();
        }

        // database object 
        Database dbManager = new Database();


        private void btnadd_Click(object sender, EventArgs e)
        {

            string roomname = txtroomname.Text;
            string roomtype = comboroomtype.Text;
            int availability = 1; // hardcode with 1

            // Validate input
            if (string.IsNullOrWhiteSpace(roomname))
            {
                MessageBox.Show("Please enter a room name.", "Validation Error");
                return; // Exit the method if validation fails
            }

            if (string.IsNullOrWhiteSpace(roomtype))
            {
                MessageBox.Show("Please select a room type.", "Validation Error");
                return; // Exit the method if validation fails
            }

            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                // Create and execute the database query to insert the data
                string insertQuery = "INSERT INTO rooms (room_name, room_type, availability) VALUES (@Room_Name, @Room_Type, @Availability)";
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Room_Name", roomname);
                    cmd.Parameters.AddWithValue("@Room_Type", roomtype);
                    cmd.Parameters.AddWithValue("@Availability", availability);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Room data added successfully.", "Success");

                        // Load back to the main form 
                        rooms rooms = new rooms();
                        if (ParentForm is adminDashboard adminDashboard)
                        {
                            adminDashboard.loadform(rooms);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to add room data.", "Error");
                    }
                }
            }



        }
    }
}
