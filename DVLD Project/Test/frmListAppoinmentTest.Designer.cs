namespace DVLD_Project.Test
{
    partial class frmListAppoinmentTest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListAppoinmentTest));
            this.lbTypeOfTest = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DGAppointment = new Guna.UI2.WinForms.Guna2DataGridView();
            this.cmsAppointment = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.takeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddApointment = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.lbNumberOfRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pbTestTypeImage = new Guna.UI2.WinForms.Guna2PictureBox();
            this.ucLocalDrivingLicenseInfo1 = new DVLD_Project.Applications.Local_Driving_License.ucLocalDrivingLicenseInfo();
            ((System.ComponentModel.ISupportInitialize)(this.DGAppointment)).BeginInit();
            this.cmsAppointment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTypeOfTest
            // 
            this.lbTypeOfTest.AutoSize = true;
            this.lbTypeOfTest.Font = new System.Drawing.Font("Georgia", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTypeOfTest.ForeColor = System.Drawing.Color.IndianRed;
            this.lbTypeOfTest.Location = new System.Drawing.Point(342, 172);
            this.lbTypeOfTest.Name = "lbTypeOfTest";
            this.lbTypeOfTest.Size = new System.Drawing.Size(173, 32);
            this.lbTypeOfTest.TabIndex = 3;
            this.lbTypeOfTest.Text = "Vision Test";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 620);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Appointment :";
            // 
            // DGAppointment
            // 
            this.DGAppointment.AllowUserToAddRows = false;
            this.DGAppointment.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DGAppointment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DGAppointment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGAppointment.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DGAppointment.ColumnHeadersHeight = 15;
            this.DGAppointment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGAppointment.ContextMenuStrip = this.cmsAppointment;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGAppointment.DefaultCellStyle = dataGridViewCellStyle3;
            this.DGAppointment.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGAppointment.Location = new System.Drawing.Point(22, 664);
            this.DGAppointment.Name = "DGAppointment";
            this.DGAppointment.ReadOnly = true;
            this.DGAppointment.RowHeadersVisible = false;
            this.DGAppointment.RowHeadersWidth = 51;
            this.DGAppointment.RowTemplate.Height = 26;
            this.DGAppointment.Size = new System.Drawing.Size(893, 116);
            this.DGAppointment.TabIndex = 6;
            this.DGAppointment.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DGAppointment.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DGAppointment.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DGAppointment.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DGAppointment.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DGAppointment.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DGAppointment.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGAppointment.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.DGAppointment.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DGAppointment.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DGAppointment.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DGAppointment.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DGAppointment.ThemeStyle.HeaderStyle.Height = 15;
            this.DGAppointment.ThemeStyle.ReadOnly = true;
            this.DGAppointment.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.DGAppointment.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DGAppointment.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Tahoma", 8F);
            this.DGAppointment.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.DGAppointment.ThemeStyle.RowsStyle.Height = 26;
            this.DGAppointment.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.DGAppointment.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // cmsAppointment
            // 
            this.cmsAppointment.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsAppointment.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.takeTestToolStripMenuItem});
            this.cmsAppointment.Name = "cmsAppointment";
            this.cmsAppointment.Size = new System.Drawing.Size(142, 56);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("editToolStripMenuItem.Image")));
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.editToolStripMenuItem.Text = "Edit ";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // takeTestToolStripMenuItem
            // 
            this.takeTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("takeTestToolStripMenuItem.Image")));
            this.takeTestToolStripMenuItem.Name = "takeTestToolStripMenuItem";
            this.takeTestToolStripMenuItem.Size = new System.Drawing.Size(141, 26);
            this.takeTestToolStripMenuItem.Text = "Take Test";
            this.takeTestToolStripMenuItem.Click += new System.EventHandler(this.takeTestToolStripMenuItem_Click);
            // 
            // btnAddApointment
            // 
            this.btnAddApointment.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddApointment.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddApointment.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddApointment.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddApointment.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnAddApointment.Font = new System.Drawing.Font("Garamond", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddApointment.ForeColor = System.Drawing.Color.White;
            this.btnAddApointment.Location = new System.Drawing.Point(758, 604);
            this.btnAddApointment.Name = "btnAddApointment";
            this.btnAddApointment.Size = new System.Drawing.Size(157, 36);
            this.btnAddApointment.TabIndex = 7;
            this.btnAddApointment.Text = "Add Appointment";
            this.btnAddApointment.Click += new System.EventHandler(this.btnAddApointment_Click);
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.guna2Button1.Font = new System.Drawing.Font("Garamond", 10.2F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.White;
            this.guna2Button1.Location = new System.Drawing.Point(797, 786);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(118, 36);
            this.guna2Button1.TabIndex = 8;
            this.guna2Button1.Text = "Close";
            this.guna2Button1.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // lbNumberOfRecords
            // 
            this.lbNumberOfRecords.AutoSize = true;
            this.lbNumberOfRecords.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumberOfRecords.Location = new System.Drawing.Point(121, 786);
            this.lbNumberOfRecords.Name = "lbNumberOfRecords";
            this.lbNumberOfRecords.Size = new System.Drawing.Size(87, 21);
            this.lbNumberOfRecords.TabIndex = 13;
            this.lbNumberOfRecords.Text = "Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Georgia", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 786);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "Records :";
            // 
            // pbTestTypeImage
            // 
            this.pbTestTypeImage.BackColor = System.Drawing.Color.Transparent;
            this.pbTestTypeImage.Image = global::DVLD_Project.Properties.Resources.vision;
            this.pbTestTypeImage.ImageRotate = 0F;
            this.pbTestTypeImage.Location = new System.Drawing.Point(323, 12);
            this.pbTestTypeImage.Name = "pbTestTypeImage";
            this.pbTestTypeImage.Size = new System.Drawing.Size(241, 157);
            this.pbTestTypeImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestTypeImage.TabIndex = 2;
            this.pbTestTypeImage.TabStop = false;
            this.pbTestTypeImage.UseTransparentBackground = true;
            // 
            // ucLocalDrivingLicenseInfo1
            // 
            this.ucLocalDrivingLicenseInfo1.Location = new System.Drawing.Point(22, 235);
            this.ucLocalDrivingLicenseInfo1.Name = "ucLocalDrivingLicenseInfo1";
            this.ucLocalDrivingLicenseInfo1.Size = new System.Drawing.Size(903, 369);
            this.ucLocalDrivingLicenseInfo1.TabIndex = 4;
            // 
            // frmListAppoinmentTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(938, 830);
            this.Controls.Add(this.lbNumberOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.btnAddApointment);
            this.Controls.Add(this.DGAppointment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ucLocalDrivingLicenseInfo1);
            this.Controls.Add(this.lbTypeOfTest);
            this.Controls.Add(this.pbTestTypeImage);
            this.Name = "frmListAppoinmentTest";
            this.Text = "frmListAppoinmentTest";
            this.Load += new System.EventHandler(this.frmListAppoinmentTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGAppointment)).EndInit();
            this.cmsAppointment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbTestTypeImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox pbTestTypeImage;
        private System.Windows.Forms.Label lbTypeOfTest;
        private Applications.Local_Driving_License.ucLocalDrivingLicenseInfo ucLocalDrivingLicenseInfo1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2DataGridView DGAppointment;
        private Guna.UI2.WinForms.Guna2Button btnAddApointment;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private System.Windows.Forms.Label lbNumberOfRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cmsAppointment;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem takeTestToolStripMenuItem;
    }
}