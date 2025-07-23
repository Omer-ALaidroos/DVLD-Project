using DVLD_Project.Applications.Application_Types;
using DVLD_Project.Applications.International_DriveLicense;
using DVLD_Project.Applications.Local_Driving_License;
using DVLD_Project.Applications.Release_Detained_License;
using DVLD_Project.Applications.Renew_Local_License;
using DVLD_Project.Applications.Replace_Lost_OR_Damage_Licenses;
using DVLD_Project.Applications.Test_Types;
using DVLD_Project.Global_Classes;
using DVLD_Project.License.Detain_License;
using DVLD_Project.Login;
using DVLD_Project.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class frmMainScreen : Form
    {
        frmLogin _frmlogin;
        public frmMainScreen(frmLogin frm)
        {
            _frmlogin = frm;
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new frmManagePeople();
            frm.ShowDialog();
        }

        private void frmMainScreen_Load(object sender, EventArgs e)
        {

        }

        private void msMenuItems_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmManageUser = new frmManageUsers();
            frmManageUser.ShowDialog();
        }

        private void accountSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmlogin.Show();
            this.Close();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmchangePass = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frmchangePass.ShowDialog();
        }

        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmUserInfo = new frmUserInfo(clsGlobal.CurrentUser.PersonID);
            frmUserInfo.ShowDialog();
        }

        private void currentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form frmUserInfo = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frmUserInfo.ShowDialog();
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void drivingLicensesServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTestTypes frm = new frmManageTestTypes();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
          frmAddUpdateNewLDLApplication frm = new frmAddUpdateNewLDLApplication();
          frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApps frm= new frmListLocalDrivingLicenseApps();
            frm.ShowDialog();
        }

        private void internationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewInternationaLicense frm = new frmAddNewInternationaLicense();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalLicense frm = new frmRenewLocalLicense();
            frm.ShowDialog();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void replacementForLostOrDamagedLicenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceOrDamageLicense frm = new frmReplaceOrDamageLicense();
            frm.ShowDialog();

        }

        private void detainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm    = new frmDetainLicenseApplication();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }

        private void manageDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();
        }
    }
}
