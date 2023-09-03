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
    public partial class appoinments : UserControl
    {
        // database object 
        Database dbManager = new Database();

        //load appoinment data 

        private void LoadAppointmentData()
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT a.id, d.name AS DoctorName, p.name AS PatientName, a.description, a.date,a.time, a.isactive, a.cost " +
                                     "FROM appoiment a " +
                                     "INNER JOIN doctor d ON a.doctor_id = d.id " +
                                     "INNER JOIN patient p ON a.patient_id = p.id";

                using (MySqlDataAdapter adapter = new MySqlDataAdapter(selectQuery, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    appoinmentgridview.DataSource = dataTable;
                }
            }
        }

        public appoinments()
        {
            InitializeComponent();
        }

        private void btnaddappoinment_Click(object sender, EventArgs e)
        {
            add_appoinment add_appoinment = new add_appoinment();
            if (ParentForm is staffDashboard staffDashboard)
            {
                staffDashboard.loadform(add_appoinment);
            }
        }

        private void appoinments_Load(object sender, EventArgs e)
        {
            LoadAppointmentData();
        }

        private void appoinmentgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = appoinmentgridview.Rows[e.RowIndex];

                // Extract the values you want from the selected row
                int appointmentId = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string doctorName = selectedRow.Cells["DoctorName"].Value.ToString();
                string patientName = selectedRow.Cells["PatientName"].Value.ToString();
                string description = selectedRow.Cells["description"].Value.ToString();
                DateTime date = Convert.ToDateTime(selectedRow.Cells["date"].Value);
                string time = selectedRow.Cells["time"].Value.ToString();
                decimal cost = Convert.ToDecimal(selectedRow.Cells["cost"].Value);

                // Create an instance of the "edit_appointments" form
                edit_appoinment edit_appoinment = new edit_appoinment(appointmentId, doctorName, patientName, description, date, time, cost);

                if (ParentForm is staffDashboard staffDashboard)
                {
                    staffDashboard.loadform(edit_appoinment);
                }
                // Show the form
               

                // Optionally, handle any actions after the "edit_appointments" form is closed if needed
                // For example, refreshing the data grid view after editing
            }

        }
    }
}
