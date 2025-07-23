using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.License.Local_Drive_License
{
    public partial class frmShowLicenseInfo : Form
    {
        int _LicenseID;
        public frmShowLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            InitializeComponent();
        }


        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            ucDriverLicenseInfo1.LoadInfo(_LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
