using HealthCare_Plus.Controllers;
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
using System.Web.Compilation;
using System.Windows.Forms;

namespace HealthCare_Plus.views.admin
{
    public partial class unpaidbills_report : UserControl
    {
        public unpaidbills_report()
        {
            InitializeComponent();
        }

        // reports object
        reportsClass reports = new reportsClass();


        private void btngenerate_Click(object sender, EventArgs e)
        {

            DateTime fromDate = fromdate.Value;
            DateTime toDate = todate.Value;

            reports.UnpaidBillsReport(fromDate, toDate, unpaidbillsgrid, btnexportpdf);
        }

        private void btnexportpdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                reports.ExportToExcel(unpaidbillsgrid, saveFileDialog.FileName);
            }

        }

        private void unpaidbills_report_Load(object sender, EventArgs e)
        {
           

        }
    }
}
