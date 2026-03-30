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

namespace Car_Rental.Vehicles
{
    public partial class frmAddEditVehicle : Form
    {
        public delegate void DataBackEventHandler(object sender, int VehicleID);
        public event DataBackEventHandler DataBack;

        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        enMode mode = enMode.AddNew;
        int _VehicleID = -1;
        clsVehicle _VehicleInfo;

        public frmAddEditVehicle(int VehicleID)
        {
            InitializeComponent(); 
            if (VehicleID == -1)
            {
                mode = enMode.AddNew;
            }
            else
            {
                mode = enMode.Update;
                this._VehicleID = VehicleID;
            }
        }
        void _LoadData()
        {
            _VehicleInfo = clsVehicle.FindVehicleByID(_VehicleID);

            if (_VehicleInfo == null)
            {
                MessageBox.Show("Can't find Vehicle with ID[" + _VehicleID + "]!!",
                    "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            txtPlateNumber.Text = _VehicleInfo.PlateNumber;
            txtMileage.Text = _VehicleInfo.Mileage.ToString();
            txtRentalCostPerDay.Text = _VehicleInfo.RentalCostPerDay.ToString();

            cbFuelType.SelectedItem = _VehicleInfo.FuelTypeInfo.FuelTypeName;

            cbCategories.SelectedItem = _VehicleInfo.VehicleCategoryInfo.CategoryName;
            cbMakes.SelectedItem = _VehicleInfo.ModelInfo.MakeInfo.MakeName;
            cbModels.SelectedItem = _VehicleInfo.ModelInfo.ModelName;
          
        }
        void _ResetDefaultValues()
        {
            cbMakes.SelectedIndex = 0;
            cbModels.SelectedIndex = 0;
            cbCategories.SelectedIndex = 0;
            cbFuelType.SelectedIndex = 0;
            txtPlateNumber.Text = "";
            txtMileage.Text = "";
            txtRentalCostPerDay.Text = "";

            lblVehicleID.Text = "[????]";

            if (mode == enMode.AddNew)
            {
                this.Text = "Add New Vehicle";
                lblMode.Text = "Add New Vehicle";
                _VehicleInfo = new clsVehicle();
                return;
            }

            lblMode.Text = "Update Vehicle";
            this.Text = "Update Vehicle";
        }

        void _LoadMakes()
        {
            DataTable dt = clsVehicleMake.GetAllVehicleMakes();

            foreach (DataRow row in dt.Rows)
            {
                cbMakes.Items.Add(row["MakeName"]);
            }
            cbMakes.SelectedIndex = 0;
        }

        void _LoadCategories()
        {
            DataTable dt = clsVehicleCategory.GetAllVehicleCategories();

            foreach (DataRow row in dt.Rows)
            {
                cbCategories.Items.Add(row["CategoryName"]);
            }
            cbCategories.SelectedIndex = 0;

        }

        void _LoadFuelTypes()
        {
            DataTable dt = clsFuelType.GetAllFuelTypes();

            foreach (DataRow row in dt.Rows)
            {
                cbFuelType.Items.Add(row["FuelTypeName"]);
            }
            cbFuelType.SelectedIndex = 0;

        }

        void _LoadModels()
        {
            cbModels.Items.Clear();
            int MakeID = clsVehicleMake.FindVehicleMakeByName(cbMakes.SelectedItem.ToString()).MakeID;
            DataTable dt = clsVehicleModel.GetModelsByMakeID(MakeID);

            foreach (DataRow row in dt.Rows)
            {
                cbModels.Items.Add(row["ModelName"]);
            }
            cbModels.SelectedIndex = 0;

        }

        private void frmAddEditVehicle_Load(object sender, EventArgs e)
        {
            _LoadMakes();
            _LoadModels();
            _LoadCategories();
            _LoadFuelTypes();

            _ResetDefaultValues();

            if (mode == enMode.Update)
                _LoadData();
        }

        private void cbMakes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _LoadModels();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There is Missing Data, Please check.",
                   "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsVehicleModel vehicleModel = clsVehicleModel.FindVehicleModelByName(cbModels.SelectedItem.ToString());
            clsVehicleCategory vehicleCategory = clsVehicleCategory.FindVehicleCategoryByName(cbCategories.SelectedItem.ToString());
            clsFuelType fuel = clsFuelType.FindFuelTypeByName(cbFuelType.SelectedItem.ToString());

            _VehicleInfo.ModelID = vehicleModel.ModelID;
            _VehicleInfo.Mileage = int.Parse(txtMileage.Text);
            _VehicleInfo.PlateNumber = txtPlateNumber.Text;
            _VehicleInfo.RentalCostPerDay = decimal.Parse(txtRentalCostPerDay.Text);
            _VehicleInfo.FuelType = fuel.FuelTypeID;
            _VehicleInfo.VehicleCategory = vehicleCategory.CategoryID;
            _VehicleInfo.Status = (byte)clsVehicle.enStatus.Available;

            if (_VehicleInfo.Save())
            {
                _VehicleID = _VehicleInfo.VehicleID;
                MessageBox.Show("Data Saved Successfully", "Save Completed",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _VehicleInfo.VehicleID);
            }

            if (mode == enMode.AddNew)
            {
                mode = enMode.Update;
                lblMode.Text = "Update Vehicle";
                this.Text = "Update Vehicle";
                lblVehicleID.Text = _VehicleInfo.VehicleID.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
