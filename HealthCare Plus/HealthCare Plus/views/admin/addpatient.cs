using HealthCare_Plus.Controllers;
using HealthCare_Plus.Services;
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
    public partial class addpatient : UserControl
    {

        patientsClass patients = new patientsClass();


        public addpatient()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (AddPatientValidations.IsValidFormFields(
            txtname.Text.Trim(),
             txtage.Text.Trim(),
                txtaddress.Text.Trim(),
                txtphone.Text.Trim(),
                txtblood.Text.Trim(),
                rtextdescription.Text.Trim()))
            {
                string name = txtname.Text.Trim();
                string age = txtage.Text.Trim();
                string address = txtaddress.Text.Trim();
                string phone = txtphone.Text.Trim();
                string bloodType = txtblood.Text.Trim();
                string description = rtextdescription.Text.Trim();
                string isActive = "Active"; // Hardcoded "Active"

                if (patients.InsertPatientData(name, age, address, phone, bloodType, description, isActive))
                {
                    MessageBox.Show("Patient data added successfully.", "Success");

                    // Load back to the main form (adjust form name accordingly)
                    patients patients = new patients();
                    if (ParentForm is adminDashboard adminDashboard)
                    {
                        adminDashboard.loadform(patients);
                    }
                }
                else
                {
                    MessageBox.Show("Failed to add patient data.", "Error");
                }
            }

        }
    }
}
