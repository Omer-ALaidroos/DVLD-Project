namespace DVLD_Project.Applications.Local_Driving_License
{
    partial class frmLocalDrivingLicenseInfo
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
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.ucLocalDrivingLicenseInfo1 = new DVLD_Project.Applications.Local_Driving_License.ucLocalDrivingLicenseInfo();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.LightCoral;
            this.btnClose.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(742, 387);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(129, 39);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ucLocalDrivingLicenseInfo1
            // 
            this.ucLocalDrivingLicenseInfo1.Location = new System.Drawing.Point(12, 12);
            this.ucLocalDrivingLicenseInfo1.Name = "ucLocalDrivingLicenseInfo1";
            this.ucLocalDrivingLicenseInfo1.Size = new System.Drawing.Size(903, 369);
            this.ucLocalDrivingLicenseInfo1.TabIndex = 0;
            // 
            // frmLocalDrivingLicenseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 446);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ucLocalDrivingLicenseInfo1);
            this.Name = "frmLocalDrivingLicenseInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLocalDrivingLicenseInfo";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseInfo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ucLocalDrivingLicenseInfo ucLocalDrivingLicenseInfo1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
    }
}