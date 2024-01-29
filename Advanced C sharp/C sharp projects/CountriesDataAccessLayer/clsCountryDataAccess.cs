using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CountriesDataAccessLayer
{
    public class clsCountryDataAccess
    {

        public static bool GetCountryInfoByID(int CountryID,ref string CountryName,ref string Code,ref string PhoneCode)
        {
            bool IsFound=false;
            SqlConnection connection=new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string query = "select * from Countries where CountryID=@CountryID ";
            SqlCommand cmd=new SqlCommand(query,connection);
            cmd.Parameters.AddWithValue("@CountryID",CountryID);
            try
            {
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                if(read.Read())
                {
                    IsFound = true;
                    CountryName = (string)read["CountryName"];
                    if(read["Code"]!=DBNull.Value)
                    {
                        Code = (string)read["Code"];

                    }
                    else
                    {
                        Code = "";
                    }
                    if (read["PhoneCode"] != DBNull.Value)
                    {
                        PhoneCode = (string)read["PhoneCode"];

                    }
                    else
                    {
                        PhoneCode = "";
                    }

                }
                read.Close();
            }
            catch { IsFound = false; }
            finally { connection.Close(); }
            return IsFound;
           
        }
        /////////////////////////
        ///
        public static bool GetCountryInfoByName( ref int CountryID,  string CountryName, ref string Code, ref string PhoneCode)
        {
            bool IsFound = false;
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string query = "select * from Countries where CountryName=@CountryName ";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                connection.Open();
                SqlDataReader read = cmd.ExecuteReader();
                if (read.Read())
                {
                    IsFound = true;
                   CountryID = (int)read["CountryID"];
                    if (read["Code"] != DBNull.Value)
                    {
                        Code = (string)read["Code"];

                    }
                    else
                    {
                        Code = "";
                    }
                    if (read["PhoneCode"] != DBNull.Value)
                    {
                        PhoneCode = (string)read["PhoneCode"];

                    }
                    else
                    {
                        PhoneCode = "";
                    }

                }
                read.Close();
            }
            catch { IsFound = false; }
            finally { connection.Close(); }
            return IsFound;

        }
        ///////////////////////
        ///
        public static int AddNewCountry( string CountryName,string Code,string PhoneCode)
        {
            int CountryID = -1; // Return new id
            SqlConnection connection=new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string Query = "Insert into Countries (CountryName,Code,PhoneCode) VALUES (@CountryName,@Code,@PhoneCode) SELECT SCOPE_IDENTITY();\r\n  ";

            SqlCommand command= new SqlCommand(Query, connection);
         //   command.Parameters.AddWithValue("@ID", ID);

            command.Parameters.AddWithValue("@CountryName", CountryName);

            if (Code != "")
                command.Parameters.AddWithValue("@Code", Code);
            else
                command.Parameters.AddWithValue("@Code", System.DBNull.Value);

            if (PhoneCode != "")
                command.Parameters.AddWithValue("@PhoneCode", PhoneCode);
            else
                command.Parameters.AddWithValue("@PhoneCode", System.DBNull.Value);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))

                {
                    CountryID = InsertedID;
                }
            }

            catch (Exception ex)

            { return -1; }

            finally { connection.Close(); }
            return CountryID;

        }
        ///////////////////////
        ///
        public static bool UpdateCountry (int CountryID, string CountryName, string Code, string PhoneCode)

        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string Query = "Update Countries set CountryName=@CountryName,Code=@Code, PhoneCode=@PhoneCode where CountryID =@CountryID";

            SqlCommand command = new SqlCommand(Query, connection);
           
            command.Parameters.AddWithValue("@CountryID", CountryID);

            command.Parameters.AddWithValue("@CountryName", CountryName);
         //   if (Code != "")
                command.Parameters.AddWithValue("@Code", Code);
          //  else
      //          command.Parameters.AddWithValue("@Code", System.DBNull.Value);
        //    if (PhoneCode != "")
                command.Parameters.AddWithValue("@PhoneCode", PhoneCode);
       //     else
          //      command.Parameters.AddWithValue("@PhoneCode", System.DBNull.Value);


            try
            {
                connection.Open();
                RowAffected = command.ExecuteNonQuery();

            }

            catch (Exception ex)

            { return false; }

            finally { connection.Close(); }

            return RowAffected >0 ;



        }
        ///////////////////////
        ///
      
        public static DataTable GetCountryList()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM COUNTRIES ORDER BY CountryName";

            SqlCommand command = new SqlCommand(Query, connection);

           

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
              
                    if(reader.HasRows )
                    {
                        dataTable.Load(reader);
                    }
                reader.Close();
            }
            catch
            { 
               // return dataTable; 
            }


            finally
            { 
                connection.Close(); 
            }
            return dataTable;

        }
        ///////////////////////
        ///

        public static bool DeleteCountry (int CountryID)
        {
            int RowAffected = 0;
            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);
            string Query = "Delete Countries where CountryID = @CountryID";
            SqlCommand command = new SqlCommand(Query, connection);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            try
            {

                connection.Open();

                RowAffected = command.ExecuteNonQuery();


            }
            catch { }
            finally { connection.Close(); }

            return RowAffected>0;


        }
        ///////////////////////
        ///

        public static bool IsCountryExist(string CountryName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Countries WHERE CountryName = @CountryName";
            SqlCommand command = new SqlCommand (query, connection);
            command.Parameters.AddWithValue("@CountryName", CountryName);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;//   

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
        public static bool IsCountryExist(int ID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ClsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Countries WHERE CountryID = @CountryID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CountryID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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







    }






}

