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
    public partial class patients : UserControl
    {

        // database object 
        Database dbManager = new Database();

        //load patient data
        private void LoadPatientData(string searchText = null)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT id, name, address, phone, age, blood_type, description, is_active FROM patient"; // Default query for loading all patient data

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    selectQuery += $" WHERE id LIKE '%{searchText}%' OR name LIKE '%{searchText}%' OR address LIKE '%{searchText}%' OR phone LIKE '%{searchText}%' OR age LIKE '%{searchText}%' OR blood_type LIKE '%{searchText}%' OR description LIKE '%{searchText}%' OR is_active LIKE '%{searchText}%'";
                }

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    patientgridview.DataSource = dataTable;
                }
            }
        }
        public patients()
        {
            InitializeComponent();
        }

        private void btnaddpatient_Click(object sender, EventArgs e)
        {
            addpatient addpatient = new addpatient();
            if (ParentForm is adminDashboard adminDashboard)
            {
                adminDashboard.loadform(addpatient);
            }
        }

        private void patients_Load(object sender, EventArgs e)
        {
            LoadPatientData();

            patientgridview.Columns["id"].HeaderText = "ID";
            patientgridview.Columns["name"].HeaderText = "Name";
            patientgridview.Columns["address"].HeaderText = "Address";
            patientgridview.Columns["phone"].HeaderText = "Phone";
            patientgridview.Columns["age"].HeaderText = "Age";
            patientgridview.Columns["blood_type"].HeaderText = "Blood Type";
            patientgridview.Columns["description"].HeaderText = "Description";
            patientgridview.Columns["is_active"].HeaderText = "Active?";
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string searchText = txtsearch.Text.Trim().ToLower();
            LoadPatientData(searchText);
        }

        private void patientgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
