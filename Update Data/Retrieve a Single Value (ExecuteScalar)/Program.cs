using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Retrieve_a_Single_Value__ExecuteScalar_
{
    internal class Program
    {
        static string ConnectionString = "Server=.;Database=ContactsDB;User id=sa;Password=sa123456";
        static string GetFirstName( int ContactID)
        {
            string FirstName = "";
            SqlConnection connection = new SqlConnection(ConnectionString);
            //    string query = "select * from Contacts where FirstName=@FirstName OR ContactID=@ContactID";
            string query = "select firstname from Contacts where ContactID=@ContactID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ContactID );
            try
            {
                connection.Open();
              //  SqlDataReader reader = command.ExecuteReader();
              Object readersinglevalue=command.ExecuteScalar();

                if (readersinglevalue != null)
                {
                     FirstName=readersinglevalue.ToString();
                }
                else
                {
                    FirstName = "";

                }
                         connection.Close();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return FirstName;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetFirstName(1));

        }
    }
}
