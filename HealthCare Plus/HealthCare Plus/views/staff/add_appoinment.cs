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

    public partial class add_appoinment : UserControl
    {
        // database object 
        Database dbManager = new Database();

        class Patient
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        class Doctor
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        // Example method to load patient data from the database
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

        //load doctors from database

        private List<Doctor> LoadDoctorsFromDatabase()
        {
            List<Doctor> doctors = new List<Doctor>();

            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string query = "SELECT id, name FROM doctor";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            doctors.Add(new Doctor
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name")
                            });
                        }
                    }
                }
            }

            return doctors;
        }

        public add_appoinment()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {

            if (AddAppointmentValidations.IsValidFormFields(
             combopatient,
             combodoctor,
             date,
             txtcost.Text.Trim(),
             rtextdescription.Text.Trim()))
            {
                // Proceed with processing the form data
            }

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void add_appoinment_Load(object sender, EventArgs e)
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

            // Load doctor data from the database and populate combodoctor
            List<Doctor> doctors = LoadDoctorsFromDatabase();
            foreach (Doctor doctor in doctors)
            {
                string formattedEntry = $"{doctor.Id} - {doctor.Name}";
                combodoctor.Items.Add(formattedEntry);
            }
        }
    }
}
