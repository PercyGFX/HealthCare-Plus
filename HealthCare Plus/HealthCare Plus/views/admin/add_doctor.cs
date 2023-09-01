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
    public partial class add_doctor : UserControl
    {
        // add doctor class
        doctorClass doctorClass = new doctorClass();

        public add_doctor()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            //check validations
            if (AddDoctorValidations.IsValidFormFields(
                    txtname.Text.Trim(),
                    txtage.Text.Trim(),
                    txtlocation.Text.Trim(),
                    txtphone.Text.Trim(),
                    txtemail.Text.Trim(),
                    txtspecialized.Text.Trim(),
                    rtextqualifications.Text.Trim()))
            {
                // call add doctor if validations are right
               if( doctorClass.AddDoctor(
                    txtname.Text.Trim(),
                    txtage.Text.Trim(),
                    txtlocation.Text.Trim(),
                    txtphone.Text.Trim(),
                    txtemail.Text.Trim(),
                    txtspecialized.Text.Trim(),
                    rtextqualifications.Text.Trim()
                ))
                {
                    MessageBox.Show("Doctor data added successfully.", "Success");
                    if (ParentForm is adminDashboard adminDashboard)
                    {
                        doctors doctors = new doctors();
                        adminDashboard.loadform(doctors);
                    }

                } else
                {
                    MessageBox.Show("Failed to add doctor data.", "Error");
                }
            }
        }

        private void add_doctor_Load(object sender, EventArgs e)
        {

        }
    }
}
