namespace Car_Rental.ReturnRecords
{
    partial class frmAddEditReturnRecord
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
            this.ctrlVehicleDetailsWithFilter1 = new Car_Rental.Vehicles.Controls.ctrlVehicleDetailsWithFilter();
            this.lblMode = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCurrentMileages = new System.Windows.Forms.TextBox();
            this.txtVehicleFinalCheckNotes = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txtAdditionalChrges = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblVehicleOldMileages = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpActualReturnDate = new System.Windows.Forms.DateTimePicker();
            this.lblRentalBookingID = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblReturnRecordID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlVehicleDetailsWithFilter1
            // 
            this.ctrlVehicleDetailsWithFilter1.cbFilterSelectedItem = "";
            this.ctrlVehicleDetailsWithFilter1.FilterEnabled = true;
            this.ctrlVehicleDetailsWithFilter1.Location = new System.Drawing.Point(50, 70);
            this.ctrlVehicleDetailsWithFilter1.Name = "ctrlVehicleDetailsWithFilter1";
            this.ctrlVehicleDetailsWithFilter1.Size = new System.Drawing.Size(777, 360);
            this.ctrlVehicleDetailsWithFilter1.TabIndex = 0;
            this.ctrlVehicleDetailsWithFilter1.txtFilterValue = "";
            this.ctrlVehicleDetailsWithFilter1.OnVehicleSelected += new System.Action<int>(this.ctrlVehicleDetailsWithFilter1_OnVehicleSelected);
            this.ctrlVehicleDetailsWithFilter1.Load += new System.EventHandler(this.ctrlVehicleDetailsWithFilter1_Load);
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMode.Location = new System.Drawing.Point(273, 22);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(331, 31);
            this.lblMode.TabIndex = 129;
            this.lblMode.Text = "Add New Vehicle Return";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Firebrick;
            this.btnClose.Image = global::Car_Rental.Properties.Resources.Close_321;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(634, 741);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 41);
            this.btnClose.TabIndex = 131;
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
            this.btnSave.Location = new System.Drawing.Point(750, 741);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 41);
            this.btnSave.TabIndex = 130;
            this.btnSave.Text = "        Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCurrentMileages);
            this.groupBox1.Controls.Add(this.txtVehicleFinalCheckNotes);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtAdditionalChrges);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblCustomerName);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblVehicleOldMileages);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.dtpActualReturnDate);
            this.groupBox1.Controls.Add(this.lblRentalBookingID);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblReturnRecordID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 436);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(865, 299);
            this.groupBox1.TabIndex = 132;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Vehicle Return Record Info";
            // 
            // txtCurrentMileages
            // 
            this.txtCurrentMileages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCurrentMileages.Location = new System.Drawing.Point(648, 136);
            this.txtCurrentMileages.Name = "txtCurrentMileages";
            this.txtCurrentMileages.Size = new System.Drawing.Size(190, 26);
            this.txtCurrentMileages.TabIndex = 160;
            // 
            // txtVehicleFinalCheckNotes
            // 
            this.txtVehicleFinalCheckNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehicleFinalCheckNotes.Location = new System.Drawing.Point(227, 221);
            this.txtVehicleFinalCheckNotes.Name = "txtVehicleFinalCheckNotes";
            this.txtVehicleFinalCheckNotes.Size = new System.Drawing.Size(237, 26);
            this.txtVehicleFinalCheckNotes.TabIndex = 159;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(475, 139);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(167, 20);
            this.label18.TabIndex = 158;
            this.label18.Text = "V.Current Mileages:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(45, 224);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(182, 20);
            this.label19.TabIndex = 157;
            this.label19.Text = "V. Final Check Notes:";
            // 
            // txtAdditionalChrges
            // 
            this.txtAdditionalChrges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAdditionalChrges.Location = new System.Drawing.Point(648, 179);
            this.txtAdditionalChrges.Name = "txtAdditionalChrges";
            this.txtAdditionalChrges.Size = new System.Drawing.Size(190, 26);
            this.txtAdditionalChrges.TabIndex = 156;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(476, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 20);
            this.label2.TabIndex = 155;
            this.label2.Text = "Additional Charges:";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerName.ForeColor = System.Drawing.Color.Firebrick;
            this.lblCustomerName.Location = new System.Drawing.Point(224, 95);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(53, 20);
            this.lblCustomerName.TabIndex = 154;
            this.lblCustomerName.Text = "[????]";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(45, 95);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(142, 20);
            this.label16.TabIndex = 153;
            this.label16.Text = "Customer Name:";
            // 
            // lblVehicleOldMileages
            // 
            this.lblVehicleOldMileages.AutoSize = true;
            this.lblVehicleOldMileages.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVehicleOldMileages.Location = new System.Drawing.Point(223, 136);
            this.lblVehicleOldMileages.Name = "lblVehicleOldMileages";
            this.lblVehicleOldMileages.Size = new System.Drawing.Size(53, 20);
            this.lblVehicleOldMileages.TabIndex = 152;
            this.lblVehicleOldMileages.Text = "[????]";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(45, 138);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(134, 20);
            this.label15.TabIndex = 151;
            this.label15.Text = "V.Old Mileages:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(45, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(169, 20);
            this.label10.TabIndex = 150;
            this.label10.Text = "Actual Return Date:";
            // 
            // dtpActualReturnDate
            // 
            this.dtpActualReturnDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpActualReturnDate.Location = new System.Drawing.Point(227, 179);
            this.dtpActualReturnDate.Name = "dtpActualReturnDate";
            this.dtpActualReturnDate.Size = new System.Drawing.Size(237, 22);
            this.dtpActualReturnDate.TabIndex = 149;
            // 
            // lblRentalBookingID
            // 
            this.lblRentalBookingID.AutoSize = true;
            this.lblRentalBookingID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentalBookingID.Location = new System.Drawing.Point(644, 96);
            this.lblRentalBookingID.Name = "lblRentalBookingID";
            this.lblRentalBookingID.Size = new System.Drawing.Size(53, 20);
            this.lblRentalBookingID.TabIndex = 148;
            this.lblRentalBookingID.Text = "[????]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(481, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 20);
            this.label6.TabIndex = 147;
            this.label6.Text = "Rental Booking ID:";
            // 
            // lblReturnRecordID
            // 
            this.lblReturnRecordID.AutoSize = true;
            this.lblReturnRecordID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReturnRecordID.Location = new System.Drawing.Point(224, 52);
            this.lblReturnRecordID.Name = "lblReturnRecordID";
            this.lblReturnRecordID.Size = new System.Drawing.Size(53, 20);
            this.lblReturnRecordID.TabIndex = 146;
            this.lblReturnRecordID.Text = "[????]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 20);
            this.label1.TabIndex = 145;
            this.label1.Text = "V.Return Record ID:";
            // 
            // frmAddEditReturnRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 794);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.ctrlVehicleDetailsWithFilter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditReturnRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Vehicle Return Record Screen";
            this.Load += new System.EventHandler(this.frmAddEditReturnRecord_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Vehicles.Controls.ctrlVehicleDetailsWithFilter ctrlVehicleDetailsWithFilter1;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCurrentMileages;
        private System.Windows.Forms.TextBox txtVehicleFinalCheckNotes;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtAdditionalChrges;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblVehicleOldMileages;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpActualReturnDate;
        private System.Windows.Forms.Label lblRentalBookingID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblReturnRecordID;
        private System.Windows.Forms.Label label1;
    }
}