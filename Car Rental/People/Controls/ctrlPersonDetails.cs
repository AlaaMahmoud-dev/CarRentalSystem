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

namespace Car_Rental.People.Controls
{
    public partial class ctrlPersonDetails : UserControl
    {
        private int _PersonID;
        public int PersonID
        {
            get
            {
                return _PersonID;
            }
        }
        private clsPerson _PersonInfo;

        public clsPerson SelectedPersonInfo
        {
            get
            {
                return _PersonInfo;
            }
        }
        public ctrlPersonDetails()
        {
            InitializeComponent();
        }
        private void _ResetDefaultValues()
        {
            _PersonID = -1;
            _PersonInfo = new clsPerson();
            lblDateOfBirth.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblGendor.Text = "[????]";
            lblName.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblPersonID.Text = "[????]";
            llEditInfo.Visible = false;
        }

        private void _FillPersonInfo()
        {
            llEditInfo.Visible = true;
            this._PersonID = _PersonInfo.ID;
            lblPersonID.Text = _PersonInfo.ID.ToString();
            lblName.Text = _PersonInfo.FullName;
            lblNationalNo.Text = _PersonInfo.NationalNo.ToString();
            lblPhone.Text = _PersonInfo.Phone.ToString();
            lblEmail.Text = _PersonInfo.Email.ToString();
            lblGendor.Text = _PersonInfo.GenderCaption;
            lblDateOfBirth.Text = _PersonInfo.DateOfBirth.ToString("yyyy/MMM/dd");

        }

        public void FillPersonInfo(int PersonID)
        {

            _PersonInfo = clsPerson.FindPersonByID(PersonID);

            if (_PersonInfo == null)
            {
                _ResetDefaultValues();
                MessageBox.Show("Person With ID [" + PersonID + "] is not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _FillPersonInfo();

            }

        }
        public void FillPersonInfo(string NationalNo)
        {

            _PersonInfo = clsPerson.FindPersonByNationalNo(NationalNo);

            if (_PersonInfo == null)
            {
                _ResetDefaultValues();
                MessageBox.Show("Person With NationalNo [" + NationalNo + "] is not Found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _FillPersonInfo();

            }

        }
        void PersonInfoUpdated(object sender, int PersonID)
        {
            FillPersonInfo(PersonID);
        }

        private void llEditInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_PersonInfo != null)
            {
                frmAddEdit addEdit = new frmAddEdit(_PersonID);
                addEdit.DataBack += PersonInfoUpdated;
                addEdit.ShowDialog();
            }
        }
    }
}
