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

     

  



        public adminDashboard()
        {
            InitializeComponent();
        }

        // forms load to main container code
        public void loadform(UserControl Form)
        {
            Form.Dock = DockStyle.Fill;
            this.panelcontent.Controls.Clear();
            this.panelcontent.Controls.Add(Form);
            Form.BringToFront();
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

        private void btnrooms_Click(object sender, EventArgs e)
        {
            rooms rooms = new rooms();
            loadform(rooms);
        }

        private void btnbillpay_Click(object sender, EventArgs e)
        {
            bills bills = new bills();
            loadform(bills);
        }

        private void panelsidebar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnresources_Click(object sender, EventArgs e)
        {
            resources resources = new resources();
            loadform(resources);
        }
    }
}
