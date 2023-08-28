namespace HealthCare_Plus.views.staff
{
    partial class discharge
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
            this.date = new System.Windows.Forms.DateTimePicker();
            this.btndischarge = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbladmindashboard = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbldischarge = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // date
            // 
            this.date.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date.Location = new System.Drawing.Point(22, 134);
            this.date.MaxDate = new System.DateTime(2025, 8, 20, 0, 0, 0, 0);
            this.date.MinDate = new System.DateTime(2023, 8, 20, 0, 0, 0, 0);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(307, 33);
            this.date.TabIndex = 24;
            this.date.Value = new System.DateTime(2023, 8, 20, 0, 0, 0, 0);
            // 
            // btndischarge
            // 
            this.btndischarge.BackColor = System.Drawing.Color.Teal;
            this.btndischarge.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndischarge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndischarge.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndischarge.ForeColor = System.Drawing.Color.White;
            this.btndischarge.Location = new System.Drawing.Point(22, 188);
            this.btndischarge.Name = "btndischarge";
            this.btndischarge.Size = new System.Drawing.Size(288, 46);
            this.btndischarge.TabIndex = 16;
            this.btndischarge.Text = "Discharge";
            this.btndischarge.UseVisualStyleBackColor = false;
            this.btndischarge.Click += new System.EventHandler(this.btndischarge_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(18, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(138, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Discharge Date";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.lbladmindashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(621, 41);
            this.panel1.TabIndex = 36;
            // 
            // lbladmindashboard
            // 
            this.lbladmindashboard.AutoSize = true;
            this.lbladmindashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbladmindashboard.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbladmindashboard.ForeColor = System.Drawing.Color.Black;
            this.lbladmindashboard.Location = new System.Drawing.Point(14, 3);
            this.lbladmindashboard.Name = "lbladmindashboard";
            this.lbladmindashboard.Size = new System.Drawing.Size(237, 33);
            this.lbladmindashboard.TabIndex = 32;
            this.lbladmindashboard.Text = "Discharge a Patient";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.OldLace;
            this.panel2.Controls.Add(this.lbldischarge);
            this.panel2.Controls.Add(this.date);
            this.panel2.Controls.Add(this.btndischarge);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(20, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(578, 280);
            this.panel2.TabIndex = 35;
            // 
            // lbldischarge
            // 
            this.lbldischarge.AutoSize = true;
            this.lbldischarge.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.lbldischarge.ForeColor = System.Drawing.Color.DarkCyan;
            this.lbldischarge.Location = new System.Drawing.Point(18, 35);
            this.lbldischarge.Name = "lbldischarge";
            this.lbldischarge.Size = new System.Drawing.Size(382, 24);
            this.lbldischarge.TabIndex = 25;
            this.lbldischarge.Text = "Do you want to discharge the patient in room";
            // 
            // discharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "discharge";
            this.Size = new System.Drawing.Size(621, 367);
            this.Load += new System.EventHandler(this.discharge_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Button btndischarge;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbladmindashboard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbldischarge;
    }
}
