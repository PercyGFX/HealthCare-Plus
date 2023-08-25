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
    public partial class adminDashboard : Form
    {

        // forms load to main container code

        public void loadform(UserControl Form)
        {
            Form.Dock = DockStyle.Fill;
            this.panelcontent.Controls.Clear();
            this.panelcontent.Controls.Add(Form);
            Form.BringToFront();
        }


        public adminDashboard()
        {
            InitializeComponent();
        }

        private void picboxclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void picboxminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void picboxlogout_Click(object sender, EventArgs e)
        {
            login login = new login();
            this.Hide();
            login.Show();
        }

        private void btnpatients_Click(object sender, EventArgs e)
        {
            patients patients = new patients();
            loadform(patients);
        }

        private void btcdoctors_Click(object sender, EventArgs e)
        {
            doctors doctors = new doctors();
            loadform(doctors);
        }
    }
}
