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

namespace DVLD_Project.Applications.Test_Types
{
    public partial class frmUpdateTestType : Form
    {
        private int _TestTypeID = -1;
        clsTestType _TestType;
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public frmUpdateTestType(int testTypeID)
        {
            Mode = enMode.Update;
            InitializeComponent();
            _TestTypeID = testTypeID;
        }

        public frmUpdateTestType()
        {
            Mode = enMode.AddNew;
            InitializeComponent();
        }

        private void _LoadData()
        {
            if (Mode == enMode.Update)
            {
                lbTypeOfEdit.Text = "Update Test type";
                _TestType = clsTestType.Find((clsTestType.enScheduleTest)_TestTypeID);
                if (_TestType != null)
                {
                    lbID.Text = _TestTypeID.ToString();
                    txtTitle.Text = _TestType.Title;
                    txtDesription.Text = _TestType.Description;
                    txtFees.Text = _TestType.Fees.ToString();
                }
                else
                {
                    MessageBox.Show("Error loading data");
                    this.Close();
                }
            }
            else
            {
                lbTypeOfEdit.Text = "Add New Test type";
            }


        }
        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _LoadData();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }

            _TestType.Title = txtTitle.Text;
            _TestType.Description = txtDesription.Text;
            _TestType.Fees = Convert.ToSingle(txtFees.Text);
            if (_TestType.Save())
            {
                MessageBox.Show("Test Type Updated Successfully");
                this.Close();
            }
            else
            {
                MessageBox.Show("Error updating Test Type");
            }
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtTitle, "Title cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtTitle, null);
            }
            ;
        }

        private void txtDesription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDesription.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtDesription, "Desription cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtDesription, null);
            }
            ;
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFees, "Fees cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(txtFees, null);
            }
            ;
        }
    }
}
