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
using static CarRental_BusinessLayar.clsPerson;

namespace Car_Rental.Customers
{
    public partial class frmAddEditCustomer : Form
    {
        public delegate void DataBackEventHandler(object sender, int CustomerID);


        public event DataBackEventHandler DataBack;
        enum enMode
        {
            AddNew = 1,
            Update = 2
        }

        enMode mode = enMode.AddNew;
        int _PersonID = -1;
        int _CustomerID = -1;
        clsCustomer _CustomerInfo;
        public frmAddEditCustomer(int CustomerID)
        {
            InitializeComponent();

            if (CustomerID == -1)
            {
                mode = enMode.AddNew;

            }
            else
            {
                mode = enMode.Update;
                this._CustomerID = CustomerID;

            }
        }

        private void tpLoginInfo_Click(object sender, EventArgs e)
        {

        }
        private bool MoveToNextPageValidation()
        {
            if (_PersonID == -1)
            {
                tcAddEditCustomer.SelectedIndex = 0;
                MessageBox.Show("Please Select a person first",
                    "Select Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (mode == enMode.AddNew && clsCustomer.IsCustomerExistsForPersonID(_PersonID))
            {
                tcAddEditCustomer.SelectedIndex = 0;
                _PersonID = -1;
                MessageBox.Show("The Selected person is already an Customer",
                    "Customer Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            MoveToNextPageValidation();
        }

        private void ctrlFindPersonByFilter1_OnPersonSelected(int PersonID)
        {
            this._PersonID = PersonID;
            if (PersonID == -1)
            {
                btnSave.Enabled = false;
            }
            else
            {
                if (MoveToNextPageValidation())
                    btnSave.Enabled = true;
            }
        }
        void _LoadData()
        {

            _CustomerInfo = clsCustomer.FindCustomerByCustomerID(_CustomerID);
            if (_CustomerInfo == null)
            {
                MessageBox.Show("Can't find customer with ID[" + _CustomerID + "]!!",
                    "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrlFindPersonByFilter1.FillPersonInfo(_CustomerInfo.PersonID);
            txtDriverLicenseNumber.Text = _CustomerInfo.DriverLicenseNumber.ToString();
            lblCreatedAt.Text = _CustomerInfo.CreatedAt.ToString("yyyy/MM/dd");
            lblCreatedBy.Text = CR_Settings.CurrentUser.Username.ToString();
            lblCustomerID.Text = _CustomerInfo.CustomerID.ToString();
            dtpLicenseIssueDate.Value = _CustomerInfo.LicenseIssueDate
                ==null?DateTime.MinValue: (DateTime)_CustomerInfo.LicenseIssueDate;
            dtpLicenseExpiryDate.Value = _CustomerInfo.LicenseExpiryDate;
        }
        void _ResetDefaultValues()
        {
            cbLicenseClass.SelectedIndex = 0;
            btnSave.Enabled = false;
            txtDriverLicenseNumber.Text = "";
            lblCustomerID.Text = "[????]";
            lblCreatedAt.Text = "[????]";
            lblCreatedBy.Text= "[????]";
            dtpLicenseIssueDate.Text = DateTime.Now.ToString();
            dtpLicenseExpiryDate.Text = DateTime.Now.ToString();
            if (mode == enMode.AddNew)
            {
                this.Text = "Add New Customer";
                lblMode.Text = "Add New Customer";
                ctrlFindPersonByFilter1.FilterEnabled = true;
                _CustomerInfo = new clsCustomer();
                return;

            }
            lblMode.Text = "Update Customer";
            this.Text = "Update Customer";
            ctrlFindPersonByFilter1.FilterEnabled = false;
        }
        private void _LoadLicenseClasses()
        {
            DataTable dtLicenseClasses = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in dtLicenseClasses.Rows)
            {
                cbLicenseClass.Items.Add(row["ClassName"]);
            }
        }
        private void frmAddEditCustomer_Load(object sender, EventArgs e)
        {
            _LoadLicenseClasses();
            _ResetDefaultValues();
            if (mode == enMode.Update)
                _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There is Missing Data, Please check for red icons.",
                   "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _CustomerInfo.PersonID = _PersonID;
            _CustomerInfo.DriverLicenseNumber = txtDriverLicenseNumber.Text.ToString();
            _CustomerInfo.LicenseIssueDate = dtpLicenseIssueDate.Value;
            _CustomerInfo.LicenseExpiryDate = dtpLicenseExpiryDate.Value;
            _CustomerInfo.CreatedAt=mode==enMode.AddNew ? DateTime.Now : _CustomerInfo.CreatedAt;
            _CustomerInfo.CreatedByUserID = mode == enMode.AddNew ? CR_Settings.CurrentUser.UserID : _CustomerInfo.CreatedByUserID;
            _CustomerInfo.LicenseClass = clsLicenseClass.FindLicenseClassByClassName(cbLicenseClass.Text).LicenseClassID;


            if (_CustomerInfo.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Save Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBack?.Invoke(this, _CustomerID);

            }

            if (mode == enMode.AddNew)
            {
                lblMode.Text = "Update Customer Info";
                this.Text = "Update Customer";
                lblCustomerID.Text = _CustomerInfo.CustomerID.ToString();
                ctrlFindPersonByFilter1.FilterEnabled = false;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            tcAddEditCustomer.SelectedTab = tpPersonalInfo;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
