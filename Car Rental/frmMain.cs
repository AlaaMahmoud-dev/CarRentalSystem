using Car_Rental.BookingRecords;
using Car_Rental.Customers;
using Car_Rental.ReturnRecords;
using Car_Rental.Vehicles;
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

namespace Car_Rental
{
    public partial class frmMain : Form
    {
        frmLogin LoginScreen;
        public frmMain(frmLogin loginScreen)
        {
            InitializeComponent();
            LoginScreen = loginScreen;
        }

      
        private void rentalBookingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBookingRecordsList bookingsList = new frmBookingRecordsList();
            bookingsList.ShowDialog();
        }

        private void newRntalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditRentalBooking addEditRentalBooking = new frmAddEditRentalBooking(-1);
            addEditRentalBooking.ShowDialog();
        }

        private void vehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomersList customersList = new frmCustomersList();
            customersList.ShowDialog();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManagePeople managePeople = new frmManagePeople();
            managePeople.ShowDialog();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void addNewCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditCustomer addEditCustomer = new frmAddEditCustomer(-1);
            addEditCustomer.ShowDialog();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUser addEditUser = new frmAddEditUser(-1);
            addEditUser.ShowDialog();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEdit addEdit = new frmAddEdit(-1);
            addEdit.ShowDialog();
        }

        private void returnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVehicleReturnRecordsList returnRecordsList = new frmVehicleReturnRecordsList();
            returnRecordsList.ShowDialog();
        }

        private void returnVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditReturnRecord addEditReturnRecord = new frmAddEditReturnRecord(-1);
            addEditReturnRecord.ShowDialog();
        }

        private void manageVehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVehiclesList vehiclesList = new frmVehiclesList();
            vehiclesList.ShowDialog();
        }

        private void addNewVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditVehicle addEditVehicle = new frmAddEditVehicle(-1);
            addEditVehicle.ShowDialog();
        }

        private void manageUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers users = new frmManageUsers();
            users.ShowDialog();
        }

        private void addNewUserToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAddEditUser addEditUser = new frmAddEditUser(-1);
            addEditUser.ShowDialog();
        }

        private void showLoggedInUserDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmShowUserDetails showUserDetails = new frmShowUserDetails(CR_Settings.CurrentUser.UserID);
            //showUserDetails.ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CR_Settings.CurrentUser=null;
            this.Close();
            LoginScreen.Show();
        }
    }
}
