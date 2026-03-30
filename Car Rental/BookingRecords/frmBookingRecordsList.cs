using Car_Rental.Payments;
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

namespace Car_Rental.BookingRecords
{
    public partial class frmBookingRecordsList : Form
    {
        DataTable _dtAllBookings;
        DataTable _dtBookings;

        public frmBookingRecordsList()
        {
            InitializeComponent();
        }
        private void _dgvFillBookings()
        {
            _dtAllBookings = clsRentalBooking.GetAllBookings(); 

            _dtBookings = _dtAllBookings.DefaultView.ToTable(false,
                "VehicleBookRecordID",
                "PaymentID",
                "NationalNo",
                "FullName",
                "RentedAt",
                "DueDate",
                "PickUpLocation",
                "DropOffLocation",
                "Status",
                "VehicleConditionNotes",
                "InitialAmount",
                "InitialPaidAmount",
                "TotalActualDueAmount"
            );

            dgvBookingsList.DataSource = _dtBookings.DefaultView;

            if (dgvBookingsList.Rows.Count > 0)
            {
                dgvBookingsList.Columns[0].HeaderText = "ID";
                dgvBookingsList.Columns[0].Width = 70;

                dgvBookingsList.Columns[1].HeaderText = "PayID";
                dgvBookingsList.Columns[1].Width = 80;

                dgvBookingsList.Columns[2].HeaderText = "NatNo";
                dgvBookingsList.Columns[2].Width = 120;

                dgvBookingsList.Columns[3].HeaderText = "Customer";
                dgvBookingsList.Columns[3].Width = 200;

                dgvBookingsList.Columns[4].HeaderText = "Rented";
                dgvBookingsList.Columns[4].Width = 110;

                dgvBookingsList.Columns[5].HeaderText = "Due";
                dgvBookingsList.Columns[5].Width = 110;

                dgvBookingsList.Columns[6].HeaderText = "PickUp";
                dgvBookingsList.Columns[6].Width = 150;

                dgvBookingsList.Columns[7].HeaderText = "DropOff";
                dgvBookingsList.Columns[7].Width = 150;

                dgvBookingsList.Columns[8].HeaderText = "Status";
                dgvBookingsList.Columns[8].Width = 100;

                dgvBookingsList.Columns[9].HeaderText = "Notes";
                dgvBookingsList.Columns[9].Width = 150;

                dgvBookingsList.Columns[10].HeaderText = "Init Amt";
                dgvBookingsList.Columns[10].Width = 100;

                dgvBookingsList.Columns[11].HeaderText = "Paid";
                dgvBookingsList.Columns[11].Width = 100;

                dgvBookingsList.Columns[12].HeaderText = "Total";
                dgvBookingsList.Columns[12].Width = 100;
            }

            lblRecordsCount.Text = dgvBookingsList.RowCount.ToString();
        }
        private void _LoadData()
        {
            _dgvFillBookings();

            cbFilterBy.Items.Add("None");
            cbFilterBy.Items.Add("Booking ID");
            cbFilterBy.Items.Add("Customer");
            cbFilterBy.Items.Add("National No");
            cbFilterBy.Items.Add("Status");

            cbFilterBy.SelectedItem = "None";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBookingRecordsList_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string Filtering_Item;

            switch (cbFilterBy.SelectedItem)
            {
                case "Booking ID":
                    Filtering_Item = "VehicleBookRecordID";
                    break;
                case "Customer":
                    Filtering_Item = "FullName";
                    break;
                case "National No":
                    Filtering_Item = "NationalNo";
                    break;
                case "Status":
                    Filtering_Item = "Status";
                    break;
                default:
                    Filtering_Item = "None";
                    break;
            }

            if (string.IsNullOrWhiteSpace(txtFilterBy.Text.Trim()))
            {
                _dtBookings.DefaultView.RowFilter = "";
                return;
            }

            if (Filtering_Item == "VehicleBookRecordID")
            {
                _dtBookings.DefaultView.RowFilter =
                    string.Format("{0}={1}", Filtering_Item, int.Parse(txtFilterBy.Text.Trim()));
            }
            else
            {
                _dtBookings.DefaultView.RowFilter =
                    string.Format("{0} LIKE '{1}%'", Filtering_Item, txtFilterBy.Text.Trim());
            }

            lblRecordsCount.Text = dgvBookingsList.RowCount.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtBookings.DefaultView.RowFilter = "";
            txtFilterBy.Visible = cbFilterBy.SelectedItem.ToString() != "None";
        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem != null &&
          cbFilterBy.SelectedItem.ToString() == "Booking ID")
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditRentalBooking addEdit = new frmAddEditRentalBooking(-1);
            addEdit.ShowDialog();
            _dgvFillBookings();
        }

       

        private void ShowDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmShowRentalBookingDetails frm =
         new frmShowRentalBookingDetails(
             Convert.ToInt32(dgvBookingsList.CurrentRow.Cells[0].Value));

            frm.ShowDialog();
        }

        private void addNewToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            frmAddEditRentalBooking addEdit = new frmAddEditRentalBooking(-1);
            addEdit.ShowDialog();
            _dgvFillBookings();
        }

        private void editToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmAddEditRentalBooking addEdit =
          new frmAddEditRentalBooking(
              Convert.ToInt32(dgvBookingsList.CurrentRow.Cells[0].Value));

            addEdit.ShowDialog();
            _dgvFillBookings();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookingID = int.Parse(dgvBookingsList.CurrentRow.Cells[0].Value.ToString());

            if (MessageBox.Show("Are you sure you want to delete booking [" + BookingID + "]?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsRentalBooking.DeleteBooking(BookingID))
                {
                    MessageBox.Show("Deleted Successfully");
                    _dgvFillBookings();
                }
                else
                {
                    MessageBox.Show("Delete Failed");
                }
            }
        }

        private void payNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookingID = int.Parse(dgvBookingsList.CurrentRow.Cells[0].Value.ToString());
            frmAddEditPayment addEditPayment = new frmAddEditPayment(BookingID);
            addEditPayment.ShowDialog();
            _dgvFillBookings();

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            showPaymentDetailsToolStripMenuItem.Enabled = int.Parse(dgvBookingsList.CurrentRow.Cells[1].Value.ToString()) != -1;

        }

        private void showPaymentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPaymentInfo showPaymentInfo = new
                 frmShowPaymentInfo(int.Parse(dgvBookingsList.CurrentRow.Cells[1].Value.ToString()));
            showPaymentInfo.ShowDialog();

        }
    }
}
