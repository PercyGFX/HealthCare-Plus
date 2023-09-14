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
    public partial class staffDashboard : Form
    {
        // staff load form
        public void loadform(UserControl Form)
        {
            Form.Dock = DockStyle.Fill;
            this.panelcontent.Controls.Clear();
            this.panelcontent.Controls.Add(Form);
            Form.BringToFront();
        }

        public staffDashboard()
        {
            InitializeComponent();
        }

        private void picboxlogout_Click(object sender, EventArgs e)
        {
            login login = new login();
            this.Hide();
            login.Show();
        }

        private void picboxclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnappoinments_Click(object sender, EventArgs e)
        {
            appoinments appoinments = new appoinments();
            loadform(appoinments);
        }

        private void btcdoctors_Click(object sender, EventArgs e)
        {
            doctor_shedule doctor_shedule = new doctor_shedule();
            loadform(doctor_shedule);
        }

        private void btnrooms_Click(object sender, EventArgs e)
        {
            patient_records patient_records = new patient_records();
            loadform(patient_records);
        }

        private void btndoctors_Click(object sender, EventArgs e)
        {
            doctors doctors = new doctors();
            loadform(doctors);
        }

        private void rooms_Click(object sender, EventArgs e)
        {
            rooms rooms = new rooms();
            loadform(rooms);
        }

        private void btnreports_Click(object sender, EventArgs e)
        {
            medications medications = new medications();
            loadform(medications);
        }

        private void staffDashboard_Load(object sender, EventArgs e)
        {
            welcomeStaff welcomeStaff = new welcomeStaff();
            loadform(welcomeStaff);
        }

        private void btnresources_Click(object sender, EventArgs e)
        {
            resources resources = new resources();
            loadform(resources);
        }
    }
}
