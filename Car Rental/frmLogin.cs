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

namespace Car_Rental
{
    public partial class frmLogin : Form
    {
        frmMain MainScreen;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string Username = "";
            string Password = "";
            if (clsGlobal.GetStoredCredential(ref Username, ref Password))
            {
                txtUserName.Text = Username;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else
            {
                chkRememberMe.Checked = false;

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Missing Data, Please check red icons.",
                    "Now Allowed, Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            clsUser LoggedUser = clsUser.FindUserByUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            if (LoggedUser == null)
            {
                MessageBox.Show("Invalid UserName/Password!!", "Wrong credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!LoggedUser.IsActive)
            {
                MessageBox.Show("Your Account is Deactivated Please Contact Your Admin!!", "Deactivated User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (chkRememberMe.Checked)
            {
                clsGlobal.RememberUsernameAndPassword(txtUserName.Text.ToString().Trim(), txtPassword.Text.ToString().Trim());
            }
            else
            {
                clsGlobal.RememberUsernameAndPassword("", "");
            }
            CR_Settings.CurrentUser = LoggedUser;
            //this.Close();
            this.Hide();
            MainScreen = new frmMain(this);
            MainScreen.Show();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text.Trim()))
            {
                errorProvider1.SetError(txtUserName, "Please enter username.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtUserName, null);
                e.Cancel = false;
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtPassword, "Please enter password.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(txtPassword, null);
                e.Cancel = false;
            }
        }
    }
}

