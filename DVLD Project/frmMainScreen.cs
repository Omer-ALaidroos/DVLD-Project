using DVLD_Project.Global_Classes;
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
        public frmMainScreen()
        {
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
            this.Close();
            Form frmlogin = new frmLogin();
            frmlogin.ShowDialog();
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
    }
}
