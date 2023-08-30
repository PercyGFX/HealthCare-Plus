using MySql.Data.MySqlClient;
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
    public partial class payment : UserControl
    {
       //receive the doctor id
        private int _billId;

        // database object 
        Database dbManager = new Database();


        public payment(int billId)
        {
            InitializeComponent();

            
            _billId = billId;
        }

        // load bill date
        private void LoadBillData(int billId)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT id, patient, date, description, amount, payment_status FROM bill WHERE id = @BillId";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@BillId", billId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["id"]);
                            string patient = reader["patient"].ToString();
                            DateTime date = Convert.ToDateTime(reader["date"]);
                            decimal amount = Convert.ToDecimal(reader["amount"]);
                            string description = reader["description"].ToString();
                            int paymentStatus = Convert.ToInt32(reader["payment_status"]);

                            // Populate the labels with the retrieved data
                            lblid.Text = id.ToString();
                            lblpatient.Text = patient;
                            lbldate.Text = date.ToString("yyyy-MM-dd");
                            lblamount.Text = amount.ToString("0.00");
                            lbldescription.Text = description;

                            // Adjust visibility based on payment_status
                            if (paymentStatus == 1)
                            {
                                lbldischarge.Visible = true;
                                btnmarkpay.Visible = false;
                            }
                            else
                            {
                                lbldischarge.Visible = false;
                                btnmarkpay.Visible = true;
                            }
                        }
                    }
                }
            }
        }


        // mark as paid

        private void MarkBillAsPaid(int billId)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string updateQuery = "UPDATE bill SET payment_status = 1 WHERE id = @BillId";

                using (MySqlCommand cmd = new MySqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@BillId", billId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Bill marked as paid.", "Success");
                        // Load back to the main form (adjust form name accordingly)
                        bills bills = new bills();
                        if (ParentForm is adminDashboard adminDashboard)
                        {
                            adminDashboard.loadform(bills);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Failed to mark bill as paid.", "Error");
                    }
                }
            }
        }

        private void payment_Load(object sender, EventArgs e)
        {
            LoadBillData(_billId);

        }

        private void btnmarkpay_Click(object sender, EventArgs e)
        {
            MarkBillAsPaid(_billId);
        }
    }
}
