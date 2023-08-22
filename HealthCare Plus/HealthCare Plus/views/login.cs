using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using HealthCare_Plus.views.admin;
using HealthCare_Plus.views.staff;

namespace HealthCare_Plus
{
    public partial class login : Form
    {
        // database object 
            Database dbManager = new Database();

        // md5 convert

        private string GetMd5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        //validations
        public bool isValid()
        {
            if (txtusername.Text.Trim() == "")
            {
                MessageBox.Show("Enter a valid username.", "Error");
                return false;
            }
            else if (txtpassword.Text.Trim() == "")
            {
                MessageBox.Show("Enter a valid password.", "Error");
                return false;
            }

            return true;
        }


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

            if (isValid())
            {
                using (MySqlConnection connection = dbManager.GetConnection())
                {
                    dbManager.OpenConnection(connection);

                    string usernameInput = txtusername.Text;
                    string passwordInput = GetMd5Hash(txtpassword.Text);

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
