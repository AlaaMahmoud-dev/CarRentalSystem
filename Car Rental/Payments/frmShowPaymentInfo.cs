using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental.Payments
{
    public partial class frmShowPaymentInfo : Form
    {
        int _PaymentID;
        public frmShowPaymentInfo(int PaymentID)
        {
            InitializeComponent();
            _PaymentID = PaymentID;
        }

        private void frmShowPaymentInfo_Load(object sender, EventArgs e)
        {
            ctrlPaymentDetails1.FillPaymentInfo(_PaymentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
