﻿using DVLD_Project.Global_Classes;
using DVLD_Project.Properties;
using DVLDBuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.License.Local_Drive_License.Controls
{
    public partial class ucDriverLicenseInfo : UserControl
    {
        private int _LicenseID;
        private clsLicense _License;

        public ucDriverLicenseInfo()
        {
            InitializeComponent();
        }
        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicense SelectedLicenseInfo
        { get { return _License; } }

        private void _LoadPersonImage()
        {
            if (_License.DriverInfo.PersonInfo.Gendor == 0)
                pbPersonImage.Image = Resources.Male;
            else
                pbPersonImage.Image = Resources.Female;

            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbPersonImage.Load(ImagePath);
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.Find(_LicenseID);
            if (_License == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            lblLicenseID.Text = _License.LicenseID.ToString();
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
            lblClass.Text = _License.LicenseClassIfo.ClassName;
            lblFullName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblNationalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGendor.Text = _License.DriverInfo.PersonInfo.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = clsUtil.DateToShort(_License.DriverInfo.PersonInfo.DateOfBirth);

            lblDriverID.Text = _License.DriverID.ToString();
            lblIssueDate.Text = clsUtil.DateToShort(_License.IssueDate);
            lblExpirationDate.Text = clsUtil.DateToShort(_License.ExpirationDate);
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            _LoadPersonImage();



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
