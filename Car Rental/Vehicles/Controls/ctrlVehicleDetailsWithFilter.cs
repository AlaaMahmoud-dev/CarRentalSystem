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
    public partial class ctrlVehicleDetailsWithFilter : UserControl
    {
        public event Action<int> OnVehicleSelected;
        protected virtual void VehicleSelected(int VehicleID)
        {
            Action<int> handler = OnVehicleSelected;
            if (handler != null)
            {
                handler(VehicleID);
            }
        }

        public int VehicleID
        {
            get { return ctrlVehicleDetails1.VehicleID; }
        }

        public clsVehicle SelectedVehicleInfo
        {
            get { return ctrlVehicleDetails1.SelectedVehicleInfo; }
        }

        bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        string _cbFilterSelectedItem = "";
        public string cbFilterSelectedItem
        {
            get { return _cbFilterSelectedItem; }
            set
            {
                _cbFilterSelectedItem = value;
                cbFilterBy.SelectedItem = _cbFilterSelectedItem;
            }
        }

        string _txtFilterValue = "";
        public string txtFilterValue
        {
            get { return _txtFilterValue; }
            set
            {
                _txtFilterValue = value;
                txtFilterBy.Text = _txtFilterValue;
            }
        }

        public ctrlVehicleDetailsWithFilter()
        {
            InitializeComponent();
            
        }
        public void FillVehicleInfo(int VehicleID)
        {
            FilterEnabled = false;
            cbFilterBy.SelectedItem = "VehicleID";
            txtFilterBy.Text = VehicleID.ToString();
            _FindNow();
        }

        public void FillVehicleInfo(string PlateNumber)
        {
            FilterEnabled = false;
            cbFilterBy.SelectedItem = "Plate Number";
            txtFilterBy.Text = PlateNumber;
            _FindNow();
        }

        void _LoadData()
        {
            cbFilterBy.Items.Add("VehicleID");
            cbFilterBy.Items.Add("Plate Number");
            cbFilterBy.SelectedIndex = 0;
            gbFilter.Enabled = true;
            txtFilterBy.Focus();
            btnSearch.Enabled = false;
        }
        private void _FindNow()
        {
            switch (cbFilterBy.SelectedItem.ToString())
            {
                case "VehicleID":
                    ctrlVehicleDetails1.FillVehicleInfo(int.Parse(txtFilterBy.Text.ToString()));
                    break;

                case "Plate Number":
                    ctrlVehicleDetails1.FillVehicleInfo(txtFilterBy.Text.Trim());
                    break;

                default:
                    break;
            }

            if (OnVehicleSelected != null && gbFilter.Enabled == true)
            {
                OnVehicleSelected(ctrlVehicleDetails1.VehicleID);
            }
        }

        private void ctrlVehicleDetailsWithFilter_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterBy.Focus();
            txtFilterBy.Enabled = (cbFilterBy.SelectedItem != null);
            txtFilterBy.Text = "";
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = (txtFilterBy.Enabled && !string.IsNullOrEmpty(txtFilterBy.Text.ToString()));
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
                return;
            }

            if (cbFilterBy.SelectedItem != null &&
                cbFilterBy.SelectedItem.ToString() == "VehicleID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _FindNow();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditVehicle addEdit = new frmAddEditVehicle(-1);
            addEdit.DataBack += NewVehicleAdded;
            addEdit.ShowDialog();
        }

        private void NewVehicleAdded(object sender, int VehicleID)
        {
            cbFilterBy.SelectedItem = "VehicleID";
            txtFilterBy.Text = VehicleID.ToString();
            _FindNow();

        }
    }
}
