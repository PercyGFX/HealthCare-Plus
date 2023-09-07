using HealthCare_Plus.Controllers;
using MySql.Data.MySqlClient;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;


namespace HealthCare_Plus.views.admin
{
    public partial class payment : UserControl
    {
       //receive the bill id
        private int _billId;


        // default constructor
        public payment(int billId)
        {
            InitializeComponent();

            
            _billId = billId;
        }

        // create billspayment object
        billspayment billspayment  = new billspayment();

        private void payment_Load(object sender, EventArgs e)
        {
            // load bill date method passing form values
            billspayment.LoadBillData(_billId, lblid, lblpatient, lbldate, lblamount, lbldescription, lbldischarge, btnmarkpay);

        }

        private void btnmarkpay_Click(object sender, EventArgs e)
        {
            // mark bill as paid
            if(billspayment.MarkBillAsPaid(_billId))
            {
                MessageBox.Show("Bill marked as paid.", "Success");

                bills bills = new bills();
                if (ParentForm is adminDashboard adminDashboard)
                {
                    adminDashboard.loadform(bills);
                }

            } else
            {
                MessageBox.Show("Failed to mark bill as paid.", "Error");
            }
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            string discharge ;

            if (btnmarkpay.Visible == false)
            {
                discharge = "Bill is Paid";
            } else
            {
                discharge = "Bill is Not Paid";
            }
            string billId = lblid.Text;
            string patient = lblpatient.Text;
            string date = lbldate.Text;
            string amount = lblamount.Text;
            string description = lbldescription.Text;
            

            billspayment.GenerateBillPDF(billId, patient, date, amount, description, discharge);

            // Display a message or handle any other logic as needed
            MessageBox.Show("Bill PDF generated successfully!");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
