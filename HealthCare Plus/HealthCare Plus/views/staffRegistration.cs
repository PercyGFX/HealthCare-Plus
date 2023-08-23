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
using System.Xml.Linq;

namespace HealthCare_Plus
{
    public partial class staffRegistration : Form
    {
        public staffRegistration()
        {
            InitializeComponent();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();

            this.Hide();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();

            this.Hide();
        }

        // register button logic

        private void btnregister_Click(object sender, EventArgs e)
        {
            // register validations
            if (RegisterValidations.IsValidRegistration(
                    txtname.Text.Trim(),
                    txtaddress.Text.Trim(),
                    txtphone.Text.Trim(),
                    txtemail.Text.Trim(),
                    txtusername.Text.Trim(),
                    txtpassword.Text.Trim()))
            {
                // Your code when registration input is valid
            }
        }
    }
}
