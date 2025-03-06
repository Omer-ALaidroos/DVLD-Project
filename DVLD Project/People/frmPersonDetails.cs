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
        public frmPersonDetails(clsPerson Person)
        {
            InitializeComponent();

            _Person = Person;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPersonDetails_Load(object sender, EventArgs e)
        {
            ucPersonDetails1.Name = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
            ucPersonDetails1.PersonID = _Person.PersonID.ToString();
            ucPersonDetails1.NationalNo = _Person.NationalNo.ToString();

            if(_Person.Gendor == 0)
            {
                ucPersonDetails1.Gender = "Male";
            }
            else
            {
                ucPersonDetails1.Gender = "Female";
            }
            
            ucPersonDetails1.Email = _Person.Email;
            ucPersonDetails1.Address = _Person.Address;
            ucPersonDetails1.BirthDate = _Person.DateOfBirth.ToString("dd/MMM/yyyy");
            ucPersonDetails1.PhoneNo = _Person.Phone;
            ucPersonDetails1.Country = clsCountry.GetCountryNameByID(_Person.NationalityCountryID);
            if(_Person.ImagePath == " ")
            {
                if (_Person.Gendor != 0)
                {
                    ucPersonDetails1.ImagePath = DefaultImages.Images[1].ToString();
                }
                else
                {
                    ucPersonDetails1.ImagePath = DefaultImages.Images[0].ToString();
                }
               
            }
            else
            {
                try
                {
                    ucPersonDetails1.ImagePath = _Person.ImagePath;
                }
                catch(Exception ex) 
                {
                    if (_Person.Gendor != 0)
                    {
                        ucPersonDetails1.ImagePath = DefaultImages.Images[1].ToString();
                    }
                    else
                    {
                        ucPersonDetails1.ImagePath = DefaultImages.Images[0].ToString();
                    }

                }

            }
        }
    }
}
