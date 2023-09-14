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

namespace HealthCare_Plus.views.staff
{
    public partial class doctor_induvidual : UserControl
    {
        //receive the doctor id
        private int doctorId;


        doctorClass doctorClass = new doctorClass();


        public doctor_induvidual(int selectedDoctorId)
        {
            InitializeComponent();

            // Store the selected doctor's ID
            doctorId = selectedDoctorId;
        }




        private void doctor_induvidual_Load(object sender, EventArgs e)
        {
            //LoadDoctorData(doctorId);
            //LoadDoctorSchedule(doctorId);

            doctorClass.LoadDoctorDataInduvidual(doctorId, lblname, lblage, lbllocation, lblphone, lblemail, lblspecialized, lblqualifications);
            doctorClass.LoadDoctorSchedule(doctorgridview, doctorId);

        }

        private void doctorgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
