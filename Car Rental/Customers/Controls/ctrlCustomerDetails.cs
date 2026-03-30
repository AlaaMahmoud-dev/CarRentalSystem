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
    public partial class ctrlCustomerDetails : UserControl
    {
        int _CustomerID = -1;
        public int CustomerID
        {
            get
            {
                return _CustomerID;
            }
        }
        clsCustomer _CustomerInfo;
        public clsCustomer CustomerInfo
        {
            get { return _CustomerInfo; }
        }
        public int PersonID
        {
            get
            {
                return ctrlPersonDetails1.PersonID;
            }
        }
        public clsPerson SelectedPersonInfo
        {
            get
            {
                return ctrlPersonDetails1.SelectedPersonInfo;
            }
        }
        public ctrlCustomerDetails()
        {
            InitializeComponent();
        }
        private void _ResetDefaultValues()
        {
            _CustomerID = -1;
            _CustomerInfo = new clsCustomer();
            lblCreatedAt.Text = "[????]";
            lblCreatedBuUsername.Text = "[????]";
            lblCustomerID.Text = "[????]";
            lblLicenseClass.Text = "[????]";
            lblLicenseExpiryDate.Text = "[????]";
            lblLicenseIssueDate.Text = "[????]";
            lblLicenseNumber.Text = "[????]";
            llEditInfo.Visible = false;
        }
        private void _FillCustomerInfo()
        {
            ctrlPersonDetails1.FillPersonInfo(_CustomerInfo.PersonID);
            llEditInfo.Visible = true;
            this._CustomerID = _CustomerInfo.CustomerID;
            lblCustomerID.Text = _CustomerID.ToString();
            lblLicenseNumber.Text = _CustomerInfo.DriverLicenseNumber;
            lblCreatedAt.Text = _CustomerInfo.CreatedAt.ToString("yyyy/MMM/dd");
            lblCreatedBuUsername.Text = _CustomerInfo.CreatedByUserInfo.Username;
            lblLicenseClass.Text = _CustomerInfo.LicenseClassName;
            lblLicenseIssueDate.Text = _CustomerInfo.LicenseIssueDate?.ToString("yyyy/MM/dd") ?? "N/A"; 
            lblLicenseExpiryDate.Text = _CustomerInfo.LicenseExpiryDate.ToString("yyyy/MM/dd");
            lblLicenseNumber.Text = _CustomerInfo.DriverLicenseNumber;

        }

        public void LoadCustomerInfoByID(int CustomerID)
        {
            _CustomerInfo = clsCustomer.FindCustomerByCustomerID(CustomerID);

            if (_CustomerInfo == null)
            {
                _ResetDefaultValues();
                MessageBox.Show("Customer With ID [" + CustomerID + "] is not Found",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _FillCustomerInfo();

            }
        }

        

        public void LoadCustomerInfoByPersonID(int PersonID)
        {
            _CustomerInfo = clsCustomer.FindCustomerByPersonID(PersonID);

            if (_CustomerInfo == null)
            {
                _ResetDefaultValues();
                MessageBox.Show("Person With ID [" + PersonID + "] is not Found",
                    "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _FillCustomerInfo();

            }
        }
        void CustomerInfoUpdated(object sender, int CustomerID)
        {
            LoadCustomerInfoByID(CustomerID);
        }

        private void llEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_CustomerInfo != null)
            {
                frmAddEditCustomer addEdit = new frmAddEditCustomer(_CustomerID);
                addEdit.DataBack += CustomerInfoUpdated;
                addEdit.ShowDialog();
            }
        }
    }
}
