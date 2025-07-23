using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccsessLayer
{
    public  class clsUserData
    {

        public static DataTable GetAllUsers()
        {

            DataTable dt = new DataTable();
            string Query = "SELECT Users.UserID,Users.PersonID,People.FirstName + ' '  + People.SecondName + ' ' +People.ThirdName + ' ' + People.LastName as FullName " +
                ",Users.UserName,IsActive from Users " +
                "inner join People on Users.PersonID = People.PersonID;";


            SqlConnection connection = new SqlConnection(clsSettingsDataBase.StringConnection);
            SqlCommand command = new SqlCommand(Query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }
        public static bool GetUserInfoByPersonID(int PersonID, ref int UserID, ref string UserName,
    ref string Password, ref bool IsActive)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsSettingsDataBase.StringConnection);

            string query = "SELECT * FROM Users WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    UserID = (int)reader["UserID"];
                    UserName = (string)reader["UserName"];
                    Password = (string)reader["Password"];
                    IsActive = (bool)reader["IsActive"];


                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static bool IsUserExistByUSerID(int UserID)
        {
            bool IsFound = false;


            string Query = "SELECT Found = 1 FROM Users WHERE UserID = @UserID;";

            SqlConnection connection = new SqlConnection(clsSettingsDataBase.StringConnection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                }
                else
                {
                    IsFound = false;
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool IsUserExistByPersonID(int PersonID)
        {
            bool IsFound = false;


            string Query = "SELECT Found = 1 FROM Users WHERE PersonID = @PersonID;";

            SqlConnection connection = new SqlConnection(clsSettingsDataBase.StringConnection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    IsFound = true;
                }
                else
                {
                    IsFound = false;
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }


        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            int UserID = 0;
            string Query = "INSERT INTO Users (PersonID,UserName,Password,IsActive) VALUES (@PersonID,@UserName,@Password,@IsActive); SELECT SCOPE_IDENTITY();";
            SqlConnection connection = new SqlConnection(clsSettingsDataBase.StringConnection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                connection.Open();
                UserID = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                UserID = 0;
            }
            finally
            {
                connection.Close();
            }
            return UserID;
        }  
        
        public static bool UpdateUser(int UserID, int PersonID, string UserName, string Password, bool IsActive)
        {
            int RowAffected = 0;
           
            string Query = "UPDATE Users SET PersonID = @PersonID, UserName = @UserName, Password = @Password, IsActive = @IsActive WHERE UserID = @UserID;";
            SqlConnection connection = new SqlConnection(clsSettingsDataBase.StringConnection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            try
            {
                connection.Open();
               RowAffected = Convert.ToInt32( command.ExecuteNonQuery());
                
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
               RowAffected = 0;
            }
            finally
            {
                connection.Close();
            }
            return (RowAffected != 0);
        }


        public static bool DeleteUser(int UserID)
        {
            bool IsDeleted = false;
            string Query = "DELETE FROM Users WHERE UserID = @UserID;";
            SqlConnection connection = new SqlConnection(clsSettingsDataBase.StringConnection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                IsDeleted = true;
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                IsDeleted = false;
            }
            finally
            {
                connection.Close();
            }
            return IsDeleted;
        }


        public static bool GetUserInfoByUserID(int UserID,ref int PersonID,ref string UserName,ref string Password,ref bool IsActive)
        {
            
            bool IsFound = false;
            string Query = "SELECT PersonID, UserName, Password, IsActive " +
                           "FROM Users WHERE UserID = @UserID;";

            SqlConnection connection = new SqlConnection(clsSettingsDataBase.StringConnection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = Convert.ToInt32(reader["PersonID"].ToString());
                    UserName = reader["UserName"].ToString();
                    Password = reader["Password"].ToString();
                    IsActive = Convert.ToBoolean(reader["IsActive"].ToString());
                    

                    reader.Close();

                }
                else
                {
                    IsFound = false;
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }


        public static bool UpdatePassword(int UserID, string Password)
        {
              int RowAffected = 0; ;
            string Query = "UPDATE Users SET Password = @Password WHERE UserID = @UserID;";
            SqlConnection connection = new SqlConnection(clsSettingsDataBase.StringConnection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@UserID", UserID);

            try
            {
                connection.Open();
                RowAffected =  Convert.ToInt32(command.ExecuteNonQuery()) ;
               
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                RowAffected = 0 ;
            }
            finally
            {
                connection.Close();
            }
            return (RowAffected != 0);

        }

        public static bool GetUserInfoByUserNameAndPassword(string UserName, string Password, ref int UserID, ref int PersonID, ref bool IsActive)
        {
            bool IsFound = false;
            string Query = "SELECT UserID, PersonID, IsActive " +
                           "FROM Users WHERE UserName = @UserName AND Password =@Password;";

            SqlConnection connection = new SqlConnection(clsSettingsDataBase.StringConnection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@Password", Password);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    PersonID = Convert.ToInt32(reader["PersonID"].ToString());
                    UserID = Convert.ToInt32(reader["UserID"].ToString());
                    IsActive = Convert.ToBoolean(reader["IsActive"].ToString());


                    reader.Close();

                }
                else
                {
                    IsFound = false;
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }



    }
}
