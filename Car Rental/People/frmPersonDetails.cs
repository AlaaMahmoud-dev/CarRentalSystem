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
    public partial class frmPersonDetails : Form
    {
        int _PersonID = -1;
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();
            _PersonID =
                PersonID;
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            ctrlPersonDetails1.FillPersonInfo(_PersonID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
