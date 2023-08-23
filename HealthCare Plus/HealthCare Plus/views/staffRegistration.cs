using HealthCare_Plus.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HealthCare_Plus
{
    public partial class staffRegistration : Form
    {

        // database object 
        Database dbManager = new Database();


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
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                // Assuming RegisterValidations.IsValidRegistration function is implemented and works as expected
                if (RegisterValidations.IsValidRegistration(
                    txtname.Text.Trim(),
                    txtaddress.Text.Trim(),
                    txtphone.Text.Trim(),
                    txtemail.Text.Trim(),
                    txtusername.Text.Trim(),
                    txtpassword.Text.Trim()))
                {
                    string usernameInput = txtusername.Text;
                    string passwordInput = md5convert.GetMd5Hash(txtpassword.Text.Trim());

                    string query = "INSERT INTO user (email, username, password, role) VALUES (@Email, @Username, @Password, @Role)";
                    using (MySqlCommand insertCommand = new MySqlCommand(query, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Email", txtemail.Text.Trim());
                        insertCommand.Parameters.AddWithValue("@Username", usernameInput);
                        insertCommand.Parameters.AddWithValue("@Password", passwordInput);
                        insertCommand.Parameters.AddWithValue("@Role", 2); // Hardcoded role

                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            long userId = insertCommand.LastInsertedId;

                            // Insert into "staff" table
                            string staffQuery = "INSERT INTO staff (user_id, name, address, phone) VALUES (@UserId, @Name, @Address, @Phone)";
                            using (MySqlCommand staffInsertCommand = new MySqlCommand(staffQuery, connection))
                            {
                                staffInsertCommand.Parameters.AddWithValue("@UserId", userId);
                                staffInsertCommand.Parameters.AddWithValue("@Name", txtname.Text.Trim());
                                staffInsertCommand.Parameters.AddWithValue("@Address", txtaddress.Text.Trim());
                                staffInsertCommand.Parameters.AddWithValue("@Phone", txtphone.Text.Trim());

                                staffInsertCommand.ExecuteNonQuery();
                            }

                            Console.WriteLine("Registration successful!");
                        }
                        else
                        {
                            Console.WriteLine("Registration failed.");
                        }
                    }
                }
               
            }
        }
    }
}
