using Car_Rental.BookingRecords;
using CarRental_BusinessLayar;
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
    public partial class ctrlPaymentDetails : UserControl
    {
        private int _PaymentID;
        public int PaymentID
        {
            get { return _PaymentID; }
        }

        private clsPayment _PaymentInfo;
        public clsPayment SelectedPaymentInfo
        {
            get { return _PaymentInfo; }
        }
        //private int _BookingID;
        //public int BookingID
        //{
        //    get { return _BookingID; }
        //}

        //private clsRentalBooking _BookingInfo;
        //public clsRentalBooking SelectedBookingInfo
        //{
        //    get { return _BookingInfo; }
        //}

        public ctrlPaymentDetails()
        {
            InitializeComponent();
        }
        private void _ResetDefaultValues()
        {
            _PaymentID = -1;
            _PaymentInfo = new clsPayment();

            lblPaymentID.Text = "[????]";
            lblRentalBookingID.Text = "[????]";
            lblPaymentDate.Text = "[????]";
            lblInitialPaidAmount.Text = "[????]";
            lblActualTotalDueAmount.Text = "[????]";
            lblRemaining.Text = "[????]";
            lblRefunded.Text = "[????]";
            lblLastPaymentDate.Text = "[????]";
            lblinitialTotalAmount.Text = "[????]";

            llEditInfo.Visible = false;
        }
        private void _FillPaymentInfo()
        {
            llEditInfo.Visible = true;
            _PaymentID=_PaymentInfo.PaymentID;
            lblPaymentID.Text = _PaymentID.ToString();
            lblPaymentDate.Text = _PaymentInfo.PaymentDate.ToString("yyyy/MM/dd");

            lblinitialTotalAmount.Text = _PaymentInfo.BookingInfo.InitialTotalAmount.ToString();
            lblActualTotalDueAmount.Text = _PaymentInfo.TotalActualDueAmount?.ToString();

            lblRemaining.Text = _PaymentInfo.Remaining.ToString();

            lblRefunded.Text = _PaymentInfo.Refunded.ToString() ;  

            lblLastPaymentDate.Text =
                _PaymentInfo.UpdatedPaymentDate.HasValue
                ? _PaymentInfo.UpdatedPaymentDate.Value.ToString("yyyy/MM/dd")
                : "[N/A]";

            lblInitialPaidAmount.Text = _PaymentInfo.InitialPaidAmount.ToString();
        }

        public void FillPaymentInfo(int PaymentID)
        {
            _PaymentInfo = clsPayment.FindPaymentByID(PaymentID);

            if (_PaymentInfo == null)
            {
                _ResetDefaultValues();
                MessageBox.Show("Payment With ID [" + PaymentID + "] is not Found",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _FillPaymentInfo();
            }
        }

        void PaymentInfoUpdated(object sender, int PaymentID)
        {
            FillPaymentInfo(PaymentID);
        }

        private void llEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(_PaymentInfo != null)
            {
                frmAddEditPayment addEditPayment = new frmAddEditPayment(_PaymentInfo.VehicleBookRecordID);
                addEditPayment.DataBack += AddEditPayment_DataBack;
                addEditPayment.ShowDialog();
            }
        }

        private void AddEditPayment_DataBack(object sender, int PaymentID)
        {
            FillPaymentInfo(PaymentID);
        }

        private void llShowPaymentInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void llShowBookingInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowRentalBookingDetails showRentalBookingDetails = new frmShowRentalBookingDetails(_PaymentInfo.VehicleBookRecordID);
            showRentalBookingDetails.ShowDialog();
        }
    }
}
