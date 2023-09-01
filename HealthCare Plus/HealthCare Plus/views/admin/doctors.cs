using HealthCare_Plus.Controllers;
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

        doctorClass doctorClass = new doctorClass();

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
            doctorClass.LoadDoctorData(doctorgridview);

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
            doctorClass.LoadDoctorData(doctorgridview, searchText);
        }
    }
}
