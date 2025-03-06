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
        public frmManagePeople()
        {
            InitializeComponent();
        }

        DataTable dtManagePeople;
        private void _FillFiltreBoxByData()
        {
            foreach (DataGridViewColumn column in DGPeople.Columns)
            {
                cmbFilterManagePeople.Items.Add(column.HeaderText);
            }

            cmbFilterManagePeople.StartIndex = 0;
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            dtManagePeople = clsPerson.GetAllPeople();
            DGPeople.DataSource = dtManagePeople;
            lbNumberOfRecords.Text = DGPeople.RowCount.ToString();
            _FillFiltreBoxByData();
        }

        public void RefreshDataOfDGPeople()
        {
            dtManagePeople = clsPerson.GetAllPeople();
            DGPeople.DataSource = dtManagePeople;
            lbNumberOfRecords.Text = DGPeople.RowCount.ToString();
        }
        private void txtFilterManagePeople_TextChanged(object sender, EventArgs e)
        {
            if(txtFilterManagePeople.Text == " ")
            {
                DGPeople.DataSource = dtManagePeople;
                return;
            }
            if (cmbFilterManagePeople.SelectedItem == null || txtFilterManagePeople.Text == "")
            {
                DGPeople.DataSource = dtManagePeople;
                return;
            }

            string filterColumn = cmbFilterManagePeople.SelectedItem.ToString();
            string filterText = txtFilterManagePeople.Text;

            // Check the data type of the column
            DataColumn column = dtManagePeople.Columns[filterColumn];
            StringBuilder filterBuilder = new StringBuilder();

            if (column.DataType == typeof(int))
            {
                filterBuilder.AppendFormat("[{0}] = {1}", filterColumn, filterText);
            }
            else
            {
                filterBuilder.AppendFormat("[{0}] LIKE '%{1}%'", filterColumn, filterText);
            }

            DataView dv = dtManagePeople.DefaultView;
            dv.RowFilter = filterBuilder.ToString();

            DGPeople.DataSource = dv;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Form frmedit = new frmEditPeople(-1);
            frmedit.Show();
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
                    dtManagePeople = clsPerson.GetAllPeople();
                    DGPeople.DataSource = dtManagePeople;
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
            clsPerson Person = new clsPerson((int)DGPeople.CurrentRow.Cells[0].Value, (string)DGPeople.CurrentRow.Cells[1].Value,
                (string)DGPeople.CurrentRow.Cells[2].Value, (string)DGPeople.CurrentRow.Cells[3].Value,
                (string)DGPeople.CurrentRow.Cells[4].Value, (string)DGPeople.CurrentRow.Cells[5].Value,
                Convert.ToDateTime(DGPeople.CurrentRow.Cells[6].Value), (byte)DGPeople.CurrentRow.Cells[7].Value,
                (string)DGPeople.CurrentRow.Cells[8].Value, (string)DGPeople.CurrentRow.Cells[9].Value,
                (string)DGPeople.CurrentRow.Cells[10].Value, (int)DGPeople.CurrentRow.Cells[11].Value,
                (string)DGPeople.CurrentRow.Cells[12].Value);


            frmPersonDetails frm = new frmPersonDetails(Person);
            frm.ShowDialog();
        }

        private void txtFilterManagePeople_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cmbFilterManagePeople.SelectedIndex == 1 || cmbFilterManagePeople.SelectedIndex == 2 ||
                cmbFilterManagePeople.SelectedIndex == 3 || cmbFilterManagePeople.SelectedIndex == 4 ||
                cmbFilterManagePeople.SelectedIndex == 5 || cmbFilterManagePeople.SelectedIndex == 8 ||
                cmbFilterManagePeople.SelectedIndex == 10 )
            {
                if(!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) &&  e.KeyChar != ' ')
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
