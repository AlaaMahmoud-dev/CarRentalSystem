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

namespace Car_Rental.Customers
{
    public partial class frmCustomersList : Form
    {
        DataTable _dtAllCustomers;
        DataTable _dtCustomers;
        public frmCustomersList()
        {
            InitializeComponent();
        }
        private void _dgvFillCustomers()
        {
            
            _dtAllCustomers = clsCustomer.CustomersList();
            _dtCustomers = _dtAllCustomers.DefaultView.ToTable(false, "CustomerID", "NationalNo", "FullName"
                , "DriverLicenseNumber", "LicenseClass","LicenseExpiryDate");
            dgvCustomersList.DataSource = _dtCustomers.DefaultView;
            if (dgvCustomersList.Rows.Count > 0)
            {
                dgvCustomersList.Columns[0].HeaderText = "Customer ID";
                dgvCustomersList.Columns[0].Width = 120;
                dgvCustomersList.Columns[1].HeaderText = "National No";
                dgvCustomersList.Columns[1].Width = 120;
                dgvCustomersList.Columns[2].HeaderText = "Full Name";
                dgvCustomersList.Columns[2].Width = 450;
                dgvCustomersList.Columns[3].HeaderText = "License Number";
                dgvCustomersList.Columns[3].Width = 150;
                dgvCustomersList.Columns[4].HeaderText = "License Class";
                dgvCustomersList.Columns[4].Width = 150;
                dgvCustomersList.Columns[5].HeaderText = "L.Expiry Date";
                dgvCustomersList.Columns[5].Width = 150;
              
              
        }
            lblCustomersCount.Text = (dgvCustomersList.RowCount).ToString();


        }
        private void _LoadData()
        {
            _dgvFillCustomers();
            cbFilterBy.Items.Add("None");
            cbFilterBy.Items.Add("Customer ID");
            cbFilterBy.Items.Add("National No");
            cbFilterBy.Items.Add("Full Name");
            cbFilterBy.Items.Add("License Number");
            cbFilterBy.Items.Add("License Class");
            cbFilterBy.SelectedItem = "None";

        }
        private void frmCustomersList_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtCustomers.DefaultView.RowFilter = "";
            txtFilterBy.Visible = cbFilterBy.SelectedItem.ToString() != "None";

        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {

            string Filtering_Item;
            switch (cbFilterBy.SelectedItem)
            {
                case "Customer ID":
                    Filtering_Item = "CustomerID";
                    break;
                case "National No":
                    Filtering_Item = "NationalNo";
                    break;
                case "Full Name":
                    Filtering_Item = "FullName";
                    break;
                case "License Number":
                    Filtering_Item = "DriverLicenseNumber";
                    break;
                case "License Class":
                    Filtering_Item = "LicenseClass";
                    break;
               
                default:
                    Filtering_Item = "None";
                    break;

            }
            if (string.IsNullOrWhiteSpace(txtFilterBy.Text.Trim()))
            {
                _dtCustomers.DefaultView.RowFilter = "";
                return;
            }

            if (Filtering_Item == "CustomerID"|| Filtering_Item == "LicenseClass")
            {
                _dtCustomers.DefaultView.RowFilter = string.Format("{0}={1}", Filtering_Item, int.Parse(txtFilterBy.Text.Trim()));

            }
            else
            {
                _dtCustomers.DefaultView.RowFilter = string.Format("{0} LIKE '{1}%'", Filtering_Item, txtFilterBy.Text.Trim());

            }
            lblCustomersCount.Text = dgvCustomersList.RowCount.ToString();
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem != null && (cbFilterBy.SelectedItem.ToString() == "Customer ID"|| cbFilterBy.SelectedItem.ToString() == "License Class"))
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer addEditCustomer = new frmAddEditCustomer(-1);
            addEditCustomer.ShowDialog();
            _dgvFillCustomers();
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowCustomerDetails showCustomerDetails = new frmShowCustomerDetails(
                Convert.ToInt32(dgvCustomersList.CurrentRow.Cells[0].Value));
            showCustomerDetails.ShowDialog();
        }

        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer addEditCustomer = new frmAddEditCustomer(-1);
            addEditCustomer.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer addEditCustomer = new frmAddEditCustomer(
                Convert.ToInt32(dgvCustomersList.CurrentRow.Cells[0].Value));
            addEditCustomer.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int CustomerID = int.Parse(dgvCustomersList.CurrentRow.Cells[0].Value.ToString());
            if (MessageBox.Show("Are you sure you want to delete customer with ID [" + CustomerID + "]??",
               "Confirmation Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               == DialogResult.Yes)
            {
                if (clsCustomer.DeleteCustomer(CustomerID))
                {
                    MessageBox.Show("Customer With ID [" + CustomerID.ToString() + "] Deleted Successfully");
                    _dgvFillCustomers();
                }
                else
                {
                    MessageBox.Show("Deleting Customer With ID [" + CustomerID.ToString() + "]was not Completed Successfully");
                }
            }
        }
    }
}
