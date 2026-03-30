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

namespace Car_Rental.BookingRecords
{
    public partial class frmAddEditRentalBooking : Form
    {
        public delegate void DataBackEventHandler(object sender, int BookingID);
        public event DataBackEventHandler DataBack;

        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        enMode mode = enMode.AddNew;

        int _BookingID = -1;
        public int CustomerID
        {
            get
            {
                return ctrlCustomerDetailsWithFilter1.CustomerID;
            }
        }
        public int VehicleID
        {
            get
            {
                return ctrlVehicleDetailsWithFilter1.VehicleID;
            }
        }

        clsRentalBooking _BookingInfo;
        public frmAddEditRentalBooking(int BookingID)
        {
            InitializeComponent();
            if (BookingID == -1)
            {
                mode = enMode.AddNew;
            }
            else
            {
                mode = enMode.Update;
                this._BookingID = BookingID;
            }
        }
        void _LoadData()
        {
            _BookingInfo = clsRentalBooking.FindBookingByID(_BookingID);

            if (_BookingInfo == null)
            {
                MessageBox.Show("Can't find booking with ID [" + _BookingID + "]!!",
                    "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

           
            ctrlCustomerDetailsWithFilter1.FillCustomerInfoByCustomerID(_BookingInfo.CustomerID);
            ctrlVehicleDetailsWithFilter1.FillVehicleInfo(_BookingInfo.VehicleID);

            lblRentalBookingID.Text = _BookingInfo.RentalBookingID.ToString();
            lblCustomerID.Text = CustomerID.ToString();
            lblStatus.Text = _BookingInfo.StatusCaption;
            lblVehicleID.Text = VehicleID.ToString();
            lblCustomerName.Text = _BookingInfo.CustomerInfo.PersonInfo.FullName;
            lblVehicleModel.Text = _BookingInfo.VehicleInfo.ModelInfo.MakeInfo.MakeName 
                + " " + _BookingInfo.VehicleInfo.ModelInfo.ModelName;


            txtPickUpLocation.Text = _BookingInfo.PickUpLocation;
            txtDropOffLocation.Text = _BookingInfo.DropOffLocation;
            txtVehicleConditionNotes.Text = _BookingInfo.VehicleConditionNotes;

            dtpRentedAt.Value = _BookingInfo.RentedAt;
            dtpDueDate.Value = _BookingInfo.DueDate;

           
        }

        private void frmAddEditRentalBooking_Load(object sender, EventArgs e)
        {
            _ResetDefaultValues();

            if (mode == enMode.Update)
                _LoadData();
        }

        void _ResetDefaultValues()
        {
            lblRentalBookingID.Text = "[????]";
            lblCustomerID.Text = "[????]";
            lblCustomerName.Text = "[????]";
            lblStatus.Text = "[????]";
            lblVehicleID.Text = "[????]";
            lblVehicleModel.Text = "[????]";

            txtPickUpLocation.Text = "";
            txtDropOffLocation.Text = "";
            txtVehicleConditionNotes.Text = "";

            dtpRentedAt.Value = DateTime.Now;
            dtpDueDate.Value = DateTime.Now;

            btnSave.Enabled = false;

            if (mode == enMode.AddNew)
            {
                this.Text = "Add New Booking";
                lblMode.Text = "Add New Booking";
                _BookingInfo = new clsRentalBooking();
                return;
            }

            this.Text = "Update Booking";
            lblMode.Text = "Update Booking";
        }

        private void tpRentalInfo_Click(object sender, EventArgs e)
        {
            if (!IsCustomerAndVehicleDataAreValid())
                tcAddEditRentalBooking.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There is Missing Data, Please check.",
                    "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _BookingInfo.CustomerID = CustomerID;
            _BookingInfo.VehicleID = VehicleID;
            _BookingInfo.PickUpLocation = txtPickUpLocation.Text;
            _BookingInfo.DropOffLocation = txtDropOffLocation.Text;
            _BookingInfo.VehicleConditionNotes = txtVehicleConditionNotes.Text;
            _BookingInfo.RentedAt = dtpRentedAt.Value;
            _BookingInfo.DueDate = dtpDueDate.Value;
            _BookingInfo.Status = (byte)clsRentalBooking.enStatus.Pending;
            if (_BookingInfo.Save())
            {
                _BookingID = _BookingInfo.RentalBookingID;
                MessageBox.Show("Data Saved Successfully",
                    "Save Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _BookingInfo.RentalBookingID);
                frmAddEditPayment addEditPayment = new frmAddEditPayment(_BookingID);
                addEditPayment.ShowDialog();
                
            }

            if (mode == enMode.AddNew)
            {
                lblMode.Text = "Update Booking";
                this.Text = "Update Booking";
                lblRentalBookingID.Text = _BookingInfo.RentalBookingID.ToString();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tcAddEditRentalBooking.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private bool IsCustomerAndVehicleDataAreValid()
        {
            if (CustomerID == -1 || VehicleID == -1)
            {
                MessageBox.Show("Select Customer and Vehicle first",
                   "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (mode ==enMode.AddNew && !ctrlVehicleDetailsWithFilter1.SelectedVehicleInfo.IsAvailable())
            {
                MessageBox.Show("Select Vehicle is not available right now",
                  "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (IsCustomerAndVehicleDataAreValid())
                tcAddEditRentalBooking.SelectedIndex = 1;
        }
    }
}
