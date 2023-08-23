using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using HealthCare_Plus.views.admin;
using HealthCare_Plus.views.staff;
using HealthCare_Plus.Services;

namespace HealthCare_Plus
{
    public partial class login : Form
    {
        // database object 
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

            if (LoginValidations.IsValidLogin(txtusername.Text.Trim(), txtpassword.Text.Trim()))
            {
                using (MySqlConnection connection = dbManager.GetConnection())
                {
                    dbManager.OpenConnection(connection);

                    string usernameInput = txtusername.Text;
                    string passwordInput = md5convert.GetMd5Hash(txtpassword.Text.Trim());

                    string query = "SELECT * FROM user WHERE username = @Username AND password = @Password";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", usernameInput);
                        cmd.Parameters.AddWithValue("@Password", passwordInput);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();
                                int role = Convert.ToInt32(reader["role"]);

                                if (role == 1)
                                {
                                    // User has role 1 / admin
                                    adminDashboard adminDashboard = new adminDashboard();
                                    adminDashboard.Show();

                                    this.Hide();
                                }
                                else
                                {
                                    // User has staff role
                                    staffDashboard staffDashboard = new staffDashboard();
                                    staffDashboard.Show();

                                    this.Hide();
                                }
                            }
                            else
                            {
                                // Invalid login
                                MessageBox.Show("Invalid login information.", "Error");
                            }
                        }
                    }
                }
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
