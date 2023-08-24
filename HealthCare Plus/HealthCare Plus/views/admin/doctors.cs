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
    public partial class doctors : UserControl
    {
        public doctors()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void orders_Click(object sender, EventArgs e)
        {
            add_doctor addDoctorsForm = new add_doctor();
            if (ParentForm is adminDashboard adminDashboard)
            {
                adminDashboard.loadform(addDoctorsForm);
            }

        }
    }
}
