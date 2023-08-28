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
    public partial class doctoravailability : UserControl
    {

        private int _doctorId;
        private DateTime _selectedDate;

        public doctoravailability(int doctorId, DateTime selectedDate)
        {
            InitializeComponent();
            _doctorId = doctorId;
            _selectedDate = selectedDate;

            // Use _doctorId and _selectedDate as needed in the form
        }
      

        private void doctoravailability_Load(object sender, EventArgs e)
        {

        }
    }
}
