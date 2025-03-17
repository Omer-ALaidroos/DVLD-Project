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

namespace DVLD_Project.Users.Controls
{
    public partial class ucUserInfo : UserControl
    {
        public ucUserInfo()
        {
            InitializeComponent();
        }

        clsUser _User;
        public int PersonID
        {
            set {  ucPersonDetails1.PersonID = value; }
        }

        public int UserID
        {
            set { lbUserID.Text = value.ToString(); }
        }

        public string UserName
        {
            set { lbUserName.Text = value.ToString(); }
        }

        public string IsActive
        {
            set { lbIsActive.Text = value.ToString(); } 
        }
        private void ucPersonDetails1_Load(object sender, EventArgs e)
        {

        }
        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.FindUserByUserID(UserID);

            if (_User == null)
            {
                _ResetPersonInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ucPersonDetails1.LoadPersonInfo(_User.PersonID);
          
            lbUserName.Text = _User.UserName;               
            lbUserID.Text = _User.UserID.ToString();

            if (_User.IsActive)
            {
                lbIsActive.Text = "Yes";
            }
            else
            {
                lbIsActive.Text = "No";
            }
        }

        private void _ResetPersonInfo()
        {

            ucPersonDetails1.ResetPersonInfo();
            lbUserID.Text = "[???]";
            lbUserName.Text = "[???]";
            lbIsActive.Text = "[???]";
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lbUserName_Click(object sender, EventArgs e)
        {

        }
    }
}
