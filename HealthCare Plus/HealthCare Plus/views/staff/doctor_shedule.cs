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
    public partial class doctor_shedule : UserControl
    {

        // database object 
        Database dbManager = new Database();
        public doctor_shedule()
        {
            InitializeComponent();
        }


        class Doctor
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
        //get doctor id

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

        //load doctors 
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

        private void doctor_shedule_Load(object sender, EventArgs e)
        {
            // Load doctor data from the database and populate combodoctor
            List<Doctor> doctors = LoadDoctorsFromDatabase();
            foreach (Doctor doctor in doctors)
            {
                string formattedEntry = $"{doctor.Id} - {doctor.Name}";
                combodoctor.Items.Add(formattedEntry);
                
            }

            combodoctor.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combodoctor.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void btnavailability_Click(object sender, EventArgs e)
        {
            if (combodoctor.SelectedItem != null && date.Value != null)
            {
                string selectedFormattedEntry = combodoctor.SelectedItem.ToString();
                int doctorId = GetIdFromFormattedText(selectedFormattedEntry); // Use your method to extract ID from formatted text
                DateTime selectedDate = date.Value;

                doctoravailability doctoravailability = new doctoravailability(doctorId, selectedDate);
             
                if (ParentForm is staffDashboard staffDashboard)
                {
                    staffDashboard.loadform(doctoravailability);
                }
            }
            else
            {
                MessageBox.Show("Please select a doctor and a date.", "Error");
            }
        }
    }
}
