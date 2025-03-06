using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Project
{
    public partial class ucPersonDetails : UserControl
    {
        public ucPersonDetails()
        {
            InitializeComponent();
        }

        private void ucPersonDetails_Load(object sender, EventArgs e)
        {

        }

        public string PersonID
        {
            get { return lbPersonID.Text; }
            set { lbPersonID.Text = value; }
        }
        public string Name
        {
            get { return lbName.Text; }
            set { lbName.Text = value; }
        }
        public string NationalNo
        {
            get { return lbNationalNo.Text; }
            set { lbNationalNo.Text = value; }
        }

        // Methods to get and set the text of label lbGender, lbBirthDate, lbAddress, lbPhoneNo, lbEmail
        public string Gender
        {
            get { return lbGender.Text; }
            set { lbGender.Text = value; }
        }

        public string BirthDate
        {
            get { return lbDateOfBirth.Text; }
            set { lbDateOfBirth.Text = value; }
        }

        public string Address
        {
            get { return lbAddress.Text; }
            set { lbAddress.Text = value; }
        }

        public string PhoneNo
        {
            get { return lbPhone.Text; }
            set { lbPhone.Text = value; }
        }

        public string Email
        {
            get { return lbEmail.Text; }
            set { lbEmail.Text = value; }
        }

        public string Country
        {
            get { return lbCountry.Text; }
            set { lbCountry.Text = value; }
        }

        public string ImagePath
        {
            set { pbImagePerson.Load(value); }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
