using DVLD_Project.Properties;
using DVLDBuisnessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.Users
{
    public partial class frmAddUpdateUser : Form
    {
        clsUser _User;
        clsPerson _Person;
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        private int _UserID;

        public frmAddUpdateUser()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            Mode = enMode.Update;
        }
        private void tapLoginInfo_Click(object sender, EventArgs e)
        {

        }

        private bool CheckRules()
        {
            if (ucPersonDetailsWithFilter1.SelectedPersonInfo == null)
            {
                MessageBox.Show("Please select a person");
                return false;
            }

            if(clsUser.IsUserExistByPersonid(ucPersonDetailsWithFilter1.PersonID))
            {
                MessageBox.Show("selected person already has user ,choose another one ");
                return false;
            }
            return true;
        }

        private bool CheckFillInfo()
        {

            errorProvider1.Clear();

            bool isValid = true;
            if (ucPersonDetailsWithFilter1.SelectedPersonInfo == null)
            {
                MessageBox.Show("Please select a person");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                errorProvider1.SetError(txtUserName, "UserName is required.");
                isValid = false;
            }

            // Validate FirstName
            if (string.IsNullOrWhiteSpace(txtPassWord.Text))
            {
                errorProvider1.SetError(txtPassWord, "PassWord is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "ConfirmPassword  is required.");
                isValid = false;
            }

            return isValid;
        }

        private void LoadData()
        {
            if (Mode == enMode.AddNew)
            {

                txtConfirmPassword.Enabled = false;
                txtUserName.Enabled = false;
                txtPassWord.Enabled = false;
                chbIsActive.Enabled = false;
                btnSave.Enabled = false;
               // tapLoginInfo.Enabled = false;
                _User = new clsUser();
                lbTypeOfEdit.Text = "Add New User";

                
                return;
            }

            _User = clsUser.FindUserByUserID(_UserID);
            _Person = clsPerson.FindPersonByID(_User.PersonID);  
            
            if (_User == null)
            {
                MessageBox.Show("User Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lbTypeOfEdit.Text = "Update New User";
            lbUserID.Text = _UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassWord.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;

            tapLoginInfo.Enabled = true;
            ucPersonDetailsWithFilter1.FilterEnabled = false;
            ucPersonDetailsWithFilter1.LoadPersonInfo(_User.PersonID);
            

        }
        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassWord.Text != txtConfirmPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "password is wrong");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            };

        }

        private void btnSave_Click(object sender, EventArgs e)
        {  

            if (CheckFillInfo())
            {
                _User = new clsUser();
                _User.UserName = txtUserName.Text;
                _User.Password = txtPassWord.Text;

                if (chbIsActive.Checked)
                {
                    _User.IsActive = true;
                }
                else
                {
                    _User.IsActive = false;
                }

                _User.PersonID = ucPersonDetailsWithFilter1.PersonID;

                if (_User.Save())
                {
                    Mode = enMode.Update;
                    lbTypeOfEdit.Text = "Update User Info " + _User.PersonID.ToString();
                    lbUserID.Text = _User.PersonID.ToString();

                    MessageBox.Show("Data Saved Successfully.");
                  
                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.");
                }
            }
            else
            {
                MessageBox.Show("some fields not writen");
            }
        }

        private void tabAddUpdateUser_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            if (CheckRules())
            {
                if (tabAddUpdateUser.SelectedIndex < tabAddUpdateUser.TabCount - 1)
                {
                    tabAddUpdateUser.SelectedIndex += 1;
                    txtConfirmPassword.Enabled = true;
                    txtUserName.Enabled = true;
                    txtPassWord.Enabled = true;
                    chbIsActive.Enabled = true;
                    btnSave.Enabled = true;
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ucPersonDetailsWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
