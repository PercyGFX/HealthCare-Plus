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
    public partial class add_doctor : UserControl
    {

        // database object 
        Database dbManager = new Database();

        public add_doctor()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (AddDoctorValidations.IsValidFormFields(
                    txtname.Text.Trim(),
                    txtage.Text.Trim(),
                    txtlocation.Text.Trim(),
                    txtphone.Text.Trim(),
                    txtemail.Text.Trim(),
                    txtspecialized.Text.Trim(),
                    rtextqualifications.Text.Trim()))
            {
                string name = txtname.Text.Trim();
                string age = txtage.Text.Trim();
                string location = txtlocation.Text.Trim();
                string phone = txtphone.Text.Trim();
                string email = txtemail.Text.Trim();
                string specialized = txtspecialized.Text.Trim();
                string qualifications = rtextqualifications.Text.Trim();

                using (MySqlConnection connection = dbManager.GetConnection())
                {
                    dbManager.OpenConnection(connection);

                    // Create and execute the database query to insert the data
                    string insertQuery = "INSERT INTO doctor (name, age, specialized_area, location, phone, email, qualifications) VALUES (@Name, @Age, @Specialized, @Location, @Phone, @Email, @Qualifications)";
                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Name", name);
                        insertCommand.Parameters.AddWithValue("@Age", age);
                        insertCommand.Parameters.AddWithValue("@Specialized", specialized);
                        insertCommand.Parameters.AddWithValue("@Location", location);
                        insertCommand.Parameters.AddWithValue("@Phone", phone);
                        insertCommand.Parameters.AddWithValue("@Email", email);
                        insertCommand.Parameters.AddWithValue("@Qualifications", qualifications);

                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Doctor data added successfully.", "Success");

                            // load back the to the all doctors form

                            doctors doctors = new doctors();
                            if (ParentForm is adminDashboard adminDashboard)
                            {
                                adminDashboard.loadform(doctors);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to add doctor data.", "Error");
                        }
                    }
                }
            }
        }

        private void add_doctor_Load(object sender, EventArgs e)
        {

        }
    }
}
