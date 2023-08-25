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
    public partial class doctors : UserControl
    {

        

        // database object 
        Database dbManager = new Database();


        //load doctors to data gridview
        private void LoadDoctorData(string searchText = null)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT id, name, age, specialized_area, location, phone, email, qualifications FROM doctor"; // Default query for loading all data

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    selectQuery += $" WHERE id LIKE '%{searchText}%' OR name LIKE '%{searchText}%' OR age LIKE '%{searchText}%' OR specialized_area LIKE '%{searchText}%' OR location LIKE '%{searchText}%' OR phone LIKE '%{searchText}%' OR email LIKE '%{searchText}%' OR qualifications LIKE '%{searchText}%'";
                }

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    doctorgridview.DataSource = dataTable;
                }
            }
        }


        public doctors()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedDoctorId = Convert.ToInt32(doctorgridview.Rows[e.RowIndex].Cells["id"].Value);

                doctor_induvidual doctor_induvidual = new doctor_induvidual(selectedDoctorId);
                if (ParentForm is adminDashboard adminDashboard)
                {
                    adminDashboard.loadform(doctor_induvidual);
                }

                
                
            }
        }

        private void orders_Click(object sender, EventArgs e)
        {
            add_doctor addDoctorsForm = new add_doctor();
            if (ParentForm is adminDashboard adminDashboard)
            {
                adminDashboard.loadform(addDoctorsForm);
            }

        }

        private void doctors_Load(object sender, EventArgs e)
        {
            LoadDoctorData();

            doctorgridview.Columns["id"].HeaderText = "ID";
            doctorgridview.Columns["name"].HeaderText = "Name";
            doctorgridview.Columns["age"].HeaderText = "Age";
            doctorgridview.Columns["specialized_area"].HeaderText = "Specialized Area";
            doctorgridview.Columns["location"].HeaderText = "Location";
            doctorgridview.Columns["phone"].HeaderText = "Phone";
            doctorgridview.Columns["email"].HeaderText = "Email";
            doctorgridview.Columns["qualifications"].HeaderText = "Qualifications";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchText = txtsearch.Text.Trim().ToLower();
            LoadDoctorData(searchText);
        }
    }
}
