using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project.License
{
    public partial class frmShowPersonLicenseHistory : Form
    {
        private int _PersonID = -1;
        public frmShowPersonLicenseHistory(int personid)
        {
            _PersonID  = personid;
            InitializeComponent();
        }

        private void frmShowPersonLicenseHistory_Load(object sender, EventArgs e)
        {
            if (_PersonID != -1)
            {
                ucPersonDetailsWithFilter1.LoadPersonInfo(_PersonID);
                ucPersonDetailsWithFilter1.FilterEnabled = false;
                ucDriverLicenses1.LoadInfoByPersonID(_PersonID);
            }
            else
            {
                ucPersonDetailsWithFilter1.Enabled = true;
                ucPersonDetailsWithFilter1.FilterFocus();
            }
        }

        private void ucPersonDetailsWithFilter1_Load(object sender, EventArgs e)
        {

        }
    }
}
