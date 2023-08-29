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
    public partial class medications : UserControl
    {

        // database object 
        Database dbManager = new Database();
        public medications()
        {
            InitializeComponent();
        }

        // load medications

        private void LoadDataToMedicationsGridView()
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT id, patient_id, medication, description, date, cost FROM meications";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    medicationsgridview.DataSource = dataTable;
                }
            }
        }

        private void medications_Load(object sender, EventArgs e)
        {

            LoadDataToMedicationsGridView();
        }

        private void btnaddmedication_Click(object sender, EventArgs e)
        {
            add_medication add_medication = new add_medication();
            if (ParentForm is staffDashboard staffDashboard)
            {
                staffDashboard.loadform(add_medication);
            }
        }

        // search

        private void LoadDoctorData(string searchText = null)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT id, patient_id, medication, description, date, cost FROM meications"; // Default query for loading all data

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    selectQuery += $" WHERE id LIKE '%{searchText}%' OR medication LIKE '%{searchText}%' OR description LIKE '%{searchText}%'";
                }

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    medicationsgridview.DataSource = dataTable;
                }
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string searchText = txtsearch.Text.Trim().ToLower();
            LoadDoctorData(searchText);
        }
    }
}
