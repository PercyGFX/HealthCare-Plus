namespace HealthCare_Plus.views.staff
{
    partial class booked_rooms
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbladmindashboard = new System.Windows.Forms.Label();
            this.bookedroomsgridview = new System.Windows.Forms.DataGridView();
            this.btnsearch = new System.Windows.Forms.Button();
            this.txtsearch = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookedroomsgridview)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel1.Controls.Add(this.lbladmindashboard);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 41);
            this.panel1.TabIndex = 17;
            // 
            // lbladmindashboard
            // 
            this.lbladmindashboard.AutoSize = true;
            this.lbladmindashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbladmindashboard.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbladmindashboard.ForeColor = System.Drawing.Color.Black;
            this.lbladmindashboard.Location = new System.Drawing.Point(14, 3);
            this.lbladmindashboard.Name = "lbladmindashboard";
            this.lbladmindashboard.Size = new System.Drawing.Size(191, 33);
            this.lbladmindashboard.TabIndex = 32;
            this.lbladmindashboard.Text = "Booked Rooms";
            // 
            // bookedroomsgridview
            // 
            this.bookedroomsgridview.AllowUserToAddRows = false;
            this.bookedroomsgridview.AllowUserToDeleteRows = false;
            this.bookedroomsgridview.AllowUserToOrderColumns = true;
            this.bookedroomsgridview.BackgroundColor = System.Drawing.Color.White;
            this.bookedroomsgridview.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bookedroomsgridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.bookedroomsgridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bookedroomsgridview.DefaultCellStyle = dataGridViewCellStyle2;
            this.bookedroomsgridview.GridColor = System.Drawing.Color.Silver;
            this.bookedroomsgridview.Location = new System.Drawing.Point(20, 148);
            this.bookedroomsgridview.Name = "bookedroomsgridview";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.bookedroomsgridview.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.bookedroomsgridview.Size = new System.Drawing.Size(871, 428);
            this.bookedroomsgridview.TabIndex = 16;
            this.bookedroomsgridview.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bookedroomsgridview_CellContentClick);
            // 
            // btnsearch
            // 
            this.btnsearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(39)))), ((int)(((byte)(105)))));
            this.btnsearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsearch.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.ForeColor = System.Drawing.Color.White;
            this.btnsearch.Location = new System.Drawing.Point(753, 66);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(138, 38);
            this.btnsearch.TabIndex = 19;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = false;
            // 
            // txtsearch
            // 
            this.txtsearch.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.txtsearch.Font = new System.Drawing.Font("Microsoft YaHei UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearch.ForeColor = System.Drawing.Color.Black;
            this.txtsearch.Location = new System.Drawing.Point(461, 66);
            this.txtsearch.Multiline = true;
            this.txtsearch.Name = "txtsearch";
            this.txtsearch.Size = new System.Drawing.Size(286, 38);
            this.txtsearch.TabIndex = 18;
            // 
            // booked_rooms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bookedroomsgridview);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.txtsearch);
            this.Name = "booked_rooms";
            this.Size = new System.Drawing.Size(926, 591);
            this.Load += new System.EventHandler(this.booked_rooms_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bookedroomsgridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbladmindashboard;
        private System.Windows.Forms.DataGridView bookedroomsgridview;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.TextBox txtsearch;
    }
}
