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
    public partial class booked_rooms : UserControl
    {
        public booked_rooms()
        {
            InitializeComponent();
        }

        // load data to table

        private void LoadDataToBookedRoomsGridView()
        {

            // database object 
            Database dbManager = new Database();

            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT ra.id AS ID, p.name AS Patient, r.room_name AS Room, ra.admit_date AS AdmitDate, ra.discharge_date AS DischargeDate, ra.cost AS Cost " +
                                     "FROM room_allowcation ra " +
                                     "INNER JOIN patient p ON ra.patient_id = p.id " +
                                     "INNER JOIN rooms r ON ra.room_id = r.id";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    bookedroomsgridview.DataSource = dataTable;
                }
            }
        }

        private void booked_rooms_Load(object sender, EventArgs e)
        {
            LoadDataToBookedRoomsGridView();
        }

        private void bookedroomsgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string room = bookedroomsgridview.Rows[e.RowIndex].Cells["Room"].Value.ToString();
                int allowcation_id = Convert.ToInt32(bookedroomsgridview.Rows[e.RowIndex].Cells["ID"].Value);

                // Open the new form and pass the selected room ID and value
                discharge discharge = new discharge(allowcation_id, room);
                if (ParentForm is staffDashboard staffDashboard)
                {
                    staffDashboard.loadform(discharge);
                }
            }
        }
    }
}
