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
    public partial class patient_records : UserControl
    {
        public patient_records()
        {
            InitializeComponent();
        }

        // database object 
        Database dbManager = new Database();

        private void btnaddpatientrecord_Click(object sender, EventArgs e)
        {
            add_patientrecord add_patientrecord = new add_patientrecord();
            if (ParentForm is staffDashboard staffDashboard)
            {
                staffDashboard.loadform(add_patientrecord);
            }
        }

        // load patient recods

        private void LoadDataToMedicationsGridView()
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT id, patient_id, record_name, date, record_type, record FROM patient_records";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    patientrecordsgrid.DataSource = dataTable;
                }
            }
        }

        // search
        private void LoadDoctorData(string searchText = null)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT id, patient_id, record_name, date, record_type, record FROM patient_records"; // Default query for loading all data

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    selectQuery += $" WHERE id LIKE '%{searchText}%' OR record_name LIKE '%{searchText}%' OR record_type LIKE '%{searchText}%' OR record LIKE '%{searchText}%'";
                }

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    patientrecordsgrid.DataSource = dataTable;
                }
            }
        }


        private void patient_records_Load(object sender, EventArgs e)
        {
            LoadDataToMedicationsGridView();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string searchText = txtsearch.Text.Trim().ToLower();
            LoadDoctorData(searchText);
        }
    }
}
