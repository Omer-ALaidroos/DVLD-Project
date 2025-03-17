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
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }
        private static DataTable _dtAllUsers ;

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            _dtAllUsers = clsUser.GetAllUsers();
            DGManageUsers.DataSource = _dtAllUsers;
            lbNumberOfRecords.Text = DGManageUsers.RowCount.ToString();

            if(cmbFilterManageUsers.Text == "None")
            {
                txtFilterManageUsers.Visible = false;
            }

            if(cmbFilterManageUsers.Text != "Is Active")
            {
                cmbIsActive.Visible = false;
            }

            cmbFilterManageUsers.SelectedIndex = 0;
            lbNumberOfRecords.Text = DGManageUsers.Rows.Count.ToString();
            if (DGManageUsers.Rows.Count > 0)
            {

                DGManageUsers.Columns[0].HeaderText = "User ID";
                DGManageUsers.Columns[0].Width = 100;

                DGManageUsers.Columns[1].HeaderText = "Person ID";
                DGManageUsers.Columns[1].Width = 100;


                DGManageUsers.Columns[2].HeaderText = "FullName";
                DGManageUsers.Columns[2].Width = 250;

                DGManageUsers.Columns[3].HeaderText = "UserName";
                DGManageUsers.Columns[3].Width = 150;


                DGManageUsers.Columns[4].HeaderText = "IsActive";
                DGManageUsers.Columns[4].Width = 100;

               
            }


        }

        private void txtFilterManageUsers_TextChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cmbFilterManageUsers.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "User ID":
                    FilterColumn = "UserID";
                    break;

                case "FullName":
                    FilterColumn = "FullName";
                    break;

                case "Is Active":
                    FilterColumn = "IsActive";
                    break;

                case "UserName":
                    FilterColumn = "UserName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterManageUsers.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lbNumberOfRecords.Text = DGManageUsers.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID" || FilterColumn == "UserID")
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterManageUsers.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterManageUsers.Text.Trim());

            lbNumberOfRecords.Text = DGManageUsers.Rows.Count.ToString();

        }

        private void cmbFilterManageUsers_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch(cmbFilterManageUsers.Text)
            {
                case "None" :
                    {

                        txtFilterManageUsers.Visible = false;
                        cmbIsActive.Visible = false;
                    }
                    break;
                case "IsActive":
                    {
                        txtFilterManageUsers.Visible = false;
                        cmbIsActive.Visible = true;
                    }
                    break;
                default:
                    {

                        txtFilterManageUsers.Visible = true;
                        cmbIsActive.Visible = false;
                    }
                    break;
            }
        }

        private void txtFilterManageUsers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterManageUsers.Text == "PersonID" || cmbFilterManageUsers.Text == "UserID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbIsActive.Text == "All")
            {
                _dtAllUsers.DefaultView.RowFilter = "";
                lbNumberOfRecords.Text = DGManageUsers.Rows.Count.ToString();
            }
            else if (cmbIsActive.Text == "Yes")
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}","IsActive", "true");

            }
            else
            {
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", "IsActive", "false");

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            Form frmaddUpdateUser = new frmAddUpdateUser();
            frmaddUpdateUser.ShowDialog();
            _dtAllUsers = clsUser.GetAllUsers();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete User with ID : [" + DGManageUsers.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsPerson.DeletePerson((int)DGManageUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _dtAllUsers = clsPerson.GetAllPeople();
                    DGManageUsers.DataSource = _dtAllUsers;
                }
                else
                {
                    MessageBox.Show("Error in Delete beacuse this person has  another related", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form frmaddUpdateUser = new frmAddUpdateUser();
            frmaddUpdateUser.ShowDialog();
            _dtAllUsers = clsUser.GetAllUsers();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmaddUpdateUser = new frmAddUpdateUser((int)DGManageUsers.CurrentRow.Cells[0].Value);
            frmaddUpdateUser.ShowDialog();
            _dtAllUsers = clsUser.GetAllUsers();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
          Form frmUserInfo = new frmUserInfo((int)DGManageUsers.CurrentRow.Cells[0].Value);
            frmUserInfo.ShowDialog();


        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmchangePass = new frmChangePassword((int)DGManageUsers.CurrentRow.Cells[0].Value);
            frmchangePass.ShowDialog();
        }
    }
}
