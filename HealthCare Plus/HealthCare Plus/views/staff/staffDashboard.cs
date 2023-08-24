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
    }
}
