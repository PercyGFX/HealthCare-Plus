using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCare_Plus.Controllers
{
    internal class reportsClass
    {
        // database object
        private Database dbManager = new Database();

        //////////////// EXPORT TO EXCEL METHOD ///////////////////////////////////////

        public void ExportToExcel(DataGridView dataGridView, string filePath)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                // Copy column headers from DataGridView to Excel
                for (int iC = 0; iC < dataGridView.Columns.Count; iC++)
                {
                    worksheet.Cells[1, iC + 1].Value = dataGridView.Columns[iC].HeaderText;
                }

                // Format and populate the Excel worksheet with data from the DataGridView
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        object cellValue = dataGridView.Rows[i].Cells[j].Value;

                        // Check if the cell value is a DateTime
                        if (cellValue is DateTime dateTimeValue)
                        {
                            if (dateTimeValue.TimeOfDay.TotalSeconds > 0)
                            {
                                // Handle DateTime values with time component
                                worksheet.Cells[i + 2, j + 1].Value = dateTimeValue.ToString("yyyy-MM-dd"); // Customize the format as needed
                            }
                        }
                        else if (cellValue is TimeSpan timeSpanValue)
                        {
                            // Handle TimeSpan (time-only) values
                            worksheet.Cells[i + 2, j + 1].Value = timeSpanValue.ToString("hh\\:mm\\:ss"); // Customize the format as needed
                        }
                        else
                        {
                            // For non-DateTime and non-TimeSpan values, simply copy the value
                            worksheet.Cells[i + 2, j + 1].Value = cellValue;
                        }
                    }
                }

                // Save the Excel file
                package.Save();
            }
        }

        // filter unpaid bills and add to data grid /////////////////////
        public void UnpaidBillsReport(DateTime fromDate, DateTime toDate, DataGridView dataGridView, Button exportButton)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT id, patient, date, description, amount FROM bill WHERE date BETWEEN @FromDate AND @ToDate AND payment_status = 0";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            // Bind the DataTable to the DataGridView if there are results
                            dataGridView.DataSource = dataTable;
                            dataGridView.Visible = true;
                            exportButton.Visible = true;
                        }
                        else
                        {
                            // Handle the case when there are no results (e.g., display a message)
                            MessageBox.Show("No results found for the selected date range and payment status.");
                        }
                    }
                }
            }
        }

        // Room allowcations by date reports

        public void RoomAllowcationsReport(DateTime fromDate, DateTime toDate, DataGridView dataGridView, Button exportButton)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT id, patient_id, room_id, admit_date, discharge_date, cost FROM room_allowcation WHERE admit_date BETWEEN @FromDate AND @ToDate";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            // Bind the DataTable to the DataGridView if there are results
                            dataGridView.DataSource = dataTable;
                            dataGridView.Visible = true;
                            exportButton.Visible = true;
                        }
                        else
                        {
                            // Handle the case when there are no results (e.g., display a message)
                            MessageBox.Show("No results found for the selected date range and payment status.");
                        }
                    }
                }
            }

        }

        //// Revenue report by date
        ///

        public void RevenueReport(DateTime fromDate, DateTime toDate, DataGridView dataGridView, Button exportButton)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT id, patient, date, description, amount FROM bill WHERE date BETWEEN @FromDate AND @ToDate AND payment_status = 1";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            // Bind the DataTable to the DataGridView if there are results
                            dataGridView.DataSource = dataTable;
                            dataGridView.Visible = true;
                            exportButton.Visible = true;
                        }
                        else
                        {
                            // Handle the case when there are no results (e.g., display a message)
                            MessageBox.Show("No results found for the selected date range and payment status.");
                        }
                    }
                }
            }

        }


        ///////// appoinment reports
        ///

        public void AppoinmentsReports(DateTime fromDate, DateTime toDate, DataGridView dataGridView, Button exportButton)
        {
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                string selectQuery = "SELECT id, patient, date, description, amount FROM bill WHERE date BETWEEN @FromDate AND @ToDate AND payment_status = 1";

                using (MySqlCommand cmd = new MySqlCommand(selectQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0)
                        {
                            // Bind the DataTable to the DataGridView if there are results
                            dataGridView.DataSource = dataTable;
                            dataGridView.Visible = true;
                            exportButton.Visible = true;
                        }
                        else
                        {
                            // Handle the case when there are no results (e.g., display a message)
                            MessageBox.Show("No results found for the selected date range and payment status.");
                        }
                    }
                }
            }

        }



    }
}


