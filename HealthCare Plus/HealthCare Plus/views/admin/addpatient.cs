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
    public partial class addpatient : UserControl
    {
        // database object 
        Database dbManager = new Database();

        public addpatient()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (AddPatientValidations.IsValidFormFields(
                 txtname.Text.Trim(),
                 txtage.Text.Trim(),
                 txtaddress.Text.Trim(),
                 txtphone.Text.Trim(),
                 txtblood.Text.Trim(),
                 rtextdescription.Text.Trim()))
            {
                string name = txtname.Text.Trim();
                string age = txtage.Text.Trim();
                string address = txtaddress.Text.Trim();
                string phone = txtphone.Text.Trim();
                string bloodType = txtblood.Text.Trim();
                string description = rtextdescription.Text.Trim();
                string isActive = "Active"; // Hardcoded "Active"

                using (MySqlConnection connection = dbManager.GetConnection())
                {
                    dbManager.OpenConnection(connection);

                    // Create and execute the database query to insert the data
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
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Patient data added successfully.", "Success");

                            // Load back to the main form (adjust form name accordingly)
                            patients patients = new patients();
                            if (ParentForm is adminDashboard adminDashboard)
                            {
                                adminDashboard.loadform(patients);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to add patient data.", "Error");
                        }
                    }
                }
            }
        }
    }
}
