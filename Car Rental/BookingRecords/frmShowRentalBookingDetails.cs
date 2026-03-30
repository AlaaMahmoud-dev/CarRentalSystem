using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental.BookingRecords
{
    public partial class frmShowRentalBookingDetails : Form
    {
        int _RentalBookingRecordID = -1;
        public frmShowRentalBookingDetails(int RentalBookingRecordID)
        {
            InitializeComponent();
            _RentalBookingRecordID = RentalBookingRecordID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmShowRentalBookingDetails_Load(object sender, EventArgs e)
        {
            ctrlBookingRecordDetails1.FillBookingInfo(_RentalBookingRecordID);
        }
    }
}
