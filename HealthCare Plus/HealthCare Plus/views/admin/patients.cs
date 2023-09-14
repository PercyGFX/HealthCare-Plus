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
    public partial class patients : UserControl
    {

        // patient object 
    
        patientsClass patientsClass = new patientsClass();


      
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
            //LoadPatientData();
            patientsClass.LoadPatientData(patientgridview);

            patientgridview.Columns["id"].HeaderText = "ID";
            patientgridview.Columns["name"].HeaderText = "Name";
            patientgridview.Columns["address"].HeaderText = "Address";
            patientgridview.Columns["phone"].HeaderText = "Phone";
            patientgridview.Columns["age"].HeaderText = "Age";
            patientgridview.Columns["blood_type"].HeaderText = "Blood Type";
            patientgridview.Columns["description"].HeaderText = "Description";
           
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string searchText = txtsearch.Text.Trim().ToLower();
           // LoadPatientData(searchText);

          
            patientsClass.LoadPatientData(patientgridview, searchText);
        }

        private void patientgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = patientgridview.Rows[e.RowIndex];

                // Extract data from the selected row
                int id = Convert.ToInt32(selectedRow.Cells["id"].Value);
                string name = selectedRow.Cells["name"].Value.ToString();
                string address = selectedRow.Cells["address"].Value.ToString();
                string phone = selectedRow.Cells["phone"].Value.ToString();
                int age = Convert.ToInt32(selectedRow.Cells["age"].Value);
                string bloodType = selectedRow.Cells["blood_type"].Value.ToString();
                string description = selectedRow.Cells["description"].Value.ToString();
               

               // load patient edit

                patient_edit patient_edit = new patient_edit(id, name, address, phone, age, bloodType, description);

                if (ParentForm is adminDashboard adminDashboard)
                {
                    adminDashboard.loadform(patient_edit);
                }
            }
        }
    }
}
