﻿using DVLDDataAccsessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBuisnessLayer
{
    public class clsApplicationTypes
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public int ID { set; get; }
        public string Title { set; get; }
        public float Fees { set; get; }
        public clsApplicationTypes()

        {
            this.ID = -1;
            this.Title = "";
            this.Fees = 0;
            Mode = enMode.AddNew;

        }

        public clsApplicationTypes(int ID, string ApplicationTypeTitel, float ApplicationTypeFees)

        {
            this.ID = ID;
            this.Title = ApplicationTypeTitel;
            this.Fees = ApplicationTypeFees;
            Mode = enMode.Update;
        }
        public static DataTable GetAllApplicationTypes()
        {
            return clsApplicationTypesData.GetAllApplicationTypes();
        }

        public static bool GetApplicationType(int ApplicationTypeID, ref string ApplicationTypeTitle, ref float ApplicationFees)
        {
            return clsApplicationTypesData.GetApplicationType(ApplicationTypeID, ref ApplicationTypeTitle, ref ApplicationFees);
        }

        
        private bool _UpdateApplicationType()
        {
            //call DataAccess Layer 

            return clsApplicationTypesData.UpdateApplicationType(this.ID, this.Title, this.Fees);
        }
        private bool _AddNewApplicationType()
        {
            //call DataAccess Layer 

            this.ID = clsApplicationTypesData.AddNewApplicationType(this.Title, this.Fees);


            return (this.ID != -1);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplicationType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateApplicationType();

            }

            return false;
        }

       
        public static clsApplicationTypes Find(int ID)
        {
            string Title = ""; float Fees = 0;

            if (clsApplicationTypesData.GetApplicationTypeInfoByID((int)ID, ref Title, ref Fees))

                return new clsApplicationTypes(ID, Title, Fees);
            else
                return null;

        }
    }
}
