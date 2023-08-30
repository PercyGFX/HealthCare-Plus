using Google.Protobuf.WellKnownTypes;
using HealthCare_Plus.Controllers;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Relational;
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
    public partial class bills : UserControl
    {
        public bills()
        {
            InitializeComponent();
        }

        // load patient

        class Patient
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        // database object 
        Database dbManager = new Database();


        // Example method to load patient data from the database
        private List<Patient> LoadPatientsFromDatabase()
        {
            List<Patient> patients = new List<Patient>();

            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string query = "SELECT id, name FROM patient";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            patients.Add(new Patient
                            {
                                Id = reader.GetInt32("id"),
                                Name = reader.GetString("name")
                            });
                        }
                    }
                }
            }

            return patients;
        }

        // grid load

        private void LoadDoctorData(string searchText = null)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT id, patient, date, description, amount, payment_status FROM bill"; // Default query for loading all data

                if (!string.IsNullOrWhiteSpace(searchText))
                {
                    selectQuery += $" WHERE id LIKE '%{searchText}%' OR patient LIKE '%{searchText}%' OR date LIKE '%{searchText}%' OR description LIKE '%{searchText}%' OR amount LIKE '%{searchText}%'";
                }

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Clear existing data in the patientgridview
                        patientgridview.Rows.Clear();

                        while (reader.Read())
                        {
                            // Retrieve patient data from the reader
                            int id = Convert.ToInt32(reader["id"]);
                            string patientName = reader["patient"].ToString();
                            DateTime date = Convert.ToDateTime(reader["date"]);
                            string formattedDate = date.ToString("yyyy-MM-dd");
                            string description = reader["description"].ToString();
                            decimal amount = Convert.ToDecimal(reader["amount"]);
                            int paymentStatus = Convert.ToInt32(reader["payment_status"]);
                            string status = "Pay";

                            // Map payment status to "Paid" or "Unpaid"
                            string paymentStatusText = paymentStatus == 0 ? "Unpaid" : "Paid";

                            // Add the patient data to the patientgridview
                            patientgridview.Rows.Add(id, patientName, formattedDate, description, amount, paymentStatusText, status);
                        }
                    }
                }
            }
        }

        private void bills_Load(object sender, EventArgs e)
        {
            // Load patient data from the database
            List < Patient > patients = LoadPatientsFromDatabase();

            // Format data for display
            List<string> formattedPatientList = new List<string>();
            foreach (Patient patient in patients)
            {
                string formattedEntry = $"{patient.Id} - {patient.Name}";
                formattedPatientList.Add(formattedEntry);
            }

            // Populate the combopatient combo box
            combopatient.DataSource = formattedPatientList;

            combopatient.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            combopatient.AutoCompleteSource = AutoCompleteSource.ListItems;



            // data grid load
            LoadDoctorData();

            // format pay



        }

        // loads id from combo

        private int GetIdFromFormattedText(string formattedText)
        {
            // Split the formatted text by the separator character (assuming "-" here)
            string[] parts = formattedText.Split('-');

            if (parts.Length > 0)
            {
                // Try to parse the first part as an integer
                if (int.TryParse(parts[0].Trim(), out int id))
                {
                    return id;
                }
            }

            // Return -1 or throw an exception based on your needs if parsing fails
            return -1;
        }

        private void btncreatebill_Click(object sender, EventArgs e)
        {
            int patientId = GetIdFromFormattedText(combopatient.Text);

            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                decimal totalCost = 0;

                // Check appoiment table
                string selectAppoimentQuery = "SELECT SUM(cost) FROM appoiment WHERE patient_id = @PatientId AND InvoiceStatus = 0";
                using (MySqlCommand cmd = new MySqlCommand(selectAppoimentQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@PatientId", patientId); // Replace with actual patient ID
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalCost += Convert.ToDecimal(result);
                    }
                }

                // Check medications table
                string selectMedicationsQuery = "SELECT SUM(cost) FROM meications WHERE patient_id = @PatientId AND InvoiceStatus = 0";
                using (MySqlCommand cmd = new MySqlCommand(selectMedicationsQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@PatientId", patientId); // Replace with actual patient ID
                    object result = cmd.ExecuteScalar();

                    if (result != DBNull.Value)
                    {
                        totalCost += Convert.ToDecimal(result);
                    }
                }

                // Check room_allowcation table
                string selectRoomAllocationQuery = "SELECT admit_date, discharge_date, cost FROM room_allowcation WHERE patient_id = @PatientId AND InvoiceStatus = 0";
                using (MySqlCommand cmd = new MySqlCommand(selectRoomAllocationQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@PatientId", patientId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime admitDate = Convert.ToDateTime(reader["admit_date"]);
                            DateTime? dischargeDateNullable = reader.IsDBNull(reader.GetOrdinal("discharge_date")) ? null : (DateTime?)reader["discharge_date"];
                            decimal cost = Convert.ToDecimal(reader["cost"]);

                            if (dischargeDateNullable == null)
                            {
                                // Handle the case where the discharge date is null
                                MessageBox.Show("Patient currently not discharged from a room.", "Error");
                                return;
                            }

                            DateTime dischargeDate = dischargeDateNullable.Value;
                            TimeSpan duration = dischargeDate - admitDate;
                            decimal roomCost = duration.Days * cost;
                            totalCost += roomCost;
                        }
                    }
                }
               


                if (totalCost > 0)
                    {
                        // Update InvoiceStatus to 1 for all related tables
                        string updateAppoimentQuery = "UPDATE appoiment SET InvoiceStatus = 1 WHERE patient_id = @PatientId";
                        string updateMedicationsQuery = "UPDATE meications SET InvoiceStatus = 1 WHERE patient_id = @PatientId";
                        string updateRoomAllocationQuery = "UPDATE room_allowcation SET InvoiceStatus = 1 WHERE patient_id = @PatientId";
                        using (MySqlCommand updateCmd = new MySqlCommand())
                        {
                            updateCmd.Connection = connection;
                            updateCmd.CommandText = "BEGIN;" + updateAppoimentQuery + ";" + updateMedicationsQuery + ";" + updateRoomAllocationQuery + ";COMMIT;";
                            updateCmd.Parameters.AddWithValue("@PatientId", patientId);

                        int rowsAffected = updateCmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Insert record into the bill table
                            string description = $"User ID is {patientId} & created on {DateTime.Now.ToString("yyyy/MM/dd")}";
                            string insertBillQuery = "INSERT INTO bill (patient, date, description, amount, payment_status) VALUES (@PatientId, @Date, @Description, @Amount, 0)";
                            using (MySqlCommand insertCmd = new MySqlCommand(insertBillQuery, connection))
                            {
                                insertCmd.Parameters.AddWithValue("@PatientId", patientId); // Replace with actual patient ID
                                insertCmd.Parameters.AddWithValue("@Date", DateTime.Now); // Replace with actual date
                                insertCmd.Parameters.AddWithValue("@Description", description);
                                insertCmd.Parameters.AddWithValue("@Amount", totalCost);

                                int insertRowsAffected = insertCmd.ExecuteNonQuery();
                                if (insertRowsAffected > 0)
                                {
                                    MessageBox.Show("Bill created successfully.", "Success");
                                }
                                else
                                {
                                    MessageBox.Show("Failed to create bill.", "Error");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to update InvoiceStatus.", "Error");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No pending costs for the patient.", "Information");
                }
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string searchText = txtsearch.Text.Trim().ToLower();
            LoadDoctorData(searchText);
        }

        private void btnsearch_Click_1(object sender, EventArgs e)
        {
           
            
                string searchText = txtsearch.Text.Trim().ToLower();
                LoadDoctorData(searchText);
            
        }

        private void patientgridview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedbillID = Convert.ToInt32(patientgridview.Rows[e.RowIndex].Cells["ID"].Value);

                payment payment = new payment(selectedbillID);
                if (ParentForm is adminDashboard adminDashboard)
                {
                    adminDashboard.loadform(payment);
                }



            }
        }
    }
}
