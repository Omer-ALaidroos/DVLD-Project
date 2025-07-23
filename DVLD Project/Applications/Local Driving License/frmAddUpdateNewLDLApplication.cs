using DVLD_Project.Global_Classes;
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
    public partial class frmAddUpdateNewLDLApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        clsLocalDriveLicense _LocalDrivingLicenseApplication;

        public frmAddUpdateNewLDLApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmAddUpdateNewLDLApplication(int ldl_AppID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = ldl_AppID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillAppInfo()
        {
            DataTable dt = clsLicenseClass.GetAllLicenseClasses();

            foreach (DataRow row in dt.Rows)
            {
                cmbLicenseClass.Items.Add(row["ClassName"].ToString());
            }

            cmbLicenseClass.StartIndex = clsLicenseClass.GetClassIDByName("Class 3 - Ordinary driving license") - 1;

            lbAppFees.Text = dt.Rows[2]["ClassFees"].ToString();
            lbCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lbAppDate.Text = DateTime.Now.ToString("d");
        }
        private void _LoadData()
        {
            FillAppInfo();
            if (_Mode == enMode.AddNew)
            {

                lbAppDate.Enabled = false;
                lbAppFees.Enabled = false;
                lbLDLAppID.Enabled = false;
                lbCreatedBy.Enabled = false;
                cmbLicenseClass.Enabled = false;

                btnSave.Enabled = false;

                _LocalDrivingLicenseApplication = new clsLocalDriveLicense();
                lbTypeOfEdit.Text = "New Local Driving License Application";

               
                return;
            }

            lbTypeOfEdit.Text = "Update Local Driving License Application";




            ucPersonDetailsWithFilter1.FilterEnabled = false;
            _LocalDrivingLicenseApplication = clsLocalDriveLicense.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            
            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("No Application with ID = " + _LocalDrivingLicenseApplicationID, "Application Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            ucPersonDetailsWithFilter1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            lbLDLAppID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lbAppDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString().ToString();
            cmbLicenseClass.SelectedIndex = cmbLicenseClass.FindString(clsLicenseClass.Find(_LocalDrivingLicenseApplication.LicenseClassID).ClassName);
            lbAppFees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            lbCreatedBy.Text = clsUser.FindUserByUserID(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;


        }

        private void frmNewLDLApplication_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (ucPersonDetailsWithFilter1.SelectedPersonInfo == null)
            {
                MessageBox.Show("Please select a person");
                
               
            }
            else 
            {
                tabLDLApp.SelectedIndex += 1;
                lbAppDate.Enabled = true;
                lbAppFees.Enabled = true;
                lbLDLAppID.Enabled = true;
                lbCreatedBy.Enabled = true;
                cmbLicenseClass.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }


            int LicenseClassID = clsLicenseClass.GetClassIDByName(cmbLicenseClass.Text);


            if (clsApplication.IsPersonHasSameApp(clsLicenseClass.GetClassIDByName(cmbLicenseClass.Text),
                ucPersonDetailsWithFilter1.PersonID))
            {
                if(!clsApplication.IsAppCanceldOrCompleted(LicenseClassID,
                ucPersonDetailsWithFilter1.PersonID))
                {
                    MessageBox.Show("Choose another License class,the sekected person Already have an active" +
                        "application for the selected class .");
                    return;

                }

            }





            _LocalDrivingLicenseApplication.ApplicantPersonID = ucPersonDetailsWithFilter1.PersonID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToDouble(lbAppFees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = 1;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;


            if (_LocalDrivingLicenseApplication._Save())
            {
                _Mode = enMode.Update;
                lbTypeOfEdit.Text = "Update Local Driving License Application " ;
                lbLDLAppID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();

                MessageBox.Show("Data Saved Successfully.");

            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
            }


            

            
        }
    }
}
