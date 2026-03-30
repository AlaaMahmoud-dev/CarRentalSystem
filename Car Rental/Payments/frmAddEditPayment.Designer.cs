namespace Car_Rental.Payments
{
    partial class frmAddEditPayment
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctrlBookingRecordDetails1 = new Car_Rental.BookingRecords.Controls.ctrlBookingRecordDetails();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRefunded = new System.Windows.Forms.Label();
            this.lblActualTotalDueAmount = new System.Windows.Forms.Label();
            this.txtInitialPaidAmount = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.lblinitialTotalAmount = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblLastPaymentDate = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPaymentDate = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblRemaining = new System.Windows.Forms.Label();
            this.labelll = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.ForeColor = System.Drawing.Color.Firebrick;
            this.lblMode.Location = new System.Drawing.Point(245, 9);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(253, 31);
            this.lblMode.TabIndex = 31;
            this.lblMode.Text = "Add New Payment";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Firebrick;
            this.btnClose.Image = global::Car_Rental.Properties.Resources.Close_321;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(509, 644);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(110, 41);
            this.btnClose.TabIndex = 34;
            this.btnClose.Text = "       Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.SteelBlue;
            this.btnSave.Image = global::Car_Rental.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(625, 644);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 41);
            this.btnSave.TabIndex = 33;
            this.btnSave.Text = "        Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctrlBookingRecordDetails1
            // 
            this.ctrlBookingRecordDetails1.Location = new System.Drawing.Point(12, 77);
            this.ctrlBookingRecordDetails1.Name = "ctrlBookingRecordDetails1";
            this.ctrlBookingRecordDetails1.Size = new System.Drawing.Size(740, 330);
            this.ctrlBookingRecordDetails1.TabIndex = 35;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRefunded);
            this.groupBox1.Controls.Add(this.lblActualTotalDueAmount);
            this.groupBox1.Controls.Add(this.txtInitialPaidAmount);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.lblinitialTotalAmount);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.lblLastPaymentDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblPaymentDate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.lblRemaining);
            this.groupBox1.Controls.Add(this.labelll);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 413);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(740, 225);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Payment Information";
            // 
            // lblRefunded
            // 
            this.lblRefunded.AutoSize = true;
            this.lblRefunded.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRefunded.Location = new System.Drawing.Point(199, 141);
            this.lblRefunded.Name = "lblRefunded";
            this.lblRefunded.Size = new System.Drawing.Size(53, 20);
            this.lblRefunded.TabIndex = 137;
            this.lblRefunded.Text = "[????]";
            // 
            // lblActualTotalDueAmount
            // 
            this.lblActualTotalDueAmount.AutoSize = true;
            this.lblActualTotalDueAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualTotalDueAmount.Location = new System.Drawing.Point(199, 98);
            this.lblActualTotalDueAmount.Name = "lblActualTotalDueAmount";
            this.lblActualTotalDueAmount.Size = new System.Drawing.Size(53, 20);
            this.lblActualTotalDueAmount.TabIndex = 136;
            this.lblActualTotalDueAmount.Text = "[????]";
            // 
            // txtInitialPaidAmount
            // 
            this.txtInitialPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInitialPaidAmount.Location = new System.Drawing.Point(203, 182);
            this.txtInitialPaidAmount.Multiline = true;
            this.txtInitialPaidAmount.Name = "txtInitialPaidAmount";
            this.txtInitialPaidAmount.Size = new System.Drawing.Size(150, 26);
            this.txtInitialPaidAmount.TabIndex = 135;
            this.txtInitialPaidAmount.TextChanged += new System.EventHandler(this.txtInitialPaidAmount_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(66, 182);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(132, 20);
            this.label19.TabIndex = 134;
            this.label19.Text = "Initial Payment:";
            // 
            // lblinitialTotalAmount
            // 
            this.lblinitialTotalAmount.AutoSize = true;
            this.lblinitialTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblinitialTotalAmount.Location = new System.Drawing.Point(199, 57);
            this.lblinitialTotalAmount.Name = "lblinitialTotalAmount";
            this.lblinitialTotalAmount.Size = new System.Drawing.Size(18, 20);
            this.lblinitialTotalAmount.TabIndex = 133;
            this.lblinitialTotalAmount.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(28, 57);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(170, 20);
            this.label15.TabIndex = 132;
            this.label15.Text = "Initial Total Amount:";
            // 
            // lblLastPaymentDate
            // 
            this.lblLastPaymentDate.AutoSize = true;
            this.lblLastPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastPaymentDate.Location = new System.Drawing.Point(562, 98);
            this.lblLastPaymentDate.Name = "lblLastPaymentDate";
            this.lblLastPaymentDate.Size = new System.Drawing.Size(53, 20);
            this.lblLastPaymentDate.TabIndex = 131;
            this.lblLastPaymentDate.Text = "[????]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(389, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(167, 20);
            this.label5.TabIndex = 130;
            this.label5.Text = "Last Payment Date:";
            // 
            // lblPaymentDate
            // 
            this.lblPaymentDate.AutoSize = true;
            this.lblPaymentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaymentDate.Location = new System.Drawing.Point(562, 57);
            this.lblPaymentDate.Name = "lblPaymentDate";
            this.lblPaymentDate.Size = new System.Drawing.Size(53, 20);
            this.lblPaymentDate.TabIndex = 129;
            this.lblPaymentDate.Text = "[????]";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(429, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(127, 20);
            this.label11.TabIndex = 128;
            this.label11.Text = "Payment Date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(16, 98);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(177, 20);
            this.label10.TabIndex = 127;
            this.label10.Text = "Actual Total Amount:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(105, 139);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 126;
            this.label9.Text = "Refunded:";
            // 
            // lblRemaining
            // 
            this.lblRemaining.AutoSize = true;
            this.lblRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemaining.Location = new System.Drawing.Point(562, 139);
            this.lblRemaining.Name = "lblRemaining";
            this.lblRemaining.Size = new System.Drawing.Size(53, 20);
            this.lblRemaining.TabIndex = 123;
            this.lblRemaining.Text = "[????]";
            // 
            // labelll
            // 
            this.labelll.AutoSize = true;
            this.labelll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelll.Location = new System.Drawing.Point(462, 139);
            this.labelll.Name = "labelll";
            this.labelll.Size = new System.Drawing.Size(99, 20);
            this.labelll.TabIndex = 122;
            this.labelll.Text = "Remaining:";
            // 
            // frmAddEditPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 691);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ctrlBookingRecordDetails1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddEditPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add/Edit Payment Screen";
            this.Load += new System.EventHandler(this.frmAddEditPayment_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private BookingRecords.Controls.ctrlBookingRecordDetails ctrlBookingRecordDetails1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInitialPaidAmount;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblinitialTotalAmount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblLastPaymentDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPaymentDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblRemaining;
        private System.Windows.Forms.Label labelll;
        private System.Windows.Forms.Label lblRefunded;
        private System.Windows.Forms.Label lblActualTotalDueAmount;
    }
}