namespace HealthCare_Plus.views.staff
{
    partial class edit_appoinment
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.time = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.rtextdescription = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtcost = new System.Windows.Forms.RichTextBox();
            this.btnedit = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbladmindashboard = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblpatient = new System.Windows.Forms.Label();
            this.lbldoctor = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // time
            // 
            this.time.CustomFormat = "HH:mm:ss";
            this.time.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.time.Location = new System.Drawing.Point(22, 218);
            this.time.MaxDate = new System.DateTime(2025, 8, 20, 0, 0, 0, 0);
            this.time.MinDate = new System.DateTime(2023, 8, 20, 0, 0, 0, 0);
            this.time.Name = "time";
            this.time.ShowUpDown = true;
            this.time.Size = new System.Drawing.Size(288, 33);
            this.time.TabIndex = 28;
            this.time.Value = new System.DateTime(2023, 8, 20, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(18, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 24);
            this.label6.TabIndex = 27;
            this.label6.Text = "Time";
            // 
            // date
            // 
            this.date.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Location = new System.Drawing.Point(22, 134);
            this.date.MaxDate = new System.DateTime(2025, 8, 20, 0, 0, 0, 0);
            this.date.MinDate = new System.DateTime(2023, 8, 20, 0, 0, 0, 0);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(288, 33);
            this.date.TabIndex = 24;
            this.date.Value = new System.DateTime(2023, 8, 20, 0, 0, 0, 0);
            // 
            // rtextdescription
            // 
            this.rtextdescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtextdescription.Font = new System.Drawing.Font("Candara Light", 15.75F);
            this.rtextdescription.ForeColor = System.Drawing.Color.Black;
            this.rtextdescription.Location = new System.Drawing.Point(22, 303);
            this.rtextdescription.Name = "rtextdescription";
            this.rtextdescription.Size = new System.Drawing.Size(647, 132);
            this.rtextdescription.TabIndex = 23;
            this.rtextdescription.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 24);
            this.label1.TabIndex = 22;
            this.label1.Text = "Description";
            // 
            // txtcost
            // 
            this.txtcost.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtcost.Font = new System.Drawing.Font("Candara Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcost.Location = new System.Drawing.Point(381, 134);
            this.txtcost.Multiline = false;
            this.txtcost.Name = "txtcost";
            this.txtcost.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.txtcost.Size = new System.Drawing.Size(288, 33);
            this.txtcost.TabIndex = 19;
            this.txtcost.Text = "";
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.Teal;
            this.btnedit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnedit.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.Color.White;
            this.btnedit.Location = new System.Drawing.Point(381, 459);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(288, 46);
            this.btnedit.TabIndex = 16;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = false;
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.White;
            this.btncancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btncancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancel.Font = new System.Drawing.Font("Nirmala UI", 14.25F);
            this.btncancel.ForeColor = System.Drawing.Color.Black;
            this.btncancel.Location = new System.Drawing.Point(22, 459);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(288, 46);
            this.btncancel.TabIndex = 15;
            this.btncancel.Text = "Cancel Appoinment";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(377, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "Cost (in LKR)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(18, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Date";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.lbladmindashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 41);
            this.panel1.TabIndex = 34;
            // 
            // lbladmindashboard
            // 
            this.lbladmindashboard.AutoSize = true;
            this.lbladmindashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbladmindashboard.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbladmindashboard.ForeColor = System.Drawing.Color.Black;
            this.lbladmindashboard.Location = new System.Drawing.Point(14, 3);
            this.lbladmindashboard.Name = "lbladmindashboard";
            this.lbladmindashboard.Size = new System.Drawing.Size(229, 32);
            this.lbladmindashboard.TabIndex = 32;
            this.lbladmindashboard.Text = "Edit Appoinment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(378, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Doctor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(18, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 23);
            this.label2.TabIndex = 9;
            this.label2.Text = "Patient";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.OldLace;
            this.panel2.Controls.Add(this.lbldoctor);
            this.panel2.Controls.Add(this.lblpatient);
            this.panel2.Controls.Add(this.time);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.date);
            this.panel2.Controls.Add(this.rtextdescription);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtcost);
            this.panel2.Controls.Add(this.btnedit);
            this.panel2.Controls.Add(this.btncancel);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(20, 81);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(702, 532);
            this.panel2.TabIndex = 33;
            // 
            // lblpatient
            // 
            this.lblpatient.AutoSize = true;
            this.lblpatient.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpatient.ForeColor = System.Drawing.Color.Blue;
            this.lblpatient.Location = new System.Drawing.Point(18, 50);
            this.lblpatient.Name = "lblpatient";
            this.lblpatient.Size = new System.Drawing.Size(66, 22);
            this.lblpatient.TabIndex = 29;
            this.lblpatient.Text = "Name";
            // 
            // lbldoctor
            // 
            this.lbldoctor.AutoSize = true;
            this.lbldoctor.Font = new System.Drawing.Font("Century Gothic", 14.25F);
            this.lbldoctor.ForeColor = System.Drawing.Color.Blue;
            this.lbldoctor.Location = new System.Drawing.Point(382, 50);
            this.lbldoctor.Name = "lbldoctor";
            this.lbldoctor.Size = new System.Drawing.Size(66, 22);
            this.lbldoctor.TabIndex = 30;
            this.lbldoctor.Text = "Name";
            // 
            // edit_appoinment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "edit_appoinment";
            this.Size = new System.Drawing.Size(748, 652);
            this.Load += new System.EventHandler(this.edit_appoinment_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker time;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.RichTextBox rtextdescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtcost;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbladmindashboard;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbldoctor;
        private System.Windows.Forms.Label lblpatient;
    }
}
