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

namespace Car_Rental.ReturnRecords
{
    public partial class frmVehicleReturnRecordsList : Form
    {
        DataTable _dtAllReturns;
        DataTable _dtReturns;
        public frmVehicleReturnRecordsList()
        {
            InitializeComponent();
        }
        private void _dgvFillReturns()
        {
            _dtAllReturns = clsReturnRecord.GetAllReturnRecords(); // تأكد تعملها بالـ BL

            _dtReturns = _dtAllReturns.DefaultView.ToTable(false,
                "ReturnRecordID",
                "VehicleBookRecordID",
                "NationalNo",
                "FullName",
                "RentedAt",
                "DueDate",
                "ActualReturnDate",
                "InitialPaidAmount",
                "AdditionalCharges",
                "TotalActualDueAmount"
            );

            dgvReturnRecordsList.DataSource = _dtReturns.DefaultView;

            if (dgvReturnRecordsList.Rows.Count > 0)
            {
                dgvReturnRecordsList.Columns[0].HeaderText = "Ret ID";
                dgvReturnRecordsList.Columns[0].Width = 70;

                dgvReturnRecordsList.Columns[1].HeaderText = "Book ID";
                dgvReturnRecordsList.Columns[1].Width = 80;

                dgvReturnRecordsList.Columns[2].HeaderText = "Nat No";
                dgvReturnRecordsList.Columns[2].Width = 120;

                dgvReturnRecordsList.Columns[3].HeaderText = "Customer";
                dgvReturnRecordsList.Columns[3].Width = 200;

                dgvReturnRecordsList.Columns[4].HeaderText = "Rented";
                dgvReturnRecordsList.Columns[4].Width = 100;

                dgvReturnRecordsList.Columns[5].HeaderText = "Due";
                dgvReturnRecordsList.Columns[5].Width = 100;

                dgvReturnRecordsList.Columns[6].HeaderText = "Returned";
                dgvReturnRecordsList.Columns[6].Width = 110;

                dgvReturnRecordsList.Columns[7].HeaderText = "Paid";
                dgvReturnRecordsList.Columns[7].Width = 100;

                dgvReturnRecordsList.Columns[8].HeaderText = "Extra";
                dgvReturnRecordsList.Columns[8].Width = 100;

                dgvReturnRecordsList.Columns[9].HeaderText = "Total";
                dgvReturnRecordsList.Columns[9].Width = 100;
            }

            lblRecordsCount.Text = dgvReturnRecordsList.RowCount.ToString();
        }
        private void _LoadData()
        {
            _dgvFillReturns();

            cbFilterBy.Items.Add("None");
            cbFilterBy.Items.Add("Return ID");
            cbFilterBy.Items.Add("Booking ID");
            cbFilterBy.Items.Add("Customer");
            cbFilterBy.Items.Add("National No");

            cbFilterBy.SelectedItem = "None";
        }
        private void frmVehicleReturnRecordsList_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void txtFilterBy_TextChanged(object sender, EventArgs e)
        {
            string Filtering_Item;

            switch (cbFilterBy.SelectedItem)
            {
                case "Return ID":
                    Filtering_Item = "ReturnRecordID";
                    break;
                case "Booking ID":
                    Filtering_Item = "VehicleBookRecordID";
                    break;
                case "Customer":
                    Filtering_Item = "FullName";
                    break;
                case "National No":
                    Filtering_Item = "NationalNo";
                    break;
                default:
                    Filtering_Item = "None";
                    break;
            }

            if (string.IsNullOrWhiteSpace(txtFilterBy.Text.Trim()))
            {
                _dtReturns.DefaultView.RowFilter = "";
                return;
            }

            if (Filtering_Item == "ReturnRecordID" || Filtering_Item == "VehicleBookRecordID")
            {
                _dtReturns.DefaultView.RowFilter =
                    string.Format("{0}={1}", Filtering_Item, int.Parse(txtFilterBy.Text.Trim()));
            }
            else
            {
                _dtReturns.DefaultView.RowFilter =
                    string.Format("{0} LIKE '{1}%'", Filtering_Item, txtFilterBy.Text.Trim());
            }

            lblRecordsCount.Text = dgvReturnRecordsList.RowCount.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _dtReturns.DefaultView.RowFilter = "";
            txtFilterBy.Visible = cbFilterBy.SelectedItem.ToString() != "None";

        }

        private void txtFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.SelectedItem != null &&
           (cbFilterBy.SelectedItem.ToString() == "Return ID" ||
            cbFilterBy.SelectedItem.ToString() == "Booking ID"))
            {
                e.Handled = (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowVehicleReturnRecordDetails frm =
          new frmShowVehicleReturnRecordDetails(
              Convert.ToInt32(dgvReturnRecordsList.CurrentRow.Cells[0].Value));

            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ReturnID = int.Parse(dgvReturnRecordsList.CurrentRow.Cells[0].Value.ToString());

            if (MessageBox.Show("Are you sure you want to delete return record [" + ReturnID + "]?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsReturnRecord.DeleteReturnRecord(ReturnID))
                {
                    MessageBox.Show("Deleted Successfully");
                    _dgvFillReturns();
                }
                else
                {
                    MessageBox.Show("Delete Failed");
                }
            }
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditReturnRecord addEditReturnRecord = new frmAddEditReturnRecord(-1);
            addEditReturnRecord.ShowDialog();
            _dgvFillReturns();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookingID = int.Parse(dgvReturnRecordsList.CurrentRow.Cells[1].Value.ToString());
            frmAddEditReturnRecord addEditReturnRecord = new frmAddEditReturnRecord(BookingID);
            addEditReturnRecord.ShowDialog();
            _dgvFillReturns();

        }

        private void showPaymentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int BookingID = int.Parse(dgvReturnRecordsList.CurrentRow.Cells[1].Value.ToString());
            clsRentalBooking BookingInfo = clsRentalBooking.FindBookingByID(BookingID);
            if (BookingInfo!=null)
            {
               clsPayment PaymentInfo =  clsPayment.FindByBookingID(BookingID);
                if (PaymentInfo != null)
                {
                    frmShowPaymentInfo showPaymentInfo = new frmShowPaymentInfo(PaymentInfo.PaymentID);
                    showPaymentInfo.ShowDialog();
                }
            }
           
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            frmAddEditReturnRecord addEditReturnRecord = new frmAddEditReturnRecord(-1);
             addEditReturnRecord.ShowDialog();
            _dgvFillReturns();
        }
    }
}
