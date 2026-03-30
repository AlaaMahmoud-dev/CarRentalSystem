using Car_Rental.People.Controls;
using CarRental_BusinessLayar;
using DVLD_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Rental.Customers.Controls
{
    public partial class ctrlCustomerDetailsWithFilter : UserControl
    {
        public event Action<int> OnCustomerSelected;
        protected virtual void CustomerSelected(int CustomerID)
        {
            Action<int> hundler = OnCustomerSelected;
            if (hundler != null)
            {
                hundler(CustomerID);
            }
        }
        public int CustomerID
        {
            get
            {
                return ctrlCustomerDetails1.CustomerID;
            }
        }

        public clsCustomer SelectedCustomerInfo
        {
            get
            {
                return ctrlCustomerDetails1.CustomerInfo;
            }
        }

        bool _FilterEnabled = true;

        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }

        }
        string _cbFilterSelectedItem = "";
        public string cbFilterSelectedItem
        {
            get
            {
                return _cbFilterSelectedItem;
            }
            set
            {
                _cbFilterSelectedItem = value;
                cbFilterBy.SelectedItem = _cbFilterSelectedItem;
            }
        }
        string _txtFilterValue = "";
        public string txtFilterValue
        {
            get
            {
                return _txtFilterValue;
            }
            set
            {
                _txtFilterValue = value;
                txtFilterBy.Text = _txtFilterValue;
            }
        }

        public ctrlCustomerDetailsWithFilter()
        {
            InitializeComponent();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            _FindNow();
        }

      

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
                return;
            }
            if (cbFilterBy.SelectedItem != null
                && (cbFilterBy.SelectedItem.ToString() == "PersonID" || cbFilterBy.SelectedItem.ToString() == "CustomerID"))
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer addEdit = new frmAddEditCustomer(-1);
            addEdit.DataBack += NewCustomerAdded;
            addEdit.ShowDialog();
        }
        private void NewCustomerAdded(object sender, int CustomerID)
        {

            cbFilterBy.SelectedItem = "CustomerID";
            txtFilterBy.Text = CustomerID.ToString();
            _FindNow();

        }
        private void _FindNow()
        {
            switch (cbFilterBy.SelectedItem.ToString())
            {
                case "CustomerID":
                    ctrlCustomerDetails1.LoadCustomerInfoByID(int.Parse(txtFilterBy.Text.ToString()));
                    break;
                case "PersonID":
                    ctrlCustomerDetails1.LoadCustomerInfoByPersonID(int.Parse(txtFilterBy.Text.ToString()));
                    break;
                case "National No":
                    clsPerson PersonINfo = clsPerson.FindPersonByNationalNo(txtFilterBy.Text.ToString());
                    if(PersonINfo!=null)
                    ctrlCustomerDetails1.LoadCustomerInfoByPersonID(
                       PersonINfo.ID);
                    break;
                default:
                    break;

            }

            if (OnCustomerSelected != null && gbFilter.Enabled == true)
            {
                OnCustomerSelected(ctrlCustomerDetails1.CustomerID);

            }
        }
        void _LoadData()
        {
            cbFilterBy.Items.Add("CustomerID");
            cbFilterBy.Items.Add("PersonID"); cbFilterBy.Items.Add("National No");
            cbFilterBy.SelectedIndex = 0;
            gbFilter.Enabled = true;
            txtFilterBy.Focus();
            btnSearch.Enabled = false;

        }

        private void ctrlCustomerDetailsWithFilter_Load(object sender, EventArgs e)
        {
            _LoadData();
        }
        public void FillCustomerInfoByPersonID(int PersonID)
        {
            FilterEnabled = false;
            cbFilterBy.SelectedItem = "PersonID";
            txtFilterBy.Text = PersonID.ToString();
            _FindNow();

        }
        public void FillCustomerInfoByCustomerID(int CustomerID)
        {
            FilterEnabled = false;
            cbFilterBy.SelectedItem = "CustomerID";
            txtFilterBy.Text = CustomerID.ToString() ;
            _FindNow();
        }
        public void FillCustomerInfoByNationalNo(string NationalNo)
        {
            FilterEnabled = false;
            cbFilterBy.SelectedItem = "National No";
            txtFilterBy.Text = NationalNo;
            _FindNow();
        }
    }
}
