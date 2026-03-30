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
    public partial class frmAddEditPayment : Form
    {
        public delegate void DataBackEventHandler(object sender, int PaymentID);
        public event DataBackEventHandler DataBack;
        int _PaymentID;
        clsPayment _PaymentInfo;
        public enum enMode
        {
            AddNew,
            Update
        }
        enMode mode;
        public frmAddEditPayment(int BookingID)
        {
            InitializeComponent();
            ctrlBookingRecordDetails1.FillBookingInfo(BookingID);
            _PaymentID = -1;
            _PaymentInfo = new clsPayment();
        }

        private void _ResetDefaultValues()
        {
            txtInitialPaidAmount.Text = "0";
            lblPaymentDate.Text = DateTime.Now.ToString("yyyy/MMM/dd");
            lblLastPaymentDate.Text = "N/A";
            lblinitialTotalAmount.Text = ctrlBookingRecordDetails1.SelectedBookingInfo.InitialTotalAmount.ToString();
            lblActualTotalDueAmount.Text = "N/A";

            if (_PaymentInfo != null)
            {
                mode = enMode.Update;

            }
            else
            {
                _PaymentInfo = new clsPayment();
                mode = enMode.AddNew;
                lblMode.Text = "AddNew Payment";
                return;
            }
            lblMode.Text = "Update Payment Info";
            _LoadData();
            
            
          

        }
        private void _LoadData()
        {
            txtInitialPaidAmount.Text = _PaymentInfo.InitialPaidAmount.ToString();
            if (_PaymentInfo.TotalActualDueAmount.HasValue)
                lblActualTotalDueAmount.Text = _PaymentInfo.TotalActualDueAmount.ToString();
            lblPaymentDate.Text = _PaymentInfo.PaymentDate.ToString("yyyy/MMM/dd");
            lblLastPaymentDate.Text = _PaymentInfo.UpdatedPaymentDate?.ToString("yyyy/MMM/dd") ?? "N/A";
            if((clsRentalBooking.enStatus)ctrlBookingRecordDetails1.SelectedBookingInfo.Status == clsRentalBooking.enStatus.Completed)
            {
                btnSave.Enabled = false;
                txtInitialPaidAmount.Enabled = false;
            }
        }

        private void frmAddEditPayment_Load(object sender, EventArgs e)
        {
            _PaymentInfo = clsPayment.FindByBookingID(ctrlBookingRecordDetails1.RentalBookingID);
           
            _ResetDefaultValues();
        }

        private void txtInitialPaidAmount_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtInitialPaidAmount.Text))
            {
                lblRemaining.Text = lblinitialTotalAmount.Text;
                return;
            }
            if (decimal.Parse(txtInitialPaidAmount.Text) >= decimal.Parse(lblinitialTotalAmount.Text))
            {
                lblRemaining.Text = "0";
                lblRefunded.Text = (decimal.Parse(txtInitialPaidAmount.Text) - decimal.Parse(lblinitialTotalAmount.Text)).ToString();
            }
            else
            {
                lblRefunded.Text = "0";
                lblRemaining.Text = (decimal.Parse(lblinitialTotalAmount.Text) - decimal.Parse(txtInitialPaidAmount.Text)).ToString();

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There is Missing Data, Please check.",
                    "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            _PaymentInfo.InitialPaidAmount = Convert.ToDecimal(txtInitialPaidAmount.Text.Trim());
            if(mode == enMode.AddNew)
                _PaymentInfo.PaymentDate = DateTime.Now;
            else
                _PaymentInfo.UpdatedPaymentDate = DateTime.Now;
            if (_PaymentInfo.Save())
            {

                MessageBox.Show("Data Saved Successfully",
                    "Save Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBack?.Invoke(this, _PaymentInfo.PaymentID);
            }
            else
            {
                MessageBox.Show("Data Saving Failed!!!",
                    "Save Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mode == enMode.AddNew)
            {
                
                mode = enMode.Update;
                lblMode.Text = "Update Payment";
            }


        }
    }
}
