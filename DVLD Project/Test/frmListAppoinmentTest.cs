using DVLD_Project.Properties;
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

namespace DVLD_Project.Test
{
    public partial class frmListAppoinmentTest : Form
    {
        DataTable _dtLicenseTestAppointments;
        clsTestType.enScheduleTest _TestType;
        int LDLocalDrivingAppID;
        public frmListAppoinmentTest(int scheduleTest, int lDLocalDrivingAppID)
        {
            InitializeComponent();
            _TestType = (clsTestType.enScheduleTest)scheduleTest;
            LDLocalDrivingAppID = lDLocalDrivingAppID;
        }

        private void LoadData()
        {
            switch (_TestType)
            {

                case clsTestType.enScheduleTest.vision:
                    {
                        lbTypeOfTest.Text = "Vision Test Appointments";
                        this.Text = lbTypeOfTest.Text;
                        pbTestTypeImage.Image = Resources.vision;
                        break;
                    }

                case clsTestType.enScheduleTest.Writen:
                    {
                        lbTypeOfTest.Text = "Written Test Appointments";
                        this.Text = lbTypeOfTest.Text;
                        pbTestTypeImage.Image = Resources.exam;
                        break;
                    }
                case clsTestType.enScheduleTest.Street:
                    {
                        lbTypeOfTest.Text = "Street Test Appointments";
                        this.Text = lbTypeOfTest.Text;
                        pbTestTypeImage.Image = Resources.driving_school;
                        break;
                    }
            }

        }

        private void frmListAppoinmentTest_Load(object sender, EventArgs e)
        {
            LoadData();
            ucLocalDrivingLicenseInfo1.LoadApplicationInfoByLocalDrivingAppID(LDLocalDrivingAppID);
            _dtLicenseTestAppointments = clsTestAppointments.GetApplicationTestAppointmentsPerTestType(LDLocalDrivingAppID, _TestType);

            DGAppointment.DataSource = _dtLicenseTestAppointments;
            lbNumberOfRecords.Text = DGAppointment.Rows.Count.ToString();

            if (DGAppointment.Rows.Count > 0)
            {
                DGAppointment.Columns[0].HeaderText = "Appointment ID";
                DGAppointment.Columns[0].Width = 150;

                DGAppointment.Columns[1].HeaderText = "Appointment Date";
                DGAppointment.Columns[1].Width = 200;

                DGAppointment.Columns[2].HeaderText = "Paid Fees";
                DGAppointment.Columns[2].Width = 150;

                DGAppointment.Columns[3].HeaderText = "Is Locked";
                DGAppointment.Columns[3].Width = 100;
            }


        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddApointment_Click(object sender, EventArgs e)
        {
            clsLocalDriveLicense localDrivingLicenseApplication = clsLocalDriveLicense.FindByLocalDrivingAppLicenseID(LDLocalDrivingAppID);


            if (localDrivingLicenseApplication.IsThereAnActiveScheduledTest(_TestType))
            {
                MessageBox.Show("Person Already have an active appointment for this test, You cannot add new appointment", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            //---
            clsTest LastTest = localDrivingLicenseApplication.GetLastTestPerTestType(_TestType);

            if (LastTest == null)
            {
                frmScheduleTest frm1 = new frmScheduleTest(LDLocalDrivingAppID, _TestType);
                frm1.ShowDialog();
                frmListAppoinmentTest_Load(null, null);
                return;
            }

            //if person already passed the test s/he cannot retak it.
            if (LastTest.TestResult == true)
            {
                MessageBox.Show("This person already passed this test before, you can only retake faild test", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmScheduleTest frm2 = new frmScheduleTest
                (LastTest.TestAppointmentInfo.LocalDrivingLicenseApplicationID, _TestType);
            frm2.ShowDialog();
            frmListAppoinmentTest_Load(null, null);
            //---

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmScheduleTest frm = new frmScheduleTest(LDLocalDrivingAppID, _TestType, (int)DGAppointment.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            DGAppointment.DataSource = clsTestAppointments.GetTestAppointmentByLDLID(LDLocalDrivingAppID);
            frmListAppoinmentTest_Load(null, null);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTekeTest frm = new frmTekeTest((int)DGAppointment.CurrentRow.Cells[0].Value, _TestType);
            frm.ShowDialog();
            frmListAppoinmentTest_Load(null, null);
        }
    }
}
