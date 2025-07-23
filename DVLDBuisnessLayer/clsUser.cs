using DVLDDataAccsessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVLDBuisnessLayer
{
    public class clsUser
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public clsUser()
        {
            UserID = -1;
            PersonID = -1;
            UserName = "";
            Password = "";
            IsActive = true;

            Mode = enMode.AddNew;

        }

        public clsUser(int userID, int personID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            Mode = enMode.Update;
        }

        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }

        public static bool IsUserExistByUserID(int UserID)
        {
            return clsUserData.IsUserExistByUSerID(UserID);
        }
        public static bool IsUserExistByPersonid(int PersonID)
        {
            return clsUserData.IsUserExistByUSerID(PersonID);
        }
        
        public static clsUser GetUserByUserNameAndPassword(string UserName, string Password)
        {
            int PersonID = -1, UserID = -1;
            bool IsActive = true;

            if(clsUserData.GetUserInfoByUserNameAndPassword(UserName, Password, ref UserID, ref PersonID, ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);

            }

            return null;
        }
        private bool _AddNewUser()
        {
            this.UserID = clsUserData.AddNewUser(this.PersonID, this.UserName, this.Password, this.IsActive);

            return (this.UserID != 0);
        }

        private bool _UpdateUser()
        {
           return clsUserData.UpdateUser(this.UserID,this.PersonID,this.UserName,this.Password,this.IsActive);

        }

        public static clsUser FindUserByUserID(int UserID )
        {
            int PersonID = -1;
            string UserName = "", Password = "";
            bool IsActive = true;

            if (clsUserData.GetUserInfoByUserID(UserID,ref PersonID,ref UserName,ref Password,ref IsActive))
            {
                return new clsUser(UserID, PersonID, UserName, Password, IsActive);
            }
            else
            {
                return null;
            }
          
        }
        public static clsUser FindByPersonID(int PersonID)
        {
            int UserID = -1;
            string UserName = "", Password = "";
            bool IsActive = false;

            bool IsFound = clsUserData.GetUserInfoByPersonID
                                (PersonID, ref UserID, ref UserName, ref Password, ref IsActive);

            if (IsFound)
                //we return new object of that User with the right data
                return new clsUser(UserID, UserID, UserName, Password, IsActive);
            else
                return null;
        }

        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }

        public bool UpdatePassword(int UserID,string Password)
        {
           return clsUserData.UpdatePassword(UserID,Password);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewUser())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateUser();

            }




            return false;
        }
    }
}
