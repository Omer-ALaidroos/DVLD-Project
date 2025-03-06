using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Project.Global_Classes;
using DVLD_Project.Properties;
using DVLDBuisnessLayer;
using TheArtOfDevHtmlRenderer.Adapters;

namespace DVLD_Project
{
    public partial class frmEditPeople : Form
    {
        private ErrorProvider errorProvider;
        // Declare a delegate
        public delegate void DataBackEventHandler(object sender, int PersonID);

        // Declare an event using the delegate
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        clsPerson _Person;
        int _PersonID;
        string selectedFilePath;

        public frmEditPeople(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;

            Mode = enMode.Update;
            errorProvider = new ErrorProvider();
        }

        public frmEditPeople()
        {
            InitializeComponent();

            Mode = enMode.AddNew;
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
           cmbCountries.SelectedIndex = cmbCountries.FindString(_Person.CountryInfo.CountryName);
           

            if (_Person.ImagePath != "")
            {
                pbImageSex.ImageLocation = _Person.ImagePath;
                
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

           
        }

        private bool _HandlePersonImage()
        {

            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbImageSex.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.

                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // We could not delete the file.
                        //log it later   
                    }

                }

                if (pbImageSex.ImageLocation != null)
                {
                    //then we copy the new image to the image folder after we rename it
                    string SourceImageFile = pbImageSex.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        pbImageSex.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

            }
            return true;
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


            if (!_HandlePersonImage())
                return;


            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value.Date;

            if (pbImageSex.ImageLocation != null)
                _Person.ImagePath = pbImageSex.ImageLocation;
            else
                _Person.ImagePath = "";

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
                Mode = enMode.Update;
                lbTypeOfEdit.Text = "Update Person Info " + _Person.PersonID.ToString();
                lbPersonID.Text = _Person.PersonID.ToString();

                MessageBox.Show("Data Saved Successfully.");
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");
            }


           
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
                string FilePath = openFileDialog1.FileName;

                try
                {
                    pbImageSex.Image = Image.FromFile(FilePath);
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



            if (rdbMale.Checked)
                pbImageSex.Image = imlRequireImages.Images[0];
            else
                pbImageSex.Image = imlRequireImages.Images[1];

            llbRemoveImage.Visible = false;
        }

        private void rdbMale_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void rdbFemale_CheckedChanged(object sender, EventArgs e)
        {
            
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

        private void rdbMale_Click(object sender, EventArgs e)
        {
            if (pbImageSex.ImageLocation == null)
            {
                pbImageSex.Image = imlRequireImages.Images[0];
            }
        }

        private void rdbFemale_Click(object sender, EventArgs e)
        {
            if (pbImageSex.ImageLocation == null)
            {
                pbImageSex.Image = imlRequireImages.Images[1];
            }
        }
    }
}
