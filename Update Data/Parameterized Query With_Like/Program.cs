using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parameterized_Query_With_Like
{
    internal class Program
    {
        static string ConnectionString = "Server=.;Database=ContactsDB;User id=sa;Password=sa123456";
        static void searchContains(string Contain)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            //    string query = "select * from Contacts where FirstName=@FirstName OR ContactID=@ContactID";
            string query = "select * from Contacts where FirstName like  '%' + @Contains  +  '%' ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Contains", Contain);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    int ContactID = (int)reader["ContactID"];
                    string FirstNamee = (string)reader["FirstName"];

                    string LastName = (string)reader["LastName"];
                    string Email = (string)reader["Email"];
                    string Phone = (string)reader["Phone"];
                    string Address = (string)reader["Address"];
                    int CountryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {ContactID}");
                    Console.WriteLine($"First Name: {FirstNamee}");
                    Console.WriteLine($"Last Name: {LastName}");
                    Console.WriteLine($"Email: {Email}");
                    Console.WriteLine($"Phone: {Phone}");
                    Console.WriteLine($"Address: {Address}");
                    Console.WriteLine($"Country ID: {CountryID}");
                    Console.WriteLine();
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
        static void searchEndsWith(string endwith)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            //    string query = "select * from Contacts where FirstName=@FirstName OR ContactID=@ContactID";
            string query = "select * from Contacts where FirstName like  '%' + @endswith  +  '' ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@endswith", endwith);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    int ContactID = (int)reader["ContactID"];
                    string FirstNamee = (string)reader["FirstName"];

                    string LastName = (string)reader["LastName"];
                    string Email = (string)reader["Email"];
                    string Phone = (string)reader["Phone"];
                    string Address = (string)reader["Address"];
                    int CountryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {ContactID}");
                    Console.WriteLine($"First Name: {FirstNamee}");
                    Console.WriteLine($"Last Name: {LastName}");
                    Console.WriteLine($"Email: {Email}");
                    Console.WriteLine($"Phone: {Phone}");
                    Console.WriteLine($"Address: {Address}");
                    Console.WriteLine($"Country ID: {CountryID}");
                    Console.WriteLine();
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        static void searchStartsWith(string startwith)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            //    string query = "select * from Contacts where FirstName=@FirstName OR ContactID=@ContactID";
            string query = "select * from Contacts where FirstName like  '' + @startswith  +  '%' ";

            SqlCommand command = new SqlCommand(query, connection);
          command.Parameters.AddWithValue("@startswith", startwith);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    int ContactID = (int)reader["ContactID"];
                    string FirstNamee = (string)reader["FirstName"];

                    string LastName = (string)reader["LastName"];
                    string Email = (string)reader["Email"];
                    string Phone = (string)reader["Phone"];
                    string Address = (string)reader["Address"];
                    int CountryID = (int)reader["CountryID"];

                    Console.WriteLine($"Contact ID: {ContactID}");
                    Console.WriteLine($"First Name: {FirstNamee}");
                    Console.WriteLine($"Last Name: {LastName}");
                    Console.WriteLine($"Email: {Email}");
                    Console.WriteLine($"Phone: {Phone}");
                    Console.WriteLine($"Address: {Address}");
                    Console.WriteLine($"Country ID: {CountryID}");
                    Console.WriteLine();
                }
                reader.Close();
                connection.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
            static void Main(string[] args)
        {
            // searchStartsWith("a");
            //  searchEndsWith("i");
           // searchContains("l");
        }
    }
}
