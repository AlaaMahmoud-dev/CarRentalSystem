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

namespace Car_Rental.Vehicles.Controls
{
    public partial class ctrlVehicleDetails : UserControl
    {
        private int _VehicleID = -1;
        public int VehicleID
        {
            get { return _VehicleID; }
        }

        private clsVehicle _VehicleInfo;
        public clsVehicle SelectedVehicleInfo
        {
            get { return _VehicleInfo; }
        }

        public ctrlVehicleDetails()
        {
            InitializeComponent();
            
        }
        private void _ResetDefaultValues()
        {
            _VehicleID = -1;
            _VehicleInfo = new clsVehicle();

            lblVehicleID.Text = "[????]";
            lblModel.Text = "[????]";
            lblMake.Text = "[????]";
            lblMileage.Text = "[????]";
            lblPlateNumber.Text = "[????]";
            lblRentalCostPerDay.Text = "[????]";
            lblStatus.Text = "[????]";
            lblVehicleCategory.Text = "[????]";
            lblFuelType.Text = "[????]";

            llEditInfo.Visible = false;
        }

        private void _FillVehicleInfo()
        {
            llEditInfo.Visible = true;

            this._VehicleID = _VehicleInfo.VehicleID;

            lblVehicleID.Text = _VehicleInfo.VehicleID.ToString();
            lblMileage.Text = _VehicleInfo.Mileage.ToString();
            lblPlateNumber.Text = _VehicleInfo.PlateNumber;
            lblRentalCostPerDay.Text = _VehicleInfo.RentalCostPerDay.ToString();
            lblModel.Text = _VehicleInfo.ModelInfo.ModelName;
            lblMake.Text = _VehicleInfo.ModelInfo.MakeInfo.MakeName;
            lblFuelType.Text = _VehicleInfo.FuelTypeInfo.FuelTypeName;
            lblVehicleCategory.Text = _VehicleInfo.VehicleCategoryInfo.CategoryName;
            lblStatus.Text = _VehicleInfo.StatusCaption;
        }

        public void FillVehicleInfo(int VehicleID)
        {
            
            _VehicleInfo = clsVehicle.FindVehicleByID(VehicleID);

            if (_VehicleInfo == null)
            {
                _ResetDefaultValues();
                MessageBox.Show("Vehicle With ID [" + VehicleID + "] is not Found",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _FillVehicleInfo();
            }
        }
        public void FillVehicleInfo(string PlateNumber)
        {
            _VehicleInfo = clsVehicle.FindVehicleByPlateNumber(PlateNumber);

            if (_VehicleInfo == null)
            {
                _ResetDefaultValues();
                MessageBox.Show("Vehicle With Plate [" + PlateNumber + "] is not Found",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _FillVehicleInfo();
            }
        }
        void VehicleInfoUpdated(object sender, int VehicleID)
        {
            FillVehicleInfo(VehicleID);
        }

        private void llEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void llEditInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_VehicleInfo != null)
            {
                frmAddEditVehicle addEdit = new frmAddEditVehicle(_VehicleID);
                addEdit.DataBack += VehicleInfoUpdated;
                addEdit.ShowDialog();
            }
        }
    }
}
