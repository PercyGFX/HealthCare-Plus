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
    public partial class reports : UserControl
    {
        public reports()
        {
            InitializeComponent();
        }

        private void btnpatients_Click(object sender, EventArgs e)
        {

        }

        private void btnadddoctor_Click(object sender, EventArgs e)
        {
            revenue_report revenue_report = new revenue_report();
            if (ParentForm is adminDashboard adminDashboard)
            {
                adminDashboard.loadform(revenue_report);
            }
        }
    }
}
