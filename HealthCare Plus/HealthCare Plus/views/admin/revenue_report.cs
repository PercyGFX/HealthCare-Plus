using MySql.Data.MySqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HealthCare_Plus.views.admin
{
    public partial class revenue_report : UserControl
    {
        public revenue_report()
        {
            InitializeComponent();
        }

        // database object 
        Database dbManager = new Database();

        // filter by date
        private void FilterBillsByDate()
        {
            // Get the selected dates
            DateTime fromDate = fromdate.Value;
            DateTime toDate = todate.Value;

            // Database connection setup
            using (MySqlConnection connection = dbManager.GetConnection())
            {
                dbManager.OpenConnection(connection);

                // Construct the SQL query
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
                            revenuereportgrid.DataSource = dataTable;
                            revenuereportgrid.Visible = true;
                            btnexportpdf.Visible = true;
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

        // export to excell 

        // export to excel

        private void ExportToExcel(DataGridView dataGridView, string filePath)
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


        private void btngenerate_Click(object sender, EventArgs e)
        {
            FilterBillsByDate();
        }

        private void btnexportpdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(revenuereportgrid, saveFileDialog.FileName);
            }
        }
    }
}
