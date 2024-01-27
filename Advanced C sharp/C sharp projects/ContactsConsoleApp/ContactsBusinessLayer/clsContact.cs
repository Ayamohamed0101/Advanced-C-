using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ContactsDataAccessLayer;
namespace ContactsBusinessLayer
{
    public class clsContact
    {
        public enum enMode { AddNew = 0, Update = 1 }
        public enMode Mode = enMode.AddNew;
       
        public int ID { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Address { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string ImagePath { set; get; }
        public int CountryID { set; get; }
        public clsContact()
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.CountryID = -1;
            this.ImagePath = "";
            this.Mode = enMode.AddNew;
        }

        private clsContact(int ID, string FirstName, string LastName, string Email,
           string Phone, string Address, DateTime DateOfBirth, string ImagePath, int CountryID)
        {

            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.ImagePath = ImagePath;
            this.CountryID = CountryID;
            this.Mode = enMode.Update;
        }




        public static clsContact Find(int ID)
        {

            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;

            if (clsContactDataAccess.GetContactInfoByID(ID, ref FirstName, ref LastName, ref Email,
                ref Phone, ref Address, ref DateOfBirth, ref CountryID, ref ImagePath))
            {

                return new clsContact(ID, FirstName, LastName, Email, Phone, Address, DateOfBirth, ImagePath, CountryID);

            }
            else { return null; }

        }
       
        public bool _AddnewContact()
        {
            this.ID = clsContactDataAccess.AddNewContact(this.FirstName, this.LastName, this.Email, this.Phone,
                           this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);

            return (this.ID != -1);

        }
        private bool _UpdateContact()
        {

            return clsContactDataAccess.UpdateContact(this.ID, this.FirstName, this.LastName, this.Email, this.Phone,
                this.Address, this.DateOfBirth, this.CountryID, this.ImagePath);

        }
        public static   bool _DeleteContact(int ID)
        {
            return clsContactDataAccess.DeleteContact(ID) ==true;

        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddnewContact())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else { return false; }

                case enMode.Update:
                    return (_UpdateContact());
            }
            return false;
        }

        public static DataTable _GetAllContacts()
        {
            return  clsContactDataAccess.GetAllContacts();


        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~





        public static bool isContactExist(int ID) { return clsContactDataAccess.IsContactExist(ID); }








    }


}

