using HealthCare_Plus.Services;
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
    public partial class add_patientrecord : UserControl
    {
        public add_patientrecord()
        {
            InitializeComponent();
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (AddPatientRecords.IsValidFormFields(
                combopatient,
                txtrecordname.Text,
                comborecordtype,
                date,
                txtrecord.Text))
            {
                //code here

            }
        }
    }
}
