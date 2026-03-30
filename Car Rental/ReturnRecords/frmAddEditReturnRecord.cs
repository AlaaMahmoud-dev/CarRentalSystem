using Car_Rental.Payments;
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

namespace Car_Rental.ReturnRecords
{
    public partial class frmAddEditReturnRecord : Form
    {
        int _BookingID;
        clsReturnRecord _ReturnRecord;
        int _ReturnRecordID;
        clsRentalBooking _BookingInfo;
        enum enMode
        {
            AddNew=1,
            Update
        }
        enMode mode = enMode.AddNew;
        public frmAddEditReturnRecord(int bookingID)
        {
            InitializeComponent();
            _BookingID = bookingID;
        }

        private void _LoadData()
        {
            ctrlVehicleDetailsWithFilter1.FillVehicleInfo(_ReturnRecord.BookingInfo.VehicleID);
            lblReturnRecordID.Text = _ReturnRecord.ReturnRecordID.ToString();
            lblCustomerName.Text = _ReturnRecord.BookingInfo.CustomerInfo.PersonInfo.FullName;
            lblRentalBookingID.Text = _BookingID.ToString();
            lblVehicleOldMileages.Text = _ReturnRecord.VehicleOldMileages.ToString();
            txtAdditionalChrges.Text = _ReturnRecord.AdditionalCharges.ToString();
            txtCurrentMileages.Text = _ReturnRecord.CurrentMileages.ToString();
            txtVehicleFinalCheckNotes.Text = _ReturnRecord.FinalVehicleCheckNotes;
            dtpActualReturnDate.Value = _ReturnRecord.ActualReturnDate;
        }
        private void frmAddEditReturnRecord_Load(object sender, EventArgs e)
        {
            
            lblRentalBookingID.Text = _BookingID.ToString();
            dtpActualReturnDate.Value = DateTime.Now;
             _ReturnRecord = clsReturnRecord.FindReturnRecordByBookingID(_BookingID);
            if (_ReturnRecord == null)
            {
                _ReturnRecord = new clsReturnRecord();
                lblRentalBookingID.Text = "[????]";
                mode = enMode.AddNew;
                lblMode.Text = "AddNew V.Return Record";
                return;
            }
            mode = enMode.Update;
            lblMode.Text = "Update V.Return Record";
            _LoadData();
        }

        private void ctrlVehicleDetailsWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There is Missing Data, Please check.",
                    "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _ReturnRecord.VehicleOldMileages = ctrlVehicleDetailsWithFilter1.SelectedVehicleInfo.Mileage;
            _ReturnRecord.AdditionalCharges = decimal.Parse(txtAdditionalChrges.Text);
            _ReturnRecord.CurrentMileages = int.Parse(txtCurrentMileages.Text);
            _ReturnRecord.FinalVehicleCheckNotes = txtVehicleFinalCheckNotes.Text;
            _ReturnRecord.ActualReturnDate = dtpActualReturnDate.Value;
            _ReturnRecord.VehicleBookRecordID = _BookingID;
            if (_ReturnRecord.Save())
            {
                _ReturnRecordID = _ReturnRecord.ReturnRecordID;
                MessageBox.Show("Data Saved Successfully",
                    "Save Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (mode == enMode.AddNew)
            {
                ctrlVehicleDetailsWithFilter1.FilterEnabled = false;
                mode = enMode.Update;
                lblMode.Text = "Update V.Return Record";
                lblReturnRecordID.Text = _ReturnRecord.ReturnRecordID.ToString();
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ctrlVehicleDetailsWithFilter1_OnVehicleSelected(int VehicleID)
        {
            
            if (VehicleID == -1)
            {
                btnSave.Enabled = false;
                return;
            }
            if (!((clsVehicle.enStatus)ctrlVehicleDetailsWithFilter1.SelectedVehicleInfo.Status == clsVehicle.enStatus.Rented))
            {
                MessageBox.Show("Selected Vehicle is not rented, choose another one.",
                    "Not Allowed",MessageBoxButtons.OK,MessageBoxIcon.Information);
                btnSave.Enabled = false;
                return;

            }
            _BookingInfo = clsRentalBooking.FindBookingByVehicleID(VehicleID);
            if (_BookingInfo != null)
            {
                _BookingID = _BookingInfo.RentalBookingID;
                lblRentalBookingID.Text = _BookingID.ToString();
                lblVehicleOldMileages.Text = _BookingInfo.VehicleInfo.Mileage.ToString();
                lblCustomerName.Text = _BookingInfo.CustomerInfo.PersonInfo.FullName;
                btnSave.Enabled = true;
            }
        }
    }
}
