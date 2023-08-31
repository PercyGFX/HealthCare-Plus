using HealthCare_Plus.Services;
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

namespace HealthCare_Plus.views.admin
{
    public partial class add_resource : UserControl
    {
        public add_resource()
        {
            InitializeComponent();
        }

        // database object 
        Database dbManager = new Database();

        private void btnadd_Click(object sender, EventArgs e)
        {
            string resourcename = txtresource.Text;
            string description = txtdescription.Text;

           
 

                using (MySqlConnection connection = dbManager.GetConnection())
                {
                    dbManager.OpenConnection(connection);

                    string insertQuery = "INSERT INTO resources (name, description) VALUES (@Name, @Description)";
                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Name", resourcename);
                    insertCommand.Parameters.AddWithValue("@Description", description);


                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Resource Record data added successfully.", "Success");

                            // Load back to the main form (adjust form name accordingly)
                            resources resources = new resources();
                            if (ParentForm is adminDashboard adminDashboard)
                            {
                                adminDashboard.loadform(resources);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to add appointment data.", "Error");
                        }
                    }
                }


                // code

            }
        

        private void add_resource_Load(object sender, EventArgs e)
        {

        }
    }
}
