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

namespace DVLD_Project.Applications.Application_Types
{
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }
       private  DataTable _dtApplicationTypes;
        private void _LoadData()
        {
            _dtApplicationTypes = clsApplicationTypes.GetAllApplicationTypes();
            DGApplicationTypes.DataSource = _dtApplicationTypes;
            lbNumberOfRecords.Text = _dtApplicationTypes.Rows.Count.ToString();

            DGApplicationTypes.Columns[0].HeaderText = "ID";
            DGApplicationTypes.Columns[0].Width = 110;

            DGApplicationTypes.Columns[1].HeaderText = "Title";
            DGApplicationTypes.Columns[1].Width = 400;

            DGApplicationTypes.Columns[2].HeaderText = "Fees";
            DGApplicationTypes.Columns[2].Width = 100;
        }
        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadData();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editApplicationTyoeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateApplicationTypes frm = new frmUpdateApplicationTypes(Convert.ToInt32(DGApplicationTypes.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _LoadData();
        }
    }
}
