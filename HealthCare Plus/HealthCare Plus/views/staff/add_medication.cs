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
    public partial class add_medication : UserControl
    {
        public add_medication()
        {
            InitializeComponent();
        }

        // database object 
        Database dbManager = new Database();


        class Patient
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        // load patients

        private List<Patient> LoadPatientsFromDatabase()
        {
            List<Patient> patients = new List<Patient>();

            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string query = "SELECT id, name FROM patient";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patients.Add(new Patient
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name")
                            });
                        }
                    }
                }
            }

            return patients;
        }

        // get id from formatted text
        private int GetIdFromFormattedText(string formattedText)
        {
            // Split the formatted text by the separator character (assuming "-" here)
            string[] parts = formattedText.Split('-');

            if (parts.Length > 0)
            {
                // Try to parse the first part as an integer
                if (int.TryParse(parts[0].Trim(), out int id))
                {
                    return id;
                }
            }

            // Return -1 or throw an exception based on your needs if parsing fails
            return -1;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (AddMedicationValidations.IsValidFormFields(
                combopatient, 
                txtmedication.Text,
                date,
                txtcost.Text,
                rtextdescription.Text)) 
            {

                int patientId = GetIdFromFormattedText(combopatient.Text);
                string medication = txtmedication.Text.Trim();
                string Date = date.Value.ToString("yyyy-MM-dd");// Format the date properly
                string cost = txtcost.Text.Trim();
                string description = rtextdescription.Text.Trim();
                int InvoiceStatus = 0;

                using (MySqlConnection connection = dbManager.GetConnection())
                {
                    dbManager.OpenConnection(connection);

                    string insertQuery = "INSERT INTO meications (patient_id, medication, description,date, cost, InvoiceStatus) VALUES (@PatientId, @Medication, @Description, @Date, @Cost, @InvoiceStatus)";
                    using (MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@PatientId", patientId);
                        insertCommand.Parameters.AddWithValue("@Medication", medication);
                        insertCommand.Parameters.AddWithValue("@Description", description);
                        insertCommand.Parameters.AddWithValue("@Date", Date);
                        insertCommand.Parameters.AddWithValue("@Cost", cost);
                        insertCommand.Parameters.AddWithValue("@InvoiceStatus", InvoiceStatus);
      

                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Medication data added successfully.", "Success");

                            // Load back to the main form (adjust form name accordingly)
                            medications medications = new medications();
                            if (ParentForm is staffDashboard staffDashboard)
                            {
                                staffDashboard.loadform(medications);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to add appointment data.", "Error");
                        }
                    }
                }

            }
        }

        private void add_medication_Load(object sender, EventArgs e)
        {
            // Load patient data from the database
            List<Patient> patients = LoadPatientsFromDatabase();

            // Format data for display
            List<string> formattedPatientList = new List<string>();
            foreach (Patient patient in patients)
            {
                string formattedEntry = $"{patient.Id} - {patient.Name}";
                formattedPatientList.Add(formattedEntry);
            }

            // Populate the combopatient combo box
            combopatient.DataSource = formattedPatientList;

        }
    }
}
