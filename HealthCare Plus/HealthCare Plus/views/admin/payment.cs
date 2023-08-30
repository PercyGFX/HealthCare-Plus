using HealthCare_Plus.Controllers;
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
            billspayment.MarkBillAsPaid(_billId);
        }
    }
}
