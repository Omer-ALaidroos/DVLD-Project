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

namespace DVLD_Project.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

       

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = clsUser.GetUserByUserNameAndPassword(txtUserName.Text, txtPassword.Text);
            if (clsGlobal.CurrentUser != null)
            {
                this.Hide();
                Form frmMainScreen = new frmMainScreen();
               
                frmMainScreen.Show();
            }
            else
            {
                MessageBox.Show("invalide UserName Or Password.");
            }
        }
    }
}
