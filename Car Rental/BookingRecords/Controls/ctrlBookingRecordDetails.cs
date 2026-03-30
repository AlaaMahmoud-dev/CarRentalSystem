using Car_Rental.Customers;
using Car_Rental.Payments;
using Car_Rental.Vehicles;
using CarRental_BusinessLayar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental.BookingRecords.Controls
{
    public partial class ctrlBookingRecordDetails : UserControl
    {
        private int _RentalBookingID;
        public int RentalBookingID
        {
            get { return _RentalBookingID; }
        }

        private clsRentalBooking _BookingInfo;
        public clsRentalBooking SelectedBookingInfo
        {
            get { return _BookingInfo; }
        }
        public ctrlBookingRecordDetails()
        {
            InitializeComponent();


        }
        private void _ResetDefaultValues()
        {
            _RentalBookingID = -1;
            _BookingInfo = new clsRentalBooking();

            lblRentalBookingID.Text = "[????]";
            lblCustomerID.Text = "[????]";
            lblCustomerName.Text = "[????]";
            lblPickUpLocation.Text = "[????]";
            lblDropOffLocation.Text = "[????]";
            lblDueDate.Text = "[????]";
            lblRentedAt.Text = "[????]";
            lblStatus.Text = "[????]";
            lblVehicleConditionNotes.Text = "[????]";
            lblVehicleID.Text = "[????]";
            lblVehicleModel.Text = "[????]";

            llEditInfo.Visible = false;
            llShowCustomerInfo.Visible = false;
            llShowVehicleInfo.Visible = false;
        }

        private void _FillBookingInfo()
        {
            llEditInfo.Visible = true;
            llShowCustomerInfo.Visible = true;         

            llShowVehicleInfo.Visible = true;
            this._RentalBookingID = _BookingInfo.RentalBookingID;

            lblRentalBookingID.Text = _BookingInfo.RentalBookingID.ToString();
            lblCustomerID.Text = _BookingInfo.CustomerID.ToString();
            lblPickUpLocation.Text = _BookingInfo.PickUpLocation;
            lblDropOffLocation.Text = _BookingInfo.DropOffLocation;
            lblDueDate.Text = _BookingInfo.DueDate.ToString("yyyy/MM/dd");
            lblRentedAt.Text = _BookingInfo.RentedAt.ToString("yyyy/MM/dd");
            lblStatus.Text = _BookingInfo.StatusCaption.ToString();
            lblVehicleConditionNotes.Text = _BookingInfo.VehicleConditionNotes;
            lblVehicleID.Text = _BookingInfo.VehicleID.ToString();
            lblCustomerName.Text = _BookingInfo.CustomerInfo.PersonInfo.FullName;
            lblVehicleModel.Text = _BookingInfo.VehicleInfo.ModelInfo.MakeInfo.MakeName + " " + _BookingInfo.VehicleInfo.ModelInfo.ModelName;

        }

        public void FillBookingInfo(int RentalBookingID)
        {
            _BookingInfo = clsRentalBooking.FindBookingByID(RentalBookingID);

            if (_BookingInfo == null)
            {
                _ResetDefaultValues();
                MessageBox.Show("Booking With ID [" + RentalBookingID + "] is not Found",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _FillBookingInfo();
            }
        }

        void BookingInfoUpdated(object sender, int RentalBookingID)
        {
            FillBookingInfo(RentalBookingID);
        }

        private void llEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_BookingInfo != null)
            {
                frmAddEditRentalBooking addEdit = new frmAddEditRentalBooking(_RentalBookingID);
                addEdit.DataBack += BookingInfoUpdated;
                addEdit.ShowDialog();
            }
        }

      

        private void llShowCustomerInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_BookingInfo != null)
            {
                frmShowCustomerDetails showCustomerDetails = new frmShowCustomerDetails(_BookingInfo.CustomerID);
                showCustomerDetails.ShowDialog();
            }
        }

        private void llShowVehicleInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_BookingInfo != null)
            {
                frmShowVehicleDetails showVehicleDetails = new frmShowVehicleDetails(_BookingInfo.VehicleID);
                showVehicleDetails.ShowDialog();
            }
        }

        private void llShowPaymentInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}
