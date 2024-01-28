using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CountriesDataAccessLayer;

namespace CountriesBusinessLayer
{
    public class clsCountry
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;


        public string CountryName { get; set; }
        public string   PhoneCode { get; set; }
        public string Code { get; set; }
        public int CountryID { get; set; }
        
        public clsCountry() 
        { int CountryID = -1;
            string CountryName = "";
            string PhoneCode = "";
            string Code = "";

            this.Code = Code;
            this.PhoneCode = PhoneCode;
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            Mode = enMode.AddNew;

        }
        private clsCountry(int CountryID, string CountryName, string PhoneCode, string Code)
        {
            this.Code = Code;
            this.PhoneCode = PhoneCode;
            this.CountryID = CountryID;
            this.CountryName = CountryName;
            Mode = enMode.Update;
        }




        private bool _AddNewCountry()
        {
            //call DataAccess Layer 

            this.CountryID = clsCountryDataAccess.AddNewCountry(this.CountryName, this.Code, this.PhoneCode);

            return (this.CountryID != -1);
        }

        private bool _UpdateCountry()
        {
            //call DataAccess Layer 

            return clsCountryDataAccess.UpdateCountry(this.CountryID, this.CountryName, this.Code, this.PhoneCode);

        }

        public static clsCountry Find(int ID)
        {

            string CountryName = "";
            string Code = "";
            string PhoneCode = "";


            int CountryID = -1;

            if (clsCountryDataAccess.GetCountryInfoByID(ID, ref CountryName, ref Code, ref PhoneCode))

                return new clsCountry(ID, CountryName, Code, PhoneCode);
            else
                return null;

        }

        public static clsCountry Find(string CountryName)
        {

            int ID = -1;
            string Code = "";
            string PhoneCode = "";


            if (clsCountryDataAccess.GetCountryInfoByName(ref ID, CountryName, ref Code, ref PhoneCode))

                return new clsCountry(ID, CountryName, Code, PhoneCode);
            else
                return null;

        }


        public bool Save()
        {

            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateCountry();

            }
            return false;
        }

        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetCountryList();

        }

        public static bool DeleteCountry(int ID)
        {
            return clsCountryDataAccess.DeleteCountry(ID);
        }

        public static bool isCountryExist(int ID)
        {
            return clsCountryDataAccess.IsCountryExist(ID);
        }

        public static bool isCountryExist(string CountryName)
        {
            return clsCountryDataAccess.IsCountryExist(CountryName);
        }











    }
}
