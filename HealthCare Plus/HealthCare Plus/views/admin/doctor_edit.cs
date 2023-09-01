using HealthCare_Plus.Services;
using HealthCare_Plus.views.staff;
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
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HealthCare_Plus.views.admin
{
    public partial class doctor_edit : UserControl
    {
        private int doctorId;
        private string doctorName;
        private string _age;
        private string _location;
        private string _phone;
        private string _email;
        private string _specialized;
        private string _qualifications;

        public doctor_edit(int id, string name, string age, string location, string phone, string email, string specialized, string qualifications)
        {
            InitializeComponent();



            // Store the doctor ID
            doctorId = id;

            // Use the provided values to populate your form controls
            _age = age;
            doctorName = name;
            _location = location;
            _phone = phone;
            _email = email;
            _specialized = specialized;
            _qualifications = qualifications;

        }

        // database object 
        Database dbManager = new Database();

        private void doctor_edit_Load(object sender, EventArgs e)
        {
            txtname.Text = doctorName;
            txtage.Text = _age;
            txtlocation.Text = _location;
            txtphone.Text = _phone;
            txtemail.Text = _email;
            txtspecialized.Text = _specialized;
            rtextqualifications.Text = _qualifications;
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
                    string updateQuery = "UPDATE doctor SET name = @Name, age = @Age, specialized_area = @Specialized, location = @Location, phone = @Phone, email = @Email, qualifications = @Qualifications WHERE id = @DoctorId";
                    using (MySqlCommand insertCommand = new MySqlCommand(updateQuery, connection))
                    {

                        insertCommand.Parameters.AddWithValue("@DoctorId", doctorId);

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
                            MessageBox.Show("Doctor data updated successfully.", "Success");

                            // load back the to the all doctors form

                            doctors doctors = new doctors();
                            if (ParentForm is adminDashboard adminDashboard)
                            {
                                adminDashboard.loadform(doctors);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to update doctor data.", "Error");
                        }
                    }
                }
            }
        }
    }
}
