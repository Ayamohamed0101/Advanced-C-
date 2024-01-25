


#pragma once
#include<iostream>
#include<fstream>
#include <vector>
#include"clsString.h"
#include <string>

using namespace std;

class clsCurrency
{
private:

	enum enMode { EmptyMode = 0, UpdateMode = 1 };

	//private variables
	enMode _Mode;
	string _Country;
	string _CurrencyCode;
	string _CrruncyName;
	float _Rate;

	//private functions
	static clsCurrency _ConvertLineToCurrencyObject(string Line, string Seperator = "#//#") {
		vector<string> vCurrencyData = ClsString::Split(Line, Seperator);
		return clsCurrency(enMode::UpdateMode, vCurrencyData[0], vCurrencyData[1], vCurrencyData[2], stof(vCurrencyData[3]));

	}

	static string _ConvertCurrencyObjectToLine(clsCurrency Currency, string Seperator = "#//#") {
		return Currency.get_Country() + Seperator
			+ Currency.get_CurrencyCode() + Seperator
			+ Currency.get_CurrencyName() + Seperator
			+ to_string(Currency.get_Rate());
	}

	static vector<clsCurrency> _LoadCurrencysDataFromFile() {
		vector<clsCurrency> vCurrencys;

		fstream MyFile;
		MyFile.open("Currencies.txt", ios::in);

		if (MyFile.is_open()) {
			string Line;

			while (getline(MyFile, Line)) {
				vCurrencys.push_back(_ConvertLineToCurrencyObject(Line));
			}
			MyFile.close();
		}
		return vCurrencys;
	}

	static void _SaveCurrencyDataToFile(vector<clsCurrency> vCurrencys) {
		fstream MyFile;
		MyFile.open("Currencies.txt", ios::out);

		if (MyFile.is_open()) {
			for (clsCurrency Currency : vCurrencys) {
				MyFile << _ConvertCurrencyObjectToLine(Currency) << endl;
			}
			MyFile.close();
		}
	}

	void _Update() {
		vector<clsCurrency>vCurrencys = _LoadCurrencysDataFromFile();
		for (clsCurrency& Currency : vCurrencys) {
			if (Currency.get_CurrencyCode() == this->_CurrencyCode) {
				Currency = *this;
			}
		}
		_SaveCurrencyDataToFile(vCurrencys);
	}

	static clsCurrency getEmptyCurrencyObject() {
		return clsCurrency(enMode::EmptyMode, "", "", "", 0);
	}

public:
	//constructors
	clsCurrency(enMode Mode, string Country, string CurrencyCode, string currencyName, float Rate) {
		this->_Mode = Mode;
		this->_Country = Country;
		this->_CurrencyCode = CurrencyCode;
		this->_CrruncyName = currencyName;
		this->_Rate = Rate;
	}

	//setters
	void UpdateRate(float Rate) {
		this->_Rate = Rate;
		_Update();
	};
	//getters
	enMode get_Mode() { return this->_Mode; }
	string get_Country() { return this->_Country; }
	string get_CurrencyCode() { return this->_CurrencyCode; }
	string get_CurrencyName() { return this->_CrruncyName; }
	float get_Rate() { return this->_Rate; }

	//Public functions
	bool IsEmpty() { return (this->_Mode == enMode::EmptyMode); }

	static clsCurrency FindByCode(string CurrencyCode) {
		CurrencyCode = ClsString::UpperAllString(CurrencyCode);
		fstream Myfile;
		Myfile.open("Currencies.txt", ios::in);

		if (Myfile.is_open()) {
			string Line;
			while (getline(Myfile, Line)) {
				clsCurrency Currency = _ConvertLineToCurrencyObject(Line);
				if (Currency.get_CurrencyCode() == CurrencyCode) {
					Myfile.close();
					return Currency;
				}

			}
		}
		return getEmptyCurrencyObject();
	}

	static clsCurrency FindByCountry(string Country) {
		Country = ClsString::UpperAllString(Country);
		fstream Myfile;
		Myfile.open("Currencies.txt", ios::in);

		if (Myfile.is_open()) {
			string Line;
			while (getline(Myfile, Line)) {
				clsCurrency Currency = _ConvertLineToCurrencyObject(Line);
				if (ClsString::UpperAllString(Currency.get_Country()) == Country) {
					Myfile.close();
					return Currency;
				}

			}
		}
		return getEmptyCurrencyObject();
	}

	static bool IsCurrencyExist(string CurrencyCode) {
		clsCurrency c1 = FindByCode(CurrencyCode);
		return (!c1.IsEmpty());
	}

	static vector<clsCurrency> GetCurrenciesList() {
		return _LoadCurrencysDataFromFile();
	}

};


























