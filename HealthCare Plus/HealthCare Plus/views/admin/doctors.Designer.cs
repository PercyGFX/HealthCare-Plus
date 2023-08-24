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
            this.doctores = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // doctores
            // 
            this.doctores.AutoSize = true;
            this.doctores.Location = new System.Drawing.Point(317, 45);
            this.doctores.Name = "doctores";
            this.doctores.Size = new System.Drawing.Size(42, 13);
            this.doctores.TabIndex = 0;
            this.doctores.Text = "doctors";
            // 
            // doctors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.doctores);
            this.Name = "doctors";
            this.Size = new System.Drawing.Size(908, 587);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label doctores;
    }
}
