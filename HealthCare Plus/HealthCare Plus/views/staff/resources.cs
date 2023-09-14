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
    public partial class resources : UserControl
    {
        public resources()
        {
            InitializeComponent();
        }

        // database object 
        Database dbManager = new Database();

        private void LoadResourceData(string searchText = null)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT id, name, description FROM resources"; // Default query for loading all data

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    selectQuery += $" WHERE id LIKE '%{searchText}%' OR name LIKE '%{searchText}%' OR description LIKE '%{searchText}%'";
                }

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    resourcegridview.DataSource = dataTable;
                }
            }
        }

        private void resources_Load(object sender, EventArgs e)
        {

            LoadResourceData();
            resourcegridview.Columns["description"].HeaderText = "Description";
            resourcegridview.Columns["description"].Width = 400;
            resourcegridview.Columns["name"].Width = 200;

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {

            string searchText = txtsearch.Text.Trim().ToLower();
            LoadResourceData(searchText);
        }
    }
}
