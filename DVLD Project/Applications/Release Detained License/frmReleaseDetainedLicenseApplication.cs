﻿using DVLD_Project.Global_Classes;
using DVLD_Project.License;
using DVLD_Project.License.Local_Drive_License;
using DVLDBuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Applications.Release_Detained_License
{
    public partial class frmReleaseDetainedLicenseApplication : Form
    {
        private int _SelectedLicenseID = -1;

        public frmReleaseDetainedLicenseApplication(int LicenseID)
        {
            InitializeComponent();
            _SelectedLicenseID = LicenseID;

            ucDriverLicenseInfoWithFilter1.LoadLicenseInfo(_SelectedLicenseID);
            ucDriverLicenseInfoWithFilter1.FilterEnabled = false;
        }
        public frmReleaseDetainedLicenseApplication()
        {
            InitializeComponent();
           
        }

        private void ucDriverLicenseInfoWithFilter1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucDriverLicenseInfoWithFilter1_OnLicenseSelected(int obj)
        {
            _SelectedLicenseID = obj;

            lblLicenseID.Text = _SelectedLicenseID.ToString();

            llShowLicenseHistory.Enabled = (_SelectedLicenseID != -1);

            if (_SelectedLicenseID == -1)

            {
                return;
            }

            //ToDo: make sure the license is not detained already.
            if (!ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.IsDetained)
            {
                MessageBox.Show("Selected License i is not detained, choose another one.", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lblApplicationFees.Text = clsApplicationTypes.Find((int)clsApplication.enApplicationType.ReleaseDetainedDrivingLicsense).Fees.ToString();
            lblCreatedByUser.Text = clsGlobal.CurrentUser.UserName;

            lblDetainID.Text = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainID.ToString();
            lblLicenseID.Text = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.LicenseID.ToString();

            lblCreatedByUser.Text = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.CreatedByUserInfo.UserName;
            lblDetainDate.Text = clsUtil.DateToShort(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.DetainDate);
            lblFineFees.Text = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DetainedInfo.FineFees.ToString();
            lblTotalFees.Text = (Convert.ToSingle(lblApplicationFees.Text) + Convert.ToSingle(lblFineFees.Text)).ToString();

            btnRelease.Enabled = true;
        }

        private void frmReleaseDetainedLicenseApplication_Activated(object sender, EventArgs e)
        {
            ucDriverLicenseInfoWithFilter1.txtLicenseIDFocus();
        }

        private void llShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonLicenseHistory frm =
           new frmShowPersonLicenseHistory(ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void llShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm =
         new frmShowLicenseInfo(_SelectedLicenseID);
            frm.ShowDialog();
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to release this detained  license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            int ApplicationID = -1;


            bool IsReleased = ucDriverLicenseInfoWithFilter1.SelectedLicenseInfo.ReleaseDetainedLicense(clsGlobal.CurrentUser.UserID, ref ApplicationID); ;

            lblApplicationID.Text = ApplicationID.ToString();

            if (!IsReleased)
            {
                MessageBox.Show("Faild to to release the Detain License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Detained License released Successfully ", "Detained License Released", MessageBoxButtons.OK, MessageBoxIcon.Information);

            btnRelease.Enabled = false;
            ucDriverLicenseInfoWithFilter1.FilterEnabled = false;
            llShowLicenseInfo.Enabled = true;
        }
    }
}
