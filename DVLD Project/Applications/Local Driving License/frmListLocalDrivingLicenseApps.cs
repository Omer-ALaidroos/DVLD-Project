using DVLD_Project.Applications.Application_Types;
using DVLD_Project.License;
using DVLD_Project.License.Local_Drive_License;
using DVLD_Project.Test;
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

namespace DVLD_Project.Applications.Local_Driving_License
{
    public partial class frmListLocalDrivingLicenseApps : Form
    {
        public frmListLocalDrivingLicenseApps()
        {
            InitializeComponent();
        }
        DataTable _dtLDLApps;
        public enum enScheduleTest { vision = 1, Writen = 2, Street = 3 };
        enScheduleTest scheduleTest;
        private void _LoadData()
        {


            _dtLDLApps = clsLocalDriveLicense.GetAll_LDLApplications();
            

            DGLDLApplication.DataSource = _dtLDLApps;
            cmbFilterLDLApps.SelectedIndex = 0;
            if (cmbFilterLDLApps.Text == "None")
            {
                txtFilterLDLApps.Visible = false;
            }
            lbNumberOfRecords.Text = DGLDLApplication.Rows.Count.ToString();
            DGLDLApplication.Columns[0].HeaderText = "LDL ID";
            DGLDLApplication.Columns[0].Width = 100;

            DGLDLApplication.Columns[1].HeaderText = "Driving Class";
            DGLDLApplication.Columns[1].Width = 200;

            DGLDLApplication.Columns[2].HeaderText = "National No";
            DGLDLApplication.Columns[2].Width = 200;

            DGLDLApplication.Columns[3].HeaderText = "FullName";
            DGLDLApplication.Columns[3].Width = 200;

            DGLDLApplication.Columns[4].HeaderText = "Application Date";
            DGLDLApplication.Columns[4].Width = 200;

            DGLDLApplication.Columns[5].HeaderText = "Passed Tests";
            DGLDLApplication.Columns[5].Width = 200;

            DGLDLApplication.Columns[6].HeaderText = "Status";
            DGLDLApplication.Columns[6].Width = 200;


        }
        private void frmLocalDrivingLicenseApps_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFilterLDLApps_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cmbFilterLDLApps.Text)
            {
                case "L.D.L. AppID":
                    FilterColumn = "LDLID";
                    break;

                case "National No":
                    FilterColumn = "NationalNo";
                    break;

                case "FullName":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterLDLApps.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtLDLApps.DefaultView.RowFilter = "";
                lbNumberOfRecords.Text = DGLDLApplication.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "LDL ID")
                _dtLDLApps.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterLDLApps.Text.Trim());
            else
                _dtLDLApps.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterLDLApps.Text.Trim());

            lbNumberOfRecords.Text = DGLDLApplication.Rows.Count.ToString();

        }

        private void cmbFilterLDLApps_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            if(cmbFilterLDLApps.Text == "None")
            {
                txtFilterLDLApps.Visible = false;
            }
            else
            {
                txtFilterLDLApps.Visible = true;
            }
        }

        private void txtFilterLDLApps_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterLDLApps.Text == "L.D.L. AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void CheckPermissionOfSchedules()
        {
            switch ((int)DGLDLApplication.CurrentRow.Cells[5].Value)
            {
                case 0:
                    {
                        scheduleVisionTestToolStripMenuItem.Enabled = true;
                        scheduleStreetTestToolStripMenuItem.Enabled = false;
                        scheduleWritenTestToolStripMenuItem.Enabled = false;
                        break;
                    }
                case 1:
                    {
                        scheduleVisionTestToolStripMenuItem.Enabled = false;
                        scheduleStreetTestToolStripMenuItem.Enabled = false;
                        scheduleWritenTestToolStripMenuItem.Enabled = true;
                        break;
                    }
                case 2:
                    {
                        scheduleVisionTestToolStripMenuItem.Enabled = false;
                        scheduleStreetTestToolStripMenuItem.Enabled = true;
                        scheduleWritenTestToolStripMenuItem.Enabled = false;
                        break;
                    }
                default:
                    {
                        scheduleVisionTestToolStripMenuItem.Enabled = false;
                        scheduleStreetTestToolStripMenuItem.Enabled = false;
                        scheduleWritenTestToolStripMenuItem.Enabled = false;
                        break;
                    }
            }
        }
        private void checkPermissionOfContextMenuStripe()
        {
            switch (DGLDLApplication.CurrentRow.Cells[6].Value.ToString())
            {
                case "New":
                    {
                        showApplicationDetailsToolStripMenuItem.Enabled = true;
                        toolStripMenuItem1.Enabled = true;
                        deleteApplicationToolStripMenuItem.Enabled = true;
                        cancelApplicationToolStripMenuItem.Enabled = true;
                        sechduleTestsToolStripMenuItem.Enabled = true;

                        if ((int)DGLDLApplication.CurrentRow.Cells[5].Value == 3)
                        {
                            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        }
                            
                        showLicenseToolStripMenuItem.Enabled = false;
                        showPerosnLicenseHistoryToolStripMenuItem.Enabled = true;
                        CheckPermissionOfSchedules();
                        break;
                    }
                case "Cancelled":
                    {
                        showApplicationDetailsToolStripMenuItem.Enabled = true;
                        toolStripMenuItem1.Enabled = false;
                        deleteApplicationToolStripMenuItem.Enabled = false;
                        cancelApplicationToolStripMenuItem.Enabled = false;
                        sechduleTestsToolStripMenuItem.Enabled = false;
                        issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        showLicenseToolStripMenuItem.Enabled = false;
                        showPerosnLicenseHistoryToolStripMenuItem.Enabled = true;
                        break;
                    }
                default:
                    {
                        showApplicationDetailsToolStripMenuItem.Enabled = true;
                        toolStripMenuItem1.Enabled = false;
                        deleteApplicationToolStripMenuItem.Enabled = false;
                        cancelApplicationToolStripMenuItem.Enabled = false;
                        sechduleTestsToolStripMenuItem.Enabled = false;
                        issueDrivingLicenseFirstTimeToolStripMenuItem.Enabled = false;
                        showLicenseToolStripMenuItem.Enabled = true;
                        showPerosnLicenseHistoryToolStripMenuItem.Enabled = true;
                        break;
                    }
            }
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateNewLDLApplication frm = new frmAddUpdateNewLDLApplication();
            frm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdateNewLDLApplication frm = new frmAddUpdateNewLDLApplication(Convert.ToInt32(DGLDLApplication.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _LoadData();
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to delete this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            int LocalDrivingLicenseApplicationID = (int)DGLDLApplication.CurrentRow.Cells[0].Value;

            clsLocalDriveLicense LocalDrivingLicenseApplication =
                clsLocalDriveLicense.FindByLocalDrivingAppLicenseID(LocalDrivingLicenseApplicationID);

            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Delete())
                {
                    MessageBox.Show("Application Deleted Successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    frmLocalDrivingLicenseApps_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Could not delete applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmLocalDrivingLicenseInfo frm = new frmLocalDrivingLicenseInfo(Convert.ToInt32(DGLDLApplication.CurrentRow.Cells[0].Value));
            frm.ShowDialog();

            _LoadData();
        }

        private void cmsLDLApps_Opening(object sender, CancelEventArgs e)
        {
            checkPermissionOfContextMenuStripe();
        }

        private void sechduleTestsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this feature is not found yet.");
        }

        private void issueDrivingLicenseFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLApplication =(int) DGLDLApplication.CurrentRow.Cells[0].Value;
            frmIssueDriverLicenseFirstTime frm = new frmIssueDriverLicenseFirstTime(LDLApplication);
            frm.ShowDialog();
            _LoadData();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalDrivingLicenseApplicationID = (int)DGLDLApplication.CurrentRow.Cells[0].Value;

            int LicenseID = clsLocalDriveLicense.FindByLocalDrivingAppLicenseID(
               LocalDrivingLicenseApplicationID).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void showPerosnLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsPerson Person = clsPerson.FindPersonByNationalNo(DGLDLApplication.CurrentRow.Cells[2].Value.ToString());
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(Person.PersonID);
            frm.ShowDialog();
            _LoadData();
        }

        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LDLAppId = Convert.ToInt32(DGLDLApplication.CurrentRow.Cells[0].Value);
            int AppID = clsLocalDriveLicense.GetAppIDByLDLappId(LDLAppId);
            if (clsApplication.CancelApplication(AppID))
            {
                MessageBox.Show("Application canceld Successfully.", "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                frmLocalDrivingLicenseApps_Load(null, null);
            }
            else
            {
                MessageBox.Show("Could not Cancel applicatoin, other data depends on it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListAppoinmentTest frm = new frmListAppoinmentTest(1, Convert.ToInt32(DGLDLApplication.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _LoadData();
        }

        private void scheduleWritenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListAppoinmentTest frm = new frmListAppoinmentTest(2, Convert.ToInt32(DGLDLApplication.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _LoadData();
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListAppoinmentTest frm = new frmListAppoinmentTest(3, Convert.ToInt32(DGLDLApplication.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _LoadData();
        }
    }
}
