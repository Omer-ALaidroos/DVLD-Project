using DVLD_Project.People.Controls;
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

namespace DVLD_Project.Users
{
    public partial class frmChangePassword : Form
    {
        int _UseriD;
        clsUser _User ;
        public frmChangePassword(int useriD)
        {
            InitializeComponent();
            _UseriD = useriD;                       
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            _User = clsUser.FindUserByUserID(_UseriD);
            ucUserInfo1.LoadUserInfo(_UseriD);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private bool CheckFillInfo()
        {
            errorProvider1.Clear();

            bool isValid = true;
           

            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                errorProvider1.SetError(txtCurrentPassword, "CurrentPassword is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                errorProvider1.SetError(txtNewPassword, "NewPassword is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                errorProvider1.SetError(txtConfirmPassword, "ConfirmPassword is required.");
                isValid = false;
            }

            return isValid;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!CheckFillInfo())
            {
                return;
            }

            if (_User.UpdatePassword(_UseriD, txtConfirmPassword.Text))
            {
                MessageBox.Show("Password updated Succsessfully");

            }
            else
            {
                MessageBox.Show("Password is not updated");
            }
           
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "password is wrong");
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);
            };
        }

        private void ucUserInfo1_Load(object sender, EventArgs e)
        {

        }

        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            };

            if (_User.Password != txtCurrentPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtCurrentPassword, "Current password is wrong!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtCurrentPassword, null);
            };
        }
    }
}
