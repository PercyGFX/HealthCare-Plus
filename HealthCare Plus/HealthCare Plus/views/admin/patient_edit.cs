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
using System.Xml.Linq;

namespace HealthCare_Plus.views.admin
{
    public partial class patient_edit : UserControl
    {
        private int patientId;
        private string initialName;
        private string initialAddress;
        private string initialPhone;
        private int initialAge;
        private string initialBloodType;
        private string initialDescription;

        // database object 
        Database dbManager = new Database();
        public patient_edit(int id, string name, string address, string phone, int age, string bloodType, string description)
        {
            InitializeComponent();

            // Initialize private fields with the provided patient data
            patientId = id;
            initialName = name;
            initialAddress = address;
            initialPhone = phone;
            initialAge = age;
            initialBloodType = bloodType;
            initialDescription = description;
     

            // Set the initial values of the form's controls using the provided data
            txtname.Text = initialName;
            txtaddress.Text = initialAddress;
            txtphone.Text = initialPhone;
            txtage.Text = initialAge.ToString();
            txtblood.Text = initialBloodType;
            rtextdescription.Text = initialDescription;
            
        }

        private void patient_edit_Load(object sender, EventArgs e)
        {

        }

        private void btnedit_Click(object sender, EventArgs e)
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
               

                using (MySqlConnection connection = dbManager.GetConnection())
                {
                    dbManager.OpenConnection(connection);

                    // Define the SQL UPDATE statement
string updateQuery = "UPDATE patient " +
                     "SET name = @Name, " +
                     "age = @Age, " +
                     "address = @Address, " +
                     "phone = @Phone, " +
                     "blood_type = @BloodType, " +
                     "description = @Description " +
                     "WHERE id = @PatientId";

using (MySqlCommand updateCommand = new MySqlCommand(updateQuery, connection))
{
    updateCommand.Parameters.AddWithValue("@Name", name);
    updateCommand.Parameters.AddWithValue("@Age", age);
    updateCommand.Parameters.AddWithValue("@Address", address);
    updateCommand.Parameters.AddWithValue("@Phone", phone);
    updateCommand.Parameters.AddWithValue("@BloodType", bloodType);
    updateCommand.Parameters.AddWithValue("@Description", description);
    updateCommand.Parameters.AddWithValue("@PatientId", patientId); // Use the patientId to specify which patient to update

    int rowsAffected = updateCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Patient data updated successfully.", "Success");

                            // Load back to the main form (adjust form name accordingly)
                            patients patients = new patients();
                            if (ParentForm is adminDashboard adminDashboard)
                            {
                                adminDashboard.loadform(patients);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to update patient data.", "Error");
                        }
                    }
                }
            }
        }
    }
}
