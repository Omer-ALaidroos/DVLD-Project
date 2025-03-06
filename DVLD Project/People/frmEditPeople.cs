using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Project.Global_Classes;
using DVLD_Project.Properties;
using DVLDBuisnessLayer;

namespace DVLD_Project
{
    public partial class frmEditPeople : Form
    {
        private ErrorProvider errorProvider;

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        clsPerson _Person;
        int _PersonID;
        string selectedFilePath;

        public frmEditPeople(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            if (_PersonID == -1)
            {
                Mode = enMode.AddNew;
            }
            else
            {
                Mode = enMode.Update;
            }

            errorProvider = new ErrorProvider();
        }

        private void FillcmbCountry()
        {
            cmbCountries.StartIndex = clsCountry.GetCountryIDByName("Yemen") - 1;
            DataTable dt = clsCountry.GetAllCountries();

            foreach (DataRow row in dt.Rows)
            {
                cmbCountries.Items.Add(row["CountryName"].ToString());
            }
        }

        private void PeopleLoad()
        {
            FillcmbCountry();
            if (Mode == enMode.AddNew)
            {
                rdbMale.Checked = true;
                _Person = new clsPerson();
                lbTypeOfEdit.Text = "Add New Person";
               
                pbImageSex.Image = imlRequireImages.Images[0];
                llbRemoveImage.Visible = false;
                return;
            }

            _Person = clsPerson.FindPersonByID(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("Person Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            lbPersonID.Text = _PersonID.ToString();
            lbTypeOfEdit.Text = "Update Person Info " + _Person.PersonID.ToString();
            txtNationalNo.Text = _Person.NationalNo;
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            if (_Person.Gendor == 0)
            {
                rdbMale.Checked = true;
            }
            else
            { rdbFemale.Checked = true; 
            }
          
            cmbCountries.SelectedIndex = _Person.NationalityCountryID - 1;

            if (_Person.ImagePath != "")
            {
                pbImageSex.Load(_Person.ImagePath);
            }
            else
            {
                if (rdbMale.Checked)
                {
                    pbImageSex.Image = imlRequireImages.Images[0];
                }
                else
                {
                    pbImageSex.Image = imlRequireImages.Images[1];
                }
              
            }

            selectedFilePath = _Person.ImagePath;

            if (_Person.Gendor == 0)
            {
                rdbMale.Checked = true;
            }
            else
            {
                rdbFemale.Checked = true;
            }
        }

        private void frmEditPeople_Load(object sender, EventArgs e)
        {
            
            this.StartPosition = FormStartPosition.CenterScreen;
            PeopleLoad();
        }
        private bool CheckValideOfBoxes()
        {
            // Clear previous error messages
            errorProvider.Clear();

            bool isValid = true;

            // Validate NationalNo
            if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                errorProvider.SetError(txtNationalNo, "NationalNo is required.");
                isValid = false;
            }

            // Validate FirstName
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                errorProvider.SetError(txtFirstName, "First Name is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtSecondName.Text))
            {
                errorProvider.SetError(txtSecondName, "Seconde Name is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtThirdName.Text))
            {
                errorProvider.SetError(txtThirdName, "third Name is required.");
                isValid = false;
            }
            // Validate LastName
            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                errorProvider.SetError(txtLastName, "Last Name is required.");
                isValid = false;
            }

            // Validate Email
            //if (string.IsNullOrWhiteSpace(txtEmail.Text))
            //{
            //    errorProvider.SetError(txtEmail, "Email is required.");
            //    isValid = false;
            //}
            //else if (!IsValidEmail(txtEmail.Text))
            //{
            //    errorProvider.SetError(txtEmail, "Invalid email format.");
            //    isValid = false;
            //}

            // Validate Phone
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                errorProvider.SetError(txtPhone, "Phone number is required.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                errorProvider.SetError(txtAddress, "address is required.");
                isValid = false;
            }

            return isValid;
           
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
           

            if(!CheckValideOfBoxes()) 
            {
                return;
            }

            _Person.NationalNo = txtNationalNo.Text;
            _Person.FirstName = txtFirstName.Text;
            _Person.SecondName = txtSecondName.Text;
            _Person.ThirdName = txtThirdName.Text;
            _Person.LastName = txtLastName.Text;
            _Person.Email = txtEmail.Text;
            _Person.Phone = txtPhone.Text;
            _Person.Address = txtAddress.Text;
            _Person.DateOfBirth = dtpDateOfBirth.Value.Date;
            _Person.ImagePath = selectedFilePath;
            _Person.NationalityCountryID = clsCountry.GetCountryIDByName(cmbCountries.Text);
            if (rdbMale.Checked)
            {
                _Person.Gendor = 0;
            }
            else
            {
                _Person.Gendor = 1;
            }

            _Person.NationalityCountryID = clsCountry.GetCountryIDByName(cmbCountries.Text);
            if (_Person.Save())
            {
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
            }


            Mode = enMode.Update;
            lbTypeOfEdit.Text = "Update Person Info " + _Person.PersonID.ToString();
            lbPersonID.Text = _Person.PersonID.ToString();
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llbSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Process the selected file
                selectedFilePath = openFileDialog1.FileName;

                try
                {
                    pbImageSex.Image = Image.FromFile(selectedFilePath);
                    llbRemoveImage.Visible = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void llbRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbImageSex.ImageLocation = null;
            llbRemoveImage.Visible = false;
        }

        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImageSex.Image != null)
            {
                pbImageSex.Image = imlRequireImages.Images[0];
            }
        }

        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbImageSex.Image != null)
            {
                pbImageSex.Image = imlRequireImages.Images[1];
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;

            //validate email format
            if (!clsvalidation.ValidateEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, null);
            };

        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "This field is required!");
                return;
            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }

            //Make sure the national number is not used by another person
            if (txtNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.IsPersonExist(txtNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNo, "National Number is used for another person!");

            }
            else
            {
                errorProvider1.SetError(txtNationalNo, null);
            }
        }
    }
}
