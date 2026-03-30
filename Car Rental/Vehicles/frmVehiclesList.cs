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
    public partial class frmVehiclesList : Form
    {
        DataTable _dtAllVehicles;
        DataTable _dtVehicles;

        public frmVehiclesList()
        {
            InitializeComponent();
        }
        private void _dgvFillVehicles()
        {
            _dtAllVehicles = clsVehicle.GetAllVehicles();

            _dtVehicles = _dtAllVehicles.DefaultView.ToTable(false,
                "VehicleID",
                "MakeName",
                "ModelName",
                "Year",
                "PlateNumber",
                "Mileage",
                "RentalCostPerDay",
                "Status",
                "FuelTypeName",
                "CategoryName"
            );

            dgvVehiclesList.DataSource = _dtVehicles.DefaultView;

            if (dgvVehiclesList.Rows.Count > 0)
            {
                dgvVehiclesList.Columns[0].HeaderText = "ID";
                dgvVehiclesList.Columns[0].Width = 70;

                dgvVehiclesList.Columns[1].HeaderText = "Make";
                dgvVehiclesList.Columns[1].Width = 120;

                dgvVehiclesList.Columns[2].HeaderText = "Model";
                dgvVehiclesList.Columns[2].Width = 140;

                dgvVehiclesList.Columns[3].HeaderText = "Year";
                dgvVehiclesList.Columns[3].Width = 80;

                dgvVehiclesList.Columns[4].HeaderText = "Plate";
                dgvVehiclesList.Columns[4].Width = 120;

                dgvVehiclesList.Columns[5].HeaderText = "KM";
                dgvVehiclesList.Columns[5].Width = 100;

                dgvVehiclesList.Columns[6].HeaderText = "Price/Day";
                dgvVehiclesList.Columns[6].Width = 120;

                dgvVehiclesList.Columns[7].HeaderText = "Status";
                dgvVehiclesList.Columns[7].Width = 100;

                dgvVehiclesList.Columns[8].HeaderText = "Fuel";
                dgvVehiclesList.Columns[8].Width = 100;

                dgvVehiclesList.Columns[9].HeaderText = "Category";
                dgvVehiclesList.Columns[9].Width = 120;
            }

            lblVehiclesCount.Text = dgvVehiclesList.RowCount.ToString();
        }
        private void _LoadData()
        {
            _dgvFillVehicles();

            cbFilterBy.Items.Add("None");
            cbFilterBy.Items.Add("Vehicle ID");
            cbFilterBy.Items.Add("Make");
            cbFilterBy.Items.Add("Model");
            cbFilterBy.Items.Add("Plate");
            cbFilterBy.Items.Add("Status");
            cbFilterBy.Items.Add("Fuel");
            cbFilterBy.Items.Add("Category");

            cbFilterBy.SelectedItem = "None";
        }
        private void frmVehiclesList_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string Filtering_Item;

            switch (cbFilterBy.SelectedItem)
            {
                case "Vehicle ID":
                    Filtering_Item = "VehicleID";
                    break;
                case "Make":
                    Filtering_Item = "MakeName";
                    break;
                case "Model":
                    Filtering_Item = "ModelName";
                    break;
                case "Plate":
                    Filtering_Item = "PlateNumber";
                    break;
                case "Status":
                    Filtering_Item = "Status";
                    break;
                case "Fuel":
                    Filtering_Item = "FuelTypeName";
                    break;
                case "Category":
                    Filtering_Item = "CategoryName";
                    break;
                default:
                    Filtering_Item = "None";
                    break;
            }

            if (string.IsNullOrWhiteSpace(txtFilterBy.Text.Trim()))
            {
                _dtVehicles.DefaultView.RowFilter = "";
                return;
            }

            if (Filtering_Item == "VehicleID")
            {
                _dtVehicles.DefaultView.RowFilter =
                    string.Format("{0}={1}", Filtering_Item, int.Parse(txtFilterBy.Text.Trim()));
            }
            else
            {
                _dtVehicles.DefaultView.RowFilter =
                    string.Format("{0} LIKE '{1}%'", Filtering_Item, txtFilterBy.Text.Trim());
            }

            lblVehiclesCount.Text = dgvVehiclesList.RowCount.ToString();
            
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtVehicles.DefaultView.RowFilter = "";
            txtFilterBy.Visible = cbFilterBy.SelectedItem.ToString() != "None";
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem != null &&
           cbFilterBy.SelectedItem.ToString() == "Vehicle ID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowVehicleDetails frm = new frmShowVehicleDetails(
          Convert.ToInt32(dgvVehiclesList.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditVehicle addEdit = new frmAddEditVehicle(-1);
            addEdit.ShowDialog();
            _dgvFillVehicles();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditVehicle addEdit = new frmAddEditVehicle(
            Convert.ToInt32(dgvVehiclesList.CurrentRow.Cells[0].Value));
            addEdit.ShowDialog();
            _dgvFillVehicles();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
             int VehicleID = int.Parse(dgvVehiclesList.CurrentRow.Cells[0].Value.ToString());

        if (MessageBox.Show("Are you sure you want to delete vehicle with ID [" + VehicleID + "]?",
            "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
            if (clsVehicle.DeleteVehicle(VehicleID))
            {
                MessageBox.Show("Vehicle Deleted Successfully");
                _dgvFillVehicles();
            }
            else
            {
                MessageBox.Show("Delete Failed");
            }
        }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditVehicle addEdit = new frmAddEditVehicle(-1);
            addEdit.ShowDialog();
            _dgvFillVehicles();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
