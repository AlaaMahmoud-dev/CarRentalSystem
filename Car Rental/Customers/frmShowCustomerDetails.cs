using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental.Customers
{
    public partial class frmShowCustomerDetails : Form
    {
        int _CustomerID;
        public frmShowCustomerDetails(int CustomerID)
        {
            InitializeComponent();
            _CustomerID = CustomerID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmShowCustomerDetails_Load(object sender, EventArgs e)
        {
            ctrlCustomerDetails1.LoadCustomerInfoByID(_CustomerID);
        }
    }
}
