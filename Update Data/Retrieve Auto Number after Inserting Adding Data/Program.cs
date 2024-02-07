using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrieve_Auto_Number_after_Inserting_Adding_Data
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
            "Values(@FirstName,@LastName,@Email,@Phone,@Address,@CountryID)"+ "select SCOPE_IDENTITY()";
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
                object RowAffected = command.ExecuteNonQuery();
                if (RowAffected!=null && int.TryParse(RowAffected.ToString(),out int insertedvalue)  ) { Console.WriteLine($"new inserted id  {insertedvalue} " ); }
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
                LastName = "Awaad",
                Email = "mohamed@example.com",
                Phone = "167890",
                Address = " Main Street",
                CountryID = 3,
            };
            AddNewContact(contact);


        }
    }
}
