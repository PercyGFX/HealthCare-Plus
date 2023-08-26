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
    }
}
