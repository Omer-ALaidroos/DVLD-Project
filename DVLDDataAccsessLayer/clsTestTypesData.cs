using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDDataAccsessLayer
{
    public class clsTestTypesData
    {

        public static DataTable GetAllTestTypes()
        {
            DataTable dt = new DataTable();
            string Query = "SELECT * FROM TestTypes;";

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

        public static bool GetTestType(int TestTypeID, ref string  TestTypeTitle, ref string TestTypeDescription, ref float TestTypeFees)
        {
            bool result = false;
            string Query = "SELECT * FROM TestTypes WHERE TestTypeID = @TestTypeID;";
            SqlConnection connection = new SqlConnection(clsSettingsDataBase.StringConnection);
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    TestTypeTitle = reader["TestTypeTitle"].ToString();
                    TestTypeDescription = reader["TestTypeDescription"].ToString();
                    TestTypeFees = Convert.ToSingle(reader["TestTypeFees"]);
                    result = true;
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
            return result;
        }

        public static int AddNewTestType(string Title, string Description, float Fees)
        {
            int TestTypeID = -1;

            SqlConnection connection = new SqlConnection(clsSettingsDataBase.StringConnection);

            string query = @"Insert Into TestTypes (TestTypeTitle,TestTypeTitle,TestTypeFees)
                            Values (@TestTypeTitle,@TestTypeDescription,@ApplicationFees)
                            where TestTypeID = @TestTypeID;
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", Title);
            command.Parameters.AddWithValue("@TestTypeDescription", Description);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TestTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }


            return TestTypeID;

        }

        public static bool UpdateTestType(int TestTypeID,  string TestTypeTitle,  string TestTypeDescription,  float TestTypeFees)
        {
            bool result = false;
            string Query = "UPDATE TestTypes SET TestTypeTitle = @TestTypeTitle,TestTypeDescription = @TestTypeDescription ,TestTypeFees = @TestTypeFees WHERE TestTypeID = @TestTypeID;";
            SqlConnection connection = new SqlConnection(clsSettingsDataBase.StringConnection);
            SqlCommand command = new SqlCommand(Query, connection);

            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);

            try
            {
                connection.Open();
                int rows = command.ExecuteNonQuery();
                if (rows > 0)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log it)
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}
