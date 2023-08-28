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
    public partial class doctoravailability : UserControl
    {

        // database object 
        Database dbManager = new Database();

        private int _doctorId;
        private DateTime _selectedDate;

        public doctoravailability(int doctorId, DateTime selectedDate)
        {
            InitializeComponent();
            _doctorId = doctorId;
            _selectedDate = selectedDate;

            // Use _doctorId and _selectedDate as needed in the form
        }

        //load doctor data to grid if appoinment available

        private void LoadDataToDoctorGridView(int doctorId, DateTime selectedDate)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT a.id, d.name AS DoctorName, p.name AS PatientName, a.description, a.date, a.time, a.isactive, a.cost " +
                                     "FROM appoiment a " +
                                     "INNER JOIN doctor d ON a.doctor_id = d.id " +
                                     "INNER JOIN patient p ON a.patient_id = p.id " +
                                     "WHERE d.id = @DoctorId AND a.date = @SelectedDate";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@DoctorId", doctorId);
                    cmd.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Clear existing data in the doctorgridview
                        doctorgridview.Rows.Clear();

                        doctorpanel.Visible = true;
                        lbldoctoravailability.Text = "Doctor Appointments Available on " + selectedDate.ToString("yyyy-MM-dd");


                        doctorgridview.Columns.Add("AppointmentId", "Appointment ID");
      
                        doctorgridview.Columns.Add("PatientName", "Patient Name");
                        doctorgridview.Columns.Add("Description", "Description");
                        doctorgridview.Columns.Add("Date", "Date");
                        doctorgridview.Columns.Add("Time", "Time");
                        doctorgridview.Columns.Add("IsActive", "Is Active");
                        doctorgridview.Columns.Add("Cost", "Cost");

                        while (reader.Read())
                        {
                            // Retrieve appointment data from the reader
                            int appointmentId = Convert.ToInt32(reader["id"]);
                           
                            string patientName = reader["PatientName"].ToString();
                            string description = reader["description"].ToString();
                            DateTime appointmentDate = Convert.ToDateTime(reader["date"]);
                            string appointmentTime = reader["time"].ToString();
                            string isActive = reader["isactive"].ToString();
                            decimal cost = Convert.ToDecimal(reader["cost"]);

                            // Add the appointment data to the doctorgridview
                            doctorgridview.Rows.Add(appointmentId, patientName, description, appointmentDate, appointmentTime, isActive, cost);
                        }
                    }
                }
            }
        }

        //load doctor data

        private void LoadDoctorData(int doctorId, DateTime selectedDate)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT * FROM doctor WHERE id = @DoctorId";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@DoctorId", doctorId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve the data from the reader and populate the form controls
                            string name = reader["name"].ToString();
                            int age = Convert.ToInt32(reader["age"]);
                            string location = reader["location"].ToString();
                            string phone = reader["phone"].ToString();
                            string email = reader["email"].ToString();
                            string specialized_area = reader["specialized_area"].ToString();
                            string qualifications = reader["qualifications"].ToString();

                            // ... retrieve other columns

                            // Populate the form controls with the retrieved data
                            lblname.Text = name;
                            lblage.Text = age.ToString();
                            lbllocation.Text = location;
                            lblphone.Text = phone;
                            lblemail.Text = email;
                            lblspecialized.Text = specialized_area;
                            lblqualifications.Text = qualifications;

                            // ... set other controls
                          
                        }
                    }
                }
            }
        }


        private void LoadDoctorAppoinments(int doctorId, DateTime selectedDate)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);
                // Now check if there are records for the selected date
                string availabilityQuery = "SELECT COUNT(*) FROM appoiment WHERE doctor_id = @DoctorId AND date = @SelectedDate";
                using (MySqlCommand availabilityCmd = new MySqlCommand(availabilityQuery, connection))
                {
                    availabilityCmd.Parameters.AddWithValue("@DoctorId", doctorId);
                    availabilityCmd.Parameters.AddWithValue("@SelectedDate", selectedDate);

                    int recordCount = Convert.ToInt32(availabilityCmd.ExecuteScalar());

                    if (recordCount > 0)
                    {
                        // Records exist, load data to doctorgridview
                        LoadDataToDoctorGridView(doctorId, selectedDate);
                    }
                    else
                    {
                        lbldoctoravailability.Text = "Doctor Has no Appointments & Available on " + selectedDate.ToString("yyyy-MM-dd");
                    }
                }
            }
        }


        private void doctoravailability_Load(object sender, EventArgs e)
        {
            LoadDoctorData(_doctorId, _selectedDate);
            LoadDoctorAppoinments(_doctorId, _selectedDate);
        }
    }
}
