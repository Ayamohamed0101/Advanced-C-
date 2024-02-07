using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Update_Data
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
        static void UpdateContact(stContact Contact, int ContactID)
        {

            SqlConnection Connection = new SqlConnection(ConnectionString);
            string query = "Update Contacts set FirstName=@FirstName,LastName=@LastName,Email=@Email, Phone=@Phone,Address=@Address,CountryID=@CountryID  Where ContactID=@ContactID";
            
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@ID", Contact.ID);
            command.Parameters.AddWithValue("@FirstName", Contact.FirstName);
            command.Parameters.AddWithValue("@LastName", Contact.LastName);
            command.Parameters.AddWithValue("@Address", Contact.Address);
            command.Parameters.AddWithValue("@Phone", Contact.Phone);
            command.Parameters.AddWithValue("@CountryID", Contact.CountryID);
            command.Parameters.AddWithValue("@Email", Contact.Email);
            command.Parameters.AddWithValue("@ContactID", ContactID);
            try
            {
                Connection.Open();
                int RowAffected = command.ExecuteNonQuery();
                if (RowAffected>0 ) { Console.WriteLine("Updated Successfuly"); }
                else { Console.WriteLine("Record updated Faild!"); }
                Connection.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }



        }



        static void Main(string[] args)
        {

            stContact contact = new stContact
            {
                FirstName = "amgayuiyiud",
                LastName = "Awaad",
                Email = "mohamed@example.com",
                Phone = "167890",
                Address = " Main Street",
                CountryID = 3,
            };
            UpdateContact(contact,6);
           // AddNewContact(contact);
        }
    }
}
