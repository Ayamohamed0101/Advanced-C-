using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactsBusinessLayer;
using CountriesBusinessLayer;

namespace ContactsConsoleApp
{
    internal class Program
    {
        static void testUpdateContact(int id)
        {

            clsContact Contact1 = clsContact.Find(id);
            Contact1.FirstName = "m,n,mnm,";
            Contact1.LastName = "Maher";
            Contact1.Email = "A2@a.com";
            Contact1.Phone = "2222";
            Contact1.Address = "222";
            Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
            Contact1.CountryID = 1;
            Contact1.ImagePath = "";

            if (Contact1.Save())
            {
                Console.WriteLine("Contact Updated Successfully ");
            }
            else
            {
                Console.WriteLine("Contact with id = " + id + " not Found");
            }

        }
        static void testDeleteContact(int ID)
        {
            if (clsContact.isContactExist(ID))
            {
                if (clsContact._DeleteContact(ID))
                {

                    Console.WriteLine("DELETED SUCCESSFULLY");
                }
            }
            else { Console.WriteLine("DELETE FAILED"); }

        }     
        static void testAddNewContact()
        {
            clsContact Contact1 = new clsContact();
            Contact1.FirstName = "Fadi";
            Contact1.LastName = "Maher";
            Contact1.Email = "A@a.com";
            Contact1.Phone = "010010";
            Contact1.Address = "address1";
            Contact1.DateOfBirth = new DateTime(1977, 11, 6, 10, 30, 0);
            Contact1.CountryID = 1;
            Contact1.ImagePath = "";

            if (Contact1.Save())
            {
                Console.WriteLine("Contact Added Successfully with Id=" + Contact1.ID);
            }
            else
            {
                Console.WriteLine("Error");
            }

        }

        static void testFindContact(int ID)
        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {

                Console.WriteLine(Contact1.FirstName + " " + Contact1.LastName);
                Console.WriteLine(Contact1.Email);
                Console.WriteLine(Contact1.Phone);
                Console.WriteLine(Contact1.Address);
                Console.WriteLine(Contact1.DateOfBirth);
                Console.WriteLine(Contact1.CountryID);
                Console.WriteLine(Contact1.ImagePath);
            }
            else
            {

                Console.WriteLine("Contact [" + ID + "] Not Found!");
            }
        }

        static void ListContacts()
        {

            DataTable dataTable = clsContact._GetAllContacts();

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]},  {row["FirstName"]} {row["LastName"]}");

            }
        }
        static void isContactExist(int ID)
        {
            if (clsContact.isContactExist(ID))
            {
                Console.WriteLine("YES");
            }
            else { Console.WriteLine("NO"); }

        }
        //static void testGetallContactByID(int ID)
        //{
        //    clsCountry country1=new clsCountry();
        //    if(country1!=null)
        //    {
        //        Console.WriteLine(country1.CountryName );
        //        Console.WriteLine(country1.Code);
        //        Console.WriteLine(country1.CountryID);
        //        Console.WriteLine(country1.PhoneCode);
        //    }


        //}

        /// <summary>
        /// ////////////////////////////////////////////////////////
        /// </summary>

        //---Test Country Business

        static void testFindCountryByID(int ID)

        {
            clsCountry Country1 = clsCountry.Find(ID);

            if (Country1 != null)
            {
                Console.WriteLine("Name: " + Country1.CountryName);
                Console.WriteLine("Code: " + Country1.Code);
                Console.WriteLine("PhoneCode: " + Country1.PhoneCode);

            }

            else
            {
                Console.WriteLine("Country [" + ID + "] Not found!");
            }
        }
        static void testFindCountryByName(string CountryName)

        {
            clsCountry Country1 = clsCountry.Find(CountryName);

            if (Country1 != null)
            {
                Console.WriteLine("Country [" + CountryName + "] isFound with ID = " + Country1.CountryID);
                Console.WriteLine("Name: " + Country1.CountryName);
                Console.WriteLine("Code: " + Country1.Code);
                Console.WriteLine("PhoneCode: " + Country1.PhoneCode);
            }

            else
            {
                Console.WriteLine("Country [" + CountryName + "] Is Not found!");
            }
        }
        static void testIsCountryExistByID(int ID)

        {

            if (clsCountry.isCountryExist(ID))

                Console.WriteLine("Yes, Country is there.");

            else
                Console.WriteLine("No, Country Is not there.");

        }
        static void testIsCountryExistByName(string CountryName)

        {

            if (clsCountry.isCountryExist(CountryName))

                Console.WriteLine("Yes, Country is there.");

            else
                Console.WriteLine("No, Country Is not there.");

        }
        static void testAddNewCountry()
        {
            clsCountry Country1 = new clsCountry();

            Country1.CountryName = "Eygpt2";
            Country1.Code = "222";
            Country1.PhoneCode = "001";


            if (Country1.Save())
            {

                Console.WriteLine("Country Added Successfully with id=" + Country1.CountryID);
            }

        }
        static void testUpdateCountry(int ID)
        {
            clsCountry Country1 = clsCountry.Find(ID);
            if (Country1 != null)
            {
                //update whatever info you want
                Country1.CountryName = "Germany";
                Country1.Code = "11";
                Country1.PhoneCode = "555";


                if (Country1.Save())
                {

                    Console.WriteLine("Country updated Successfully ");
                }

            }
            else
            {
                Console.WriteLine("Country is you want to update is Not found!");
            }
        }
        static void testDeleteCountry(int ID)

        {

            if (clsCountry.isCountryExist(ID))

                if (clsCountry.DeleteCountry(ID))

                    Console.WriteLine("Country Deleted Successfully.");
                else
                    Console.WriteLine("Faild to delete Country.");

            else
                Console.WriteLine("Faild to delete: The Country with id = " + ID + " is not found");

        }
        static void ListCountries()
        {

            DataTable dataTable = clsCountry.GetAllCountries();

            Console.WriteLine("Coutries Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["CountryID"]},  {row["CountryName"]} , {row["Code"]}, {row["PhoneCode"]}");
            }

        }

        static void Main(string[] args)
        {
            
             ListCountries();
            // testFindCountryByID(1);
            //   testFindCountryByName("fourth");
            // testIsCountryExistByID(1);
            //   testAddNewCountry();
            // testDeleteCountry(7);

          //  testUpdateCountry(17);

            //testFindContact(6);
            //  testAddNewContact();
            // testUpdateContact(1);
            //  testDeleteContact(6);
            //    isContactExist(6);
            //    isContactExist(2);

          //  testGetallContactByID(3);
            //ListContacts();
        }
    }
}
