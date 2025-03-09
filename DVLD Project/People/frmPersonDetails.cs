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
    public partial class frmPersonDetails : Form
    {
        clsPerson _Person;
        public frmPersonDetails(int PersonID)
        {
            InitializeComponent();

           ucPersonDetails1.LoadPersonInfo(PersonID);
        }
        public frmPersonDetails(string NationalNo)
        {
            InitializeComponent();
            ucPersonDetails1.LoadPersonInfo(NationalNo);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
           
        }

        private void ucPersonDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
