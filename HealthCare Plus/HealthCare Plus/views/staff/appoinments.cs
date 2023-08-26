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
    public partial class appoinments : UserControl
    {
        public appoinments()
        {
            InitializeComponent();
        }

        private void btnaddappoinment_Click(object sender, EventArgs e)
        {
            add_appoinment add_appoinment = new add_appoinment();
            if (ParentForm is staffDashboard staffDashboard)
            {
                staffDashboard.loadform(add_appoinment);
            }
        }
    }
}