//#pragma once
//#include<bits/stdc++.h>
//#include<iostream>
//#include <string>
//using namespace std;
//#include"ClsString.h"
//class clsCurrency
//{
//private:
// 	 enum enMode { EmptyMode = 0 , UpdateMode = 1 };
//	 enMode  _Mode;
//	 float   _Rate;
//	 string  _Country;
//	 string  _CurrencyCode;
//	 string  _CurrencyName;
//	 static clsCurrency _ConverttoRecord(string line,string seprator= "#//#" )
//	 {
//		 vector <string> vRecord;
//
//		 vRecord = ClsString::Split(line, seprator);
//		 return 
//			 ( clsCurrency(enMode::UpdateMode , vRecord[0],vRecord[1] ,
//				 vRecord[2],stof( vRecord[3]) ) );
//     }
//	
//	 static vector < clsCurrency> _loadDateFromFileTovector()
//	{
//		vector <clsCurrency> LoadedCurrency;
//
//		fstream fileCurrency;
//		string line;
//		fileCurrency.open("Currency.txt", ios::in);
//		if (fileCurrency.is_open() ) 
//		{
//			while ( getline(fileCurrency , line))
//			{ 
//				LoadedCurrency .push_back( _ConverttoRecord(line) );
//
//			}
//
//			fileCurrency.close();
//		}
//		return LoadedCurrency;
//	 }
//	static string _ConvertCurrencyObjectToLine(clsCurrency Currency, string Seperator = "#//#")
//	{
//		return 
//			Currency.Country() + Seperator
//			+ Currency.CurrencyName() + Seperator
//			+ Currency.CurrencyCode() + Seperator
//			+ to_string(Currency.Rate());
//	}
//	static void _saveCurrencydatatofile(vector <clsCurrency> vcurrency ) 
//	{
//
//		fstream myfile;
//		myfile.open("Currency.txt", ios::out, ios::app);
//		string line;
//		if (myfile.is_open() )
//		{
//			for (clsCurrency currency : vcurrency)
//			{
//				{
//					myfile << _ConvertCurrencyObjectToLine(currency) << endl;
//				}
//
//			}
//			myfile.close();
//
//	     }
//	}
//	 void _UpdateRate()
//	 {
//		 vector <clsCurrency> _vCurrenys;
//		 _vCurrenys   = _loadDateFromFileTovector();
//		 for(clsCurrency & currency : _vCurrenys)
//		 {
//			 if (currency.CurrencyCode() == _CurrencyCode)
//			 {
//				 currency = *this;
//		     }
//		 }
//		 _saveCurrencydatatofile(_vCurrenys);
//
//	 }
//	 static clsCurrency _getEMPTYobject()
//	 {
//		 return (clsCurrency(enMode::EmptyMode, "", "", "", 0));
//	   
//	 }
//public:
//	clsCurrency(enMode mode, string country,string currencyname, 
//		string currencycode, float rate)
//	{
//	this->	_Mode = mode;
//	this->_Rate = rate;
//	this->_CurrencyCode = currencycode;
//	this->_CurrencyName = currencyname;
//
//	}
//
//	bool EmptyModee() 
//	{
//		return(_Mode == enMode::EmptyMode);
//	}
//	string CurrencyName() 
//	{
//		return this-> _CurrencyName;
//	}
//	string CurrencyCode()
//	{
//		return this->_CurrencyCode;
//	}
//	string Country() 
//	{
//		return this->_Country;
//    }
//	float Rate() 
//	{
//		return this->_Rate;
//	}
//	void UpdateRate(float newRate) 
//	{
//		this->_Rate = newRate;
//		_UpdateRate();
//	}
//
//	static clsCurrency findbycode(string countrycode)
//	{
//
//		countrycode = ClsString::UpperAllString(countrycode);
//		fstream myfile;
//		myfile.open("Currency.txt", ios::out, ios::app);
//		string line;
//		if (myfile.is_open())
//		{
//			
//			while (getline ( myfile , line))
//			{
//				clsCurrency c = _ConverttoRecord(line);
//				if (c.CurrencyCode() == countrycode)
//				{
//					myfile.close();
//					return c;
//				}
//			}
//
//			}
//		return _getEMPTYobject();
//
//	}
//	static clsCurrency findbycountry(string country)
//	{
//
//
//		country = ClsString::UpperAllString(country);
//		fstream myfile;
//		myfile.open("Currency.txt", ios::out, ios::app);
//		string line;
//		if (myfile.is_open())
//		{
//
//			while (getline(myfile, line))
//			{
//				clsCurrency c = _ConverttoRecord(line);
//				if (c.Country() == country)
//				{
//					myfile.close();
//					return c;
//				}
//			}
//
//		}
//		return _getEMPTYobject();
//
//	}
//
//	static bool isCurrencyExiect(string currencycode)
//	{
//		clsCurrency c = c.findbycode(currencycode);
//		return(!c.EmptyModee() );
//	}
//	static vector<clsCurrency> getCurriencesList()
//	{
//
//		return _loadDateFromFileTovector();
//
//	}
//	
//
//
//
//
//};
//
