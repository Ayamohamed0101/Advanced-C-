using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Find_Single_Contact
{
    internal class Program
    {
        static string ConnectionString = "Server=.;Database=ContactsDB;User id=sa;Password=sa123456";
        public struct stContact
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Address { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public int CountryID { get; set; }

        }
        static bool FindContactByID(int ContactID, ref stContact ContactInfo)
        {
            SqlConnection Connection = new SqlConnection(ConnectionString);
            string query = "select * from Contacts where ContactID=@ContactID ";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@ContactID", ContactID);
            
            bool isFound = false;
            try
            {
                Connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ContactInfo.ID = (int)reader["ContactID"];
                    ContactInfo.FirstName = (string)reader["FirstName"];
                    ContactInfo.LastName = (string)reader["LastName"];
                    ContactInfo.Email = (string)reader["Email"];
                    ContactInfo.Phone = (string)reader["Phone"];
                    ContactInfo.Address = (string)reader["Address"];
                    ContactInfo.CountryID = (int)reader["CountryID"];

                }
                else { isFound = false; }
                reader.Close();
                Connection.Close();


            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return isFound;

        }


    

    static void Main(string[] args)


    {
            stContact ContactInfo = new stContact();

            if (FindContactByID(18, ref ContactInfo))
            {
                Console.WriteLine($"\nContact ID: {ContactInfo.ID}");
                Console.WriteLine($"Name: {ContactInfo.FirstName}");
                Console.WriteLine($"Email: {ContactInfo.Email}");
                Console.WriteLine($"Phone: {ContactInfo.Phone}");
                Console.WriteLine($"Address: {ContactInfo.Address}");
                Console.WriteLine($"CountryID: {ContactInfo.CountryID}");
            }
            else
            {
                Console.WriteLine("Contact not Found");
            }



        }

    }

}


