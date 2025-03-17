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
    public partial class frmUserInfo : Form
    {
        int _UseriD;
     
        public frmUserInfo(int UserID)
        {
            InitializeComponent();
            _UseriD = UserID;
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
          
            ucUserInfo1.LoadUserInfo(_UseriD);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
