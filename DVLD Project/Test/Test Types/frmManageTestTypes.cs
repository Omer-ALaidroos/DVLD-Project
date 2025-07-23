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

namespace DVLD_Project.Applications.Test_Types
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        DataTable _dtTestTypes;

        private void _LoadData()
        {
            _dtTestTypes = clsTestType.GetAllTestTypes();

            DGTestTypes.DataSource = _dtTestTypes;
            lbNumberOfRecords.Text = _dtTestTypes.Rows.Count.ToString();

            DGTestTypes.Columns[0].HeaderText = "ID";
            DGTestTypes.Columns[0].Width = 110;

            DGTestTypes.Columns[1].HeaderText = "Title";
            DGTestTypes.Columns[1].Width = 400;

            DGTestTypes.Columns[2].HeaderText = "Description";
            DGTestTypes.Columns[2].Width = 800;

            DGTestTypes.Columns[3].HeaderText = "Fees";
            DGTestTypes.Columns[3].Width = 100;

        }
        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType frm = new frmUpdateTestType((int)DGTestTypes.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _LoadData();
        }
    }
}
