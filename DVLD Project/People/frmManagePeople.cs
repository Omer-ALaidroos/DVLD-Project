using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBuisnessLayer;

namespace DVLD_Project
{
    public partial class frmManagePeople : Form
    {

        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();

        //only select the columns that you want to show in the grid
        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                         "FirstName", "SecondName", "ThirdName", "LastName",
                                                         "GenderCaption", "DateOfBirth", "CountryName",
                                                         "Phone", "Email");
        public frmManagePeople()
        {
            InitializeComponent();
        }

       
      

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            _dtPeople = clsPerson.GetAllPeople();
            DGPeople.DataSource = _dtPeople;
            lbNumberOfRecords.Text = DGPeople.RowCount.ToString();


            DGPeople.DataSource = _dtPeople;
            cmbFilterManagePeople.SelectedIndex = 0;
            lbNumberOfRecords.Text = DGPeople.Rows.Count.ToString();
            if (DGPeople.Rows.Count > 0)
            {

                DGPeople.Columns[0].HeaderText = "Person ID";
                DGPeople.Columns[0].Width = 110;

                DGPeople.Columns[1].HeaderText = "National No.";
                DGPeople.Columns[1].Width = 120;


                DGPeople.Columns[2].HeaderText = "First Name";
                DGPeople.Columns[2].Width = 120;

                DGPeople.Columns[3].HeaderText = "Second Name";
                DGPeople.Columns[3].Width = 140;


                DGPeople.Columns[4].HeaderText = "Third Name";
                DGPeople.Columns[4].Width = 120;

                DGPeople.Columns[5].HeaderText = "Last Name";
                DGPeople.Columns[5].Width = 120;

                DGPeople.Columns[6].HeaderText = "Gendor";
                DGPeople.Columns[6].Width = 120;

                DGPeople.Columns[7].HeaderText = "Date Of Birth";
                DGPeople.Columns[7].Width = 140;

                DGPeople.Columns[8].HeaderText = "Nationality";
                DGPeople.Columns[8].Width = 120;


                DGPeople.Columns[9].HeaderText = "Phone";
                DGPeople.Columns[9].Width = 120;


                DGPeople.Columns[10].HeaderText = "Email";
                DGPeople.Columns[10].Width = 170;
            }

           
        }

        public void RefreshDataOfDGPeople()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GenderCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");

            DGPeople.DataSource = _dtPeople;
            lbNumberOfRecords.Text = DGPeople.Rows.Count.ToString();
           
        }
        private void txtFilterManagePeople_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cmbFilterManagePeople.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }

            //Reset the filters in case nothing selected or filter value conains nothing.
            if (txtFilterManagePeople.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                lbNumberOfRecords.Text = DGPeople.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterManagePeople.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterManagePeople.Text.Trim());

            lbNumberOfRecords.Text = DGPeople.Rows.Count.ToString();


        }



        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditPeople frm = new frmEditPeople((int)DGPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (MessageBox.Show("Are you sure you want to delete Person with ID : [" + DGPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {

                //Perform Delele and refresh
                if (clsPerson.DeletePerson((int)DGPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _dtPeople = clsPerson.GetAllPeople();
                    DGPeople.DataSource = _dtPeople;
                }
                else
                {
                    MessageBox.Show("Error in Delete beacuse this person has  another related", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

              
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form frmedit = new frmEditPeople(-1);
            frmedit.Show();

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this feature is not Completed yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this feature is not Completed yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           


            int PersonID = (int)DGPeople.CurrentRow.Cells[0].Value;
            frmPersonDetails frm = new frmPersonDetails(PersonID);
            frm.ShowDialog();
        }

        private void txtFilterManagePeople_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilterManagePeople.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form frmedit = new frmEditPeople();
            frmedit.Show();

            RefreshDataOfDGPeople();
        }

        private void pbManagePeopleIcon_Click(object sender, EventArgs e)
        {

        }

        private void cmbFilterManagePeople_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterManagePeople.Visible = (cmbFilterManagePeople.Text != "None");

            if (txtFilterManagePeople.Visible)
            {
                txtFilterManagePeople.Text = "";
                txtFilterManagePeople.Focus();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
