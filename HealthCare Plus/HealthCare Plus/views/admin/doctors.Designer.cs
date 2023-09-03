namespace HealthCare_Plus.views.admin
{
    partial class doctors
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnadddoctor = new System.Windows.Forms.Button();
            this.doctorgridview = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbladmindashboard = new System.Windows.Forms.Label();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.btnsearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.doctorgridview)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnadddoctor
            // 
            this.btnadddoctor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(39)))), ((int)(((byte)(105)))));
            this.btnadddoctor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadddoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadddoctor.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadddoctor.ForeColor = System.Drawing.Color.White;
            this.btnadddoctor.Location = new System.Drawing.Point(20, 63);
            this.btnadddoctor.Name = "btnadddoctor";
            this.btnadddoctor.Size = new System.Drawing.Size(138, 38);
            this.btnadddoctor.TabIndex = 2;
            this.btnadddoctor.Text = "Add Doctors";
            this.btnadddoctor.UseVisualStyleBackColor = false;
            this.btnadddoctor.Click += new System.EventHandler(this.orders_Click);
            // 
            // doctorgridview
            // 
            this.doctorgridview.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.doctorgridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.doctorgridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.doctorgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.doctorgridview.DefaultCellStyle = dataGridViewCellStyle2;
            this.doctorgridview.GridColor = System.Drawing.Color.Silver;
            this.doctorgridview.Location = new System.Drawing.Point(20, 145);
            this.doctorgridview.Name = "doctorgridview";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.doctorgridview.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.doctorgridview.Size = new System.Drawing.Size(871, 428);
            this.doctorgridview.TabIndex = 3;
            this.doctorgridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.lbladmindashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(908, 41);
            this.panel1.TabIndex = 4;
            // 
            // lbladmindashboard
            // 
            this.lbladmindashboard.AutoSize = true;
            this.lbladmindashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbladmindashboard.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbladmindashboard.ForeColor = System.Drawing.Color.Black;
            this.lbladmindashboard.Location = new System.Drawing.Point(15, 5);
            this.lbladmindashboard.Name = "lbladmindashboard";
            this.lbladmindashboard.Size = new System.Drawing.Size(100, 28);
            this.lbladmindashboard.TabIndex = 32;
            this.lbladmindashboard.Text = "Doctors";
            // 
            // txtsearch
            // 
            this.txtsearch.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtsearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.ForeColor = System.Drawing.Color.Black;
            this.txtsearch.Location = new System.Drawing.Point(461, 63);
            this.txtsearch.Multiline = true;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(286, 38);
            this.txtsearch.TabIndex = 8;
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(39)))), ((int)(((byte)(105)))));
            this.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Location = new System.Drawing.Point(753, 63);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(138, 38);
            this.btnsearch.TabIndex = 9;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            this.btnsearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // doctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.txtsearch);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.doctorgridview);
            this.Controls.Add(this.btnadddoctor);
            this.Name = "doctors";
            this.Size = new System.Drawing.Size(908, 587);
            this.Load += new System.EventHandler(this.doctors_Load);
            ((System.ComponentModel.ISupportInitialize)(this.doctorgridview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnadddoctor;
        private System.Windows.Forms.DataGridView doctorgridview;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbladmindashboard;
        private System.Windows.Forms.TextBox txtsearch;
        private System.Windows.Forms.Button btnsearch;
    }
}
