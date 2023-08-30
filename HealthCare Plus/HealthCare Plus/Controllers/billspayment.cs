using HealthCare_Plus.views.admin;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCare_Plus.Controllers
{
    internal class billspayment
    {

        // load database object 
        Database dbManager = new Database();



        // load bill data to payment induvidual 

        public void LoadBillData(int billId, Label lblId, Label lblPatient, Label lblDate, Label lblAmount, Label lblDescription, Label lblDischarge, Button btnMarkPay)
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
                            lblId.Text = id.ToString();
                            lblPatient.Text = patient;
                            lblDate.Text = date.ToString("yyyy-MM-dd");
                            lblAmount.Text = amount.ToString("0.00");
                            lblDescription.Text = description;

                            // Adjust visibility based on payment_status
                            if (paymentStatus == 1)
                            {
                                lblDischarge.Visible = true;
                                btnMarkPay.Visible = false;
                            }
                            else
                            {
                                lblDischarge.Visible = false;
                                btnMarkPay.Visible = true;
                            }
                        }
                    }
                }
            }
        }

        // button mark payment as paid

        public void MarkBillAsPaid(int billId)
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
                        adminDashboard adminDashboard = new adminDashboard();
                        adminDashboard.loadform(bills);
                    }
                    else
                    {
                        MessageBox.Show("Failed to mark bill as paid.", "Error");
                    }
                }
            }
        }
    }
}
