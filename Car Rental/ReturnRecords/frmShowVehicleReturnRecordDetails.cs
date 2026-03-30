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
    public partial class frmShowVehicleReturnRecordDetails : Form
    {
        int _ReturnRecordID;
        public frmShowVehicleReturnRecordDetails(int ReturnRecordID)
        {
            InitializeComponent();
            _ReturnRecordID = ReturnRecordID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmShowVehicleReturnRecordDetails_Load(object sender, EventArgs e)
        {
            ctrlReturnRecordDetails1.FillReturnRecordInfo(_ReturnRecordID);
        }
    }
}
