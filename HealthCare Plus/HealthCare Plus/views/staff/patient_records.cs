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
    public partial class patient_records : UserControl
    {
        public patient_records()
        {
            InitializeComponent();
        }

        private void btnaddpatientrecord_Click(object sender, EventArgs e)
        {
            add_patientrecord add_patientrecord = new add_patientrecord();
            if (ParentForm is staffDashboard staffDashboard)
            {
                staffDashboard.loadform(add_patientrecord);
            }
        }
    }
}
