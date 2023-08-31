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

        private void btnunpaidbills_Click(object sender, EventArgs e)
        {

            unpaidbills_report unpaidbills_report = new unpaidbills_report();
            if (ParentForm is adminDashboard adminDashboard)
            {
                adminDashboard.loadform(unpaidbills_report);
            }

        }

        private void btnappoinments_Click(object sender, EventArgs e)
        {
            appoinments_reports appoinments_reports = new appoinments_reports();
            if (ParentForm is adminDashboard adminDashboard)
            {
                adminDashboard.loadform(appoinments_reports);
            }
        }
    }
}
