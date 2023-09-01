using HealthCare_Plus.Controllers;
using iText.Kernel.XMP.Impl;
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
using System.Xml.Linq;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace HealthCare_Plus.views.admin
{
    public partial class doctor_induvidual : UserControl
    {
        //receive the doctor id
        private int doctorId;

   
        // create doctor class object
        doctorClass doctorClass = new doctorClass();
        

        public doctor_induvidual(int selectedDoctorId)
        {
            InitializeComponent();

            // Store the selected doctor's ID
            doctorId = selectedDoctorId;
        }



        public doctor_induvidual()
        {
            InitializeComponent();
        }

       

        private void btncancel_Click(object sender, EventArgs e)
        {

        }

        private void doctor_induvidual_Load(object sender, EventArgs e)
        {
         
            doctorClass.LoadDoctorDataInduvidual(doctorId, lblname, lblage, lbllocation, lblphone, lblemail, lblspecialized, lblqualifications);
            doctorClass.LoadDoctorSchedule(doctorgridview, doctorId);
        }

        private void btnedit_Click(object sender, EventArgs e)
        {

           string name = lblname.Text ;
            string age = lblage.Text;
           string location = lbllocation.Text;
           string phone = lblphone.Text;
            string email = lblemail.Text;
            string specialized = lblspecialized.Text;
            string qualifications = lblqualifications.Text;

            doctor_edit doctor_edit = new doctor_edit(doctorId, name, age, location, phone,email, specialized, qualifications);
            if (ParentForm is adminDashboard adminDashboard)
            {
                adminDashboard.loadform(doctor_edit);
            }
        }
    }
}
