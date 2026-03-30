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

namespace Car_Rental.ReturnRecords.Controls
{
    public partial class ctrlReturnRecordDetails : UserControl
    {
        private int _ReturnRecordID;
        public int ReturnRecordID
        {
            get { return _ReturnRecordID; }
        }

        private clsReturnRecord _ReturnRecordInfo;
        public clsReturnRecord SelectedReturnRecordInfo
        {
            get { return _ReturnRecordInfo; }
        }
        public int BookingID
        {
            get
            {
                return ctrlBookingRecordDetails1.RentalBookingID;
            }
        }

        public clsRentalBooking RentalBooking
        {
            get
            {
                return ctrlBookingRecordDetails1.SelectedBookingInfo;
            }
        }
        public ctrlReturnRecordDetails()
        {
            InitializeComponent();
        }
        private void _ResetDefaultValues()
        {
            _ReturnRecordID = -1;
            _ReturnRecordInfo = new clsReturnRecord();

            lblReturnRecordID.Text = "[????]";
            lblRentalBookingID.Text = "[????]";
            lblActualReturnDate.Text = "[????]";
            lblCurrentMileages.Text = "[????]";
            lblVehicleOldMileages.Text = "[????]";
            lblAdditionalCharges.Text = "[????]";
            lblFinalVehicleChecksNotes.Text = "[????]";
            lblActualTotalAmount.Text = "[????]";

            llEditInfo.Visible = false;
        }

        private void _FillReturnRecordInfo()
        {
            llEditInfo.Visible = true;

            this._ReturnRecordID = _ReturnRecordInfo.ReturnRecordID;
            ctrlBookingRecordDetails1.FillBookingInfo(_ReturnRecordInfo.VehicleBookRecordID);
            lblReturnRecordID.Text = _ReturnRecordInfo.ReturnRecordID.ToString();
            lblRentalBookingID.Text = _ReturnRecordInfo.VehicleBookRecordID.ToString();
            lblActualReturnDate.Text = _ReturnRecordInfo.ActualReturnDate.ToString("yyyy/MM/dd");
            lblCurrentMileages.Text = _ReturnRecordInfo.CurrentMileages.ToString();
            lblVehicleOldMileages.Text = _ReturnRecordInfo.VehicleOldMileages.ToString();
            lblAdditionalCharges.Text = _ReturnRecordInfo.AdditionalCharges.ToString();
            lblFinalVehicleChecksNotes.Text = _ReturnRecordInfo.FinalVehicleCheckNotes;
            lblActualTotalAmount.Text = _ReturnRecordInfo.ActualTotalAmount.ToString();
        }

        public void FillReturnRecordInfo(int ReturnRecordID)
        {
            _ReturnRecordInfo = clsReturnRecord.FindReturnRecordByID(ReturnRecordID);

            if (_ReturnRecordInfo == null)
            {
                _ResetDefaultValues();
                MessageBox.Show("Return Record With ID [" + ReturnRecordID + "] is not Found",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _FillReturnRecordInfo();
            }
        }
        void ReturnRecordUpdated(object sender, int ReturnRecordID)
        {
            FillReturnRecordInfo(ReturnRecordID);
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void llEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (_ReturnRecordInfo != null)
            //{
            //    frmAddEditReturnRecord addEdit = new frmAddEditReturnRecord(_ReturnRecordID);
            //    addEdit.DataBack += ReturnRecordUpdated;
            //    addEdit.ShowDialog();
            //}
        }
    }
}
