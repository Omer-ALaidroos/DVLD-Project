using DVLD_Project.Properties;
using DVLDBuisnessLayer;
using System;
using System.IO;
using System.Windows.Forms;
namespace DVLD_Project
{
    public partial class ucPersonDetails : UserControl
    {
        private clsPerson _Person;

        private int _PersonID = -1;
        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }
        public ucPersonDetails()
        {
            InitializeComponent();
        }

        private void ucPersonDetails_Load(object sender, EventArgs e)
        {

        }
        private void _LoadPersonImage()
        {
            if (_Person.Gendor == 0)
                pbImagePerson.Image = Resources.Male;
            else
                pbImagePerson.Image = Resources.Female;

            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbImagePerson.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void _FillPersonInfo()
        {
            llbEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lbPersonID.Text = _Person.PersonID.ToString();
            lbNationalNo.Text = _Person.NationalNo;
            lbName.Text = _Person.FullName;
            lbGender.Text = _Person.Gendor == 0 ? "Male" : "Female";
            lbEmail.Text = _Person.Email;
            lbPhone.Text = _Person.Phone;
            lbDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lbCountry.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            lbAddress.Text = _Person.Address;
            _LoadPersonImage();




        }
        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.FindPersonByID(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.FindPersonByNationalNo(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with National No. = " + NationalNo.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }


        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lbPersonID.Text = "[????]";
            lbNationalNo.Text = "[????]";
            lbName.Text = "[????]";
            
            lbGender.Text = "[????]";
            lbEmail.Text = "[????]";
            lbPhone.Text = "[????]";
            lbDateOfBirth.Text = "[????]";
            lbCountry.Text = "[????]";
            lbAddress.Text = "[????]";
            pbImagePerson.Image = Resources.Male;

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void llbEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmEditPeople frm = new frmEditPeople(_PersonID);
            frm.ShowDialog();

            //refresh
            LoadPersonInfo(_PersonID);
        }
    }
}
