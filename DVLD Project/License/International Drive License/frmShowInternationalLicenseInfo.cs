using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.License.International_Drive_License
{
    public partial class frmShowInternationalLicenseInfo : Form
    {
        private int _InternationalLicenseID;
        public frmShowInternationalLicenseInfo(int InternationalLicenseiD)
        {
            _InternationalLicenseID = InternationalLicenseiD;
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        private void frmShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ucInternationalDriverInfo1.LoadInfo(_InternationalLicenseID);
        }
    }
}
