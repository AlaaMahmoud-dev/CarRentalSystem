namespace Car_Rental.BookingRecords
{
    partial class frmAddEditRentalBooking
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMode = new System.Windows.Forms.Label();
            this.tcAddEditRentalBooking = new System.Windows.Forms.TabControl();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.tpRentalInfo = new System.Windows.Forms.TabPage();
            this.txtDropOffLocation = new System.Windows.Forms.TextBox();
            this.txtPickUpLocation = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblVehicleModel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpDueDate = new System.Windows.Forms.DateTimePicker();
            this.dtpRentedAt = new System.Windows.Forms.DateTimePicker();
            this.lblVehicleID = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblCustomerID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblRentalBookingID = new System.Windows.Forms.Label();
            this.txtVehicleConditionNotes = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlVehicleDetailsWithFilter1 = new Car_Rental.Vehicles.Controls.ctrlVehicleDetailsWithFilter();
            this.ctrlCustomerDetailsWithFilter1 = new Car_Rental.Customers.Controls.ctrlCustomerDetailsWithFilter();
            this.tcAddEditRentalBooking.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.tpRentalInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMode.Location = new System.Drawing.Point(234, 9);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(337, 31);
            this.lblMode.TabIndex = 30;
            this.lblMode.Text = "Add New Rental Booking";
            // 
            // tcAddEditRentalBooking
            // 
            this.tcAddEditRentalBooking.Controls.Add(this.tpPersonalInfo);
            this.tcAddEditRentalBooking.Controls.Add(this.tpRentalInfo);
            this.tcAddEditRentalBooking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcAddEditRentalBooking.Location = new System.Drawing.Point(12, 77);
            this.tcAddEditRentalBooking.Name = "tcAddEditRentalBooking";
            this.tcAddEditRentalBooking.SelectedIndex = 0;
            this.tcAddEditRentalBooking.Size = new System.Drawing.Size(803, 821);
            this.tcAddEditRentalBooking.TabIndex = 33;
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.Controls.Add(this.ctrlVehicleDetailsWithFilter1);
            this.tpPersonalInfo.Controls.Add(this.ctrlCustomerDetailsWithFilter1);
            this.tpPersonalInfo.Controls.Add(this.btnNext);
            this.tpPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpPersonalInfo.Location = new System.Drawing.Point(4, 29);
            this.tpPersonalInfo.Name = "tpPersonalInfo";
            this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonalInfo.Size = new System.Drawing.Size(795, 788);
            this.tpPersonalInfo.TabIndex = 0;
            this.tpPersonalInfo.Text = "Vehicle/Customer Info";
            this.tpPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // tpRentalInfo
            // 
            this.tpRentalInfo.Controls.Add(this.txtDropOffLocation);
            this.tpRentalInfo.Controls.Add(this.txtPickUpLocation);
            this.tpRentalInfo.Controls.Add(this.label18);
            this.tpRentalInfo.Controls.Add(this.label19);
            this.tpRentalInfo.Controls.Add(this.lblCustomerName);
            this.tpRentalInfo.Controls.Add(this.label16);
            this.tpRentalInfo.Controls.Add(this.label17);
            this.tpRentalInfo.Controls.Add(this.lblVehicleModel);
            this.tpRentalInfo.Controls.Add(this.label15);
            this.tpRentalInfo.Controls.Add(this.lblStatus);
            this.tpRentalInfo.Controls.Add(this.label5);
            this.tpRentalInfo.Controls.Add(this.label10);
            this.tpRentalInfo.Controls.Add(this.label9);
            this.tpRentalInfo.Controls.Add(this.dtpDueDate);
            this.tpRentalInfo.Controls.Add(this.dtpRentedAt);
            this.tpRentalInfo.Controls.Add(this.lblVehicleID);
            this.tpRentalInfo.Controls.Add(this.label8);
            this.tpRentalInfo.Controls.Add(this.lblCustomerID);
            this.tpRentalInfo.Controls.Add(this.label6);
            this.tpRentalInfo.Controls.Add(this.btnBack);
            this.tpRentalInfo.Controls.Add(this.lblRentalBookingID);
            this.tpRentalInfo.Controls.Add(this.txtVehicleConditionNotes);
            this.tpRentalInfo.Controls.Add(this.label2);
            this.tpRentalInfo.Controls.Add(this.label1);
            this.tpRentalInfo.Location = new System.Drawing.Point(4, 29);
            this.tpRentalInfo.Name = "tpRentalInfo";
            this.tpRentalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpRentalInfo.Size = new System.Drawing.Size(795, 788);
            this.tpRentalInfo.TabIndex = 1;
            this.tpRentalInfo.Text = "Rental Info";
            this.tpRentalInfo.UseVisualStyleBackColor = true;
            this.tpRentalInfo.Click += new System.EventHandler(this.tpRentalInfo_Click);
            // 
            // txtDropOffLocation
            // 
            this.txtDropOffLocation.Location = new System.Drawing.Point(215, 406);
            this.txtDropOffLocation.Name = "txtDropOffLocation";
            this.txtDropOffLocation.Size = new System.Drawing.Size(281, 26);
            this.txtDropOffLocation.TabIndex = 122;
            // 
            // txtPickUpLocation
            // 
            this.txtPickUpLocation.Location = new System.Drawing.Point(215, 368);
            this.txtPickUpLocation.Name = "txtPickUpLocation";
            this.txtPickUpLocation.Size = new System.Drawing.Size(281, 26);
            this.txtPickUpLocation.TabIndex = 121;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(50, 409);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(157, 20);
            this.label18.TabIndex = 120;
            this.label18.Text = "Drop Off Location:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(50, 368);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(149, 20);
            this.label19.TabIndex = 118;
            this.label19.Text = "Pick Up Location:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.Firebrick;
            this.lblCustomerName.Location = new System.Drawing.Point(212, 83);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(54, 18);
            this.lblCustomerName.TabIndex = 106;
            this.lblCustomerName.Text = "[????]";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(50, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(142, 20);
            this.label16.TabIndex = 105;
            this.label16.Text = "Customer Name:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(17, 76);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(0, 20);
            this.label17.TabIndex = 52;
            // 
            // lblVehicleModel
            // 
            this.lblVehicleModel.AutoSize = true;
            this.lblVehicleModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleModel.Location = new System.Drawing.Point(211, 162);
            this.lblVehicleModel.Name = "lblVehicleModel";
            this.lblVehicleModel.Size = new System.Drawing.Size(59, 20);
            this.lblVehicleModel.TabIndex = 49;
            this.lblVehicleModel.Text = "[????]";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(50, 162);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(126, 20);
            this.label15.TabIndex = 48;
            this.label15.Text = "Vehicle Model:";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(211, 245);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(59, 20);
            this.lblStatus.TabIndex = 47;
            this.lblStatus.Text = "[????]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(50, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 46;
            this.label5.Text = "Status:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(50, 286);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 20);
            this.label10.TabIndex = 42;
            this.label10.Text = "Rented At:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(50, 327);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 20);
            this.label9.TabIndex = 41;
            this.label9.Text = "Due Date:";
            // 
            // dtpDueDate
            // 
            this.dtpDueDate.Location = new System.Drawing.Point(215, 327);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new System.Drawing.Size(281, 26);
            this.dtpDueDate.TabIndex = 40;
            // 
            // dtpRentedAt
            // 
            this.dtpRentedAt.Location = new System.Drawing.Point(215, 286);
            this.dtpRentedAt.Name = "dtpRentedAt";
            this.dtpRentedAt.Size = new System.Drawing.Size(281, 26);
            this.dtpRentedAt.TabIndex = 39;
            // 
            // lblVehicleID
            // 
            this.lblVehicleID.AutoSize = true;
            this.lblVehicleID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleID.Location = new System.Drawing.Point(211, 203);
            this.lblVehicleID.Name = "lblVehicleID";
            this.lblVehicleID.Size = new System.Drawing.Size(59, 20);
            this.lblVehicleID.TabIndex = 38;
            this.lblVehicleID.Text = "[????]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(50, 203);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 20);
            this.label8.TabIndex = 37;
            this.label8.Text = "Vehicle ID:";
            // 
            // lblCustomerID
            // 
            this.lblCustomerID.AutoSize = true;
            this.lblCustomerID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerID.Location = new System.Drawing.Point(211, 121);
            this.lblCustomerID.Name = "lblCustomerID";
            this.lblCustomerID.Size = new System.Drawing.Size(59, 20);
            this.lblCustomerID.TabIndex = 36;
            this.lblCustomerID.Text = "[????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(50, 121);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 20);
            this.label6.TabIndex = 35;
            this.label6.Text = "Customer ID:";
            // 
            // lblRentalBookingID
            // 
            this.lblRentalBookingID.AutoSize = true;
            this.lblRentalBookingID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentalBookingID.Location = new System.Drawing.Point(211, 39);
            this.lblRentalBookingID.Name = "lblRentalBookingID";
            this.lblRentalBookingID.Size = new System.Drawing.Size(59, 20);
            this.lblRentalBookingID.TabIndex = 33;
            this.lblRentalBookingID.Text = "[????]";
            // 
            // txtVehicleConditionNotes
            // 
            this.txtVehicleConditionNotes.Location = new System.Drawing.Point(215, 444);
            this.txtVehicleConditionNotes.Name = "txtVehicleConditionNotes";
            this.txtVehicleConditionNotes.Size = new System.Drawing.Size(281, 26);
            this.txtVehicleConditionNotes.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(50, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "V.Condition Notes:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rental Booking ID:";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Image = global::Car_Rental.Properties.Resources.Next_32;
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNext.Location = new System.Drawing.Point(648, 737);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(126, 38);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.Image = global::Car_Rental.Properties.Resources.Prev_32;
            this.btnBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBack.Location = new System.Drawing.Point(31, 678);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(126, 38);
            this.btnBack.TabIndex = 34;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Firebrick;
            this.btnClose.Image = global::Car_Rental.Properties.Resources.Close_321;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(568, 900);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 41);
            this.btnClose.TabIndex = 32;
            this.btnClose.Text = "       Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnSave.Image = global::Car_Rental.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(684, 900);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 41);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "        Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlVehicleDetailsWithFilter1
            // 
            this.ctrlVehicleDetailsWithFilter1.cbFilterSelectedItem = "";
            this.ctrlVehicleDetailsWithFilter1.FilterEnabled = true;
            this.ctrlVehicleDetailsWithFilter1.Location = new System.Drawing.Point(6, 371);
            this.ctrlVehicleDetailsWithFilter1.Name = "ctrlVehicleDetailsWithFilter1";
            this.ctrlVehicleDetailsWithFilter1.Size = new System.Drawing.Size(777, 360);
            this.ctrlVehicleDetailsWithFilter1.TabIndex = 9;
            this.ctrlVehicleDetailsWithFilter1.txtFilterValue = "";
            // 
            // ctrlCustomerDetailsWithFilter1
            // 
            this.ctrlCustomerDetailsWithFilter1.cbFilterSelectedItem = "";
            this.ctrlCustomerDetailsWithFilter1.FilterEnabled = true;
            this.ctrlCustomerDetailsWithFilter1.Location = new System.Drawing.Point(6, 6);
            this.ctrlCustomerDetailsWithFilter1.Name = "ctrlCustomerDetailsWithFilter1";
            this.ctrlCustomerDetailsWithFilter1.Size = new System.Drawing.Size(690, 360);
            this.ctrlCustomerDetailsWithFilter1.TabIndex = 8;
            this.ctrlCustomerDetailsWithFilter1.txtFilterValue = "";
            // 
            // frmAddEditRentalBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 950);
            this.Controls.Add(this.tcAddEditRentalBooking);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditRentalBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Rental Booking Screen";
            this.Load += new System.EventHandler(this.frmAddEditRentalBooking_Load);
            this.tcAddEditRentalBooking.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpRentalInfo.ResumeLayout(false);
            this.tpRentalInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.TabControl tcAddEditRentalBooking;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabPage tpRentalInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDueDate;
        private System.Windows.Forms.DateTimePicker dtpRentedAt;
        private System.Windows.Forms.Label lblVehicleID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblCustomerID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblRentalBookingID;
        private System.Windows.Forms.TextBox txtVehicleConditionNotes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Vehicles.Controls.ctrlVehicleDetailsWithFilter ctrlVehicleDetailsWithFilter1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblVehicleModel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtDropOffLocation;
        private System.Windows.Forms.TextBox txtPickUpLocation;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private Customers.Controls.ctrlCustomerDetailsWithFilter ctrlCustomerDetailsWithFilter1;
    }
}