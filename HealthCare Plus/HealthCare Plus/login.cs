using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace HealthCare_Plus
{
    public partial class login : Form
    {
       
            Database dbManager = new Database();
    

        public login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {

            
            
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);
                // Perform database operations here.
            }
        }

        private void register_Click(object sender, EventArgs e)
        {
            staffRegistration staffRegistration = new staffRegistration();
            staffRegistration.Show();

            this.Hide();
        }
    }
}
