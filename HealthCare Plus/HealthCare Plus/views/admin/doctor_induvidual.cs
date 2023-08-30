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
    public partial class doctor_induvidual : UserControl
    {
        //receive the doctor id
        private int doctorId;

        // database object 
        Database dbManager = new Database();

        ///
        /// 

        public doctor_induvidual(int selectedDoctorId)
        {
            InitializeComponent();

            // Store the selected doctor's ID
            doctorId = selectedDoctorId;
        }

        /// <param name="doctorId"></param>

        // load induvidual dcotr data

        private void LoadDoctorData(int doctorId)
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


        public doctor_induvidual()
        {
            InitializeComponent();
        }

        public void LoadDoctorSchedule(int doctorId)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT a.id, p.name AS PatientName, a.description, a.date, a.time, a.cost " +
                     "FROM appoiment a " +
                     "INNER JOIN patient p ON a.patient_id = p.id " +
                     "WHERE a.doctor_id = @DoctorId";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@DoctorId", doctorId);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        doctorgridview.DataSource = dataTable;
                    }
                }
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {

        }

        private void doctor_induvidual_Load(object sender, EventArgs e)
        {
            LoadDoctorData(doctorId);
            LoadDoctorSchedule(doctorId);
        }
    }
}
