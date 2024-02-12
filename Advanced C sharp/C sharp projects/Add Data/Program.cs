using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Add_Data
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
        static void AddNewContact(stContact Contact)
        {

            SqlConnection Connection = new SqlConnection(ConnectionString);
            string query = "insert into Contacts (FirstName,LastName,Email,Phone,Address,CountryID)" +
            "Values(@FirstName,@LastName,@Email,@Phone,@Address,@CountryID)";
            SqlCommand command = new SqlCommand(query, Connection);
            command.Parameters.AddWithValue("@ID", Contact.ID);
            command.Parameters.AddWithValue("@FirstName", Contact.FirstName);
            command.Parameters.AddWithValue("@LastName", Contact.LastName);
            command.Parameters.AddWithValue("@Address", Contact.Address);
            command.Parameters.AddWithValue("@Phone", Contact.Phone);
            command.Parameters.AddWithValue("@CountryID", Contact.CountryID);
            command.Parameters.AddWithValue("@Email", Contact.Email);

            try
            {
                Connection.Open();
                int RowAffected = command.ExecuteNonQuery();
                if (RowAffected > 0) { Console.WriteLine("Record inserted Successfully"); }
                else { Console.WriteLine("Record insertion Faild!"); }
                Connection.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }



        }








        static void Main(string[] args)
        {

            stContact contact = new stContact
            {
                FirstName = "Mohammed",
                LastName = "Abu-Hadhoud",
                Email = "m@example.com",
                Phone = "1234567890",
                Address = "123 Main Street",
                CountryID = 8,
            };
            AddNewContact(contact);



        }
    }
}