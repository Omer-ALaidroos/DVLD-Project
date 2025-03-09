namespace DVLD_Project
{
    partial class frmPersonDetails
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonDetails));
            this.ucPersonDetails1 = new DVLD_Project.ucPersonDetails();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.DefaultImages = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // ucPersonDetails1
            // 
            this.ucPersonDetails1.Location = new System.Drawing.Point(0, 0);
            this.ucPersonDetails1.Name = "ucPersonDetails1";
            this.ucPersonDetails1.Size = new System.Drawing.Size(1004, 376);
            this.ucPersonDetails1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(371, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 38);
            this.label1.TabIndex = 1;
            this.label1.Text = "Person Detailes";
            // 
            // btnClose
            // 
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.IndianRed;
            this.btnClose.Font = new System.Drawing.Font("Century", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(852, 481);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(147, 41);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DefaultImages
            // 
            this.DefaultImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("DefaultImages.ImageStream")));
            this.DefaultImages.TransparentColor = System.Drawing.Color.Transparent;
            this.DefaultImages.Images.SetKeyName(0, "Male.png");
            this.DefaultImages.Images.SetKeyName(1, "Female.png");
            // 
            // frmPersonDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 535);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucPersonDetails1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPersonDetails";
            this.Text = "frmPersonDetails";
            this.TransparencyKey = System.Drawing.Color.Olive;
            this.Load += new System.EventHandler(this.frmPersonDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ucPersonDetails ucPersonDetails1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        public System.Windows.Forms.ImageList DefaultImages;
    }
}