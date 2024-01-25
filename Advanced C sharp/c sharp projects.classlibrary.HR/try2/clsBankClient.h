#pragma once
#include<iostream>
#include"clsPerson.h"
#include"clsString.h"
#include <vector>
#include <string>
#include <fstream>
using namespace std;

class clsBankClient :public clsPerson
{
private:
	enum enMode { EmptyMode = 0, UpdateMode = 1, AddNewClient=2};


	//variables
	enMode _Mode;
	string _AccountNumber;
	string _PinCode;
	float _AccountBalance;
	bool _markFORdelete=false;


	//private client functions
	static clsBankClient _ConvertLineToClientObject(string Line, string Seperator = "#//#") {
		vector<string> vClientData;

		vClientData = ClsString::Split(Line, Seperator);

		return clsBankClient(enMode::UpdateMode, vClientData[0], vClientData[1]
			, vClientData[2], vClientData[3], vClientData[4], vClientData[5], stod(vClientData[6]));
	}

	static string _ConvertClientObjecttoLine(clsBankClient Client, string Seperator = "#//#") {
		return Client.get_FirstName()
			+ Seperator + Client.get_LastName()
			+ Seperator + Client.get_Email()
			+ Seperator + Client.get_Phone()
			+ Seperator + Client._AccountNumber
			+ Seperator + Client._PinCode
			+ Seperator + to_string(Client._AccountBalance);
	}

	static clsBankClient _GetEmptyClientObject() 
	{
		return clsBankClient(enMode::EmptyMode, "", "", "", "", "", "", 0);
	}

	static vector<clsBankClient>_LoadClientDataFromFile() {
		vector<clsBankClient> vClients;
		fstream MyFile;
		MyFile.open("Clients.txt", ios::in);

		if (MyFile.is_open()) {
			string Line;
			while (getline(MyFile, Line))
			{
				clsBankClient Client = _ConvertLineToClientObject(Line);
				vClients.push_back(Client);
			}
			MyFile.close();
		}
		return vClients;
	}

	static void _SaveClientsDataToFile(vector<clsBankClient>& vClients) {
		fstream MyFile;
		MyFile.open("Clients.txt", ios::out);

		string DataLine;

		if (MyFile.is_open()) {
			for (clsBankClient& C : vClients) 
			{
				if (C._markFORdelete == false) 
				{
					DataLine = _ConvertClientObjecttoLine(C);
					MyFile << DataLine << endl;
				}
				
			}
		}
		MyFile.close();
	}

	void _Update() {
		vector<clsBankClient>_vClients;
		_vClients = _LoadClientDataFromFile();

		for (clsBankClient& C : _vClients) 
		{
			if (C.get_AccountNumber () == get_AccountNumber()) 
			{
				C = *this;///////
				break;
			}
		}
		_SaveClientsDataToFile(_vClients);
	}
	void  _AddDataLineToFile(string stDataLine) {
		fstream MyFile;
		MyFile.open("Clients.txt", ios::out | ios::app);

		if (MyFile.is_open()) {
			MyFile << stDataLine << endl;
			MyFile.close();
		}
	}

	void _Addclient() 
	{
		_AddDataLineToFile(_ConvertClientObjecttoLine(*this));

	}
public:

	//constructors
	clsBankClient(enMode Mode, string FirstName, string LastName, string Email, string Phone
		, string AccountNumber, string PinCode, float AccountBalance)
		:clsPerson(FirstName, LastName, Email, Phone) {

		this->_Mode = Mode;
		this->_AccountNumber = AccountNumber;
		this->_PinCode = PinCode;
		this->_AccountBalance = AccountBalance;
	}

	//setters
	void set_Mode(enMode Mode) { this->_Mode = Mode; }
	void set_AccountNumber(string AccountNumber) { this->_AccountNumber = AccountNumber; }
	void set_PinCode(string PinCode) { this->_PinCode = PinCode; }
	void set_AccountBalance(float AccountBalance) { this->_AccountBalance = AccountBalance; }

	//getters
	enMode get_Mode() { return this->_Mode; }
	string get_AccountNumber() { return this->_AccountNumber; }
	string get_PinCode() { return this->_PinCode; }
	float get_AccountBalance() { return this->_AccountBalance; }

	//declspec
	__declspec(property(get = get_Mode, put = set_Mode))enMode Mode;
	__declspec(property(get = get_AccountNumber, put = set_AccountNumber))string AccountNumber;
	__declspec(property(get = get_PinCode, put = set_PinCode))string PinCode;
	__declspec(property(get = get_AccountBalance, put = set_AccountBalance))float AccountBalance;

	//public client functions
	bool IsEmpty() { return (this->_Mode == enMode::EmptyMode); }

	void Print() {
		cout << "\nClient Card:";
		cout << "\n-------------------";
		cout << "\nFirstName   :" << this->get_FirstName();
		cout << "\nLastName    :" << this->get_LastName();
		cout << "\nFullName    :" << this->get_FullName();;
		cout << "\nEmail       :" << this->get_Email();
		cout << "\nPhone       :" << this->get_Phone();
		cout << "\nAcc. Number :" << this->_AccountNumber;
		cout << "\nPassword    :" << this->_PinCode;
		cout << "\nBalance     :" << this->_AccountBalance;
		cout << "\n-------------------";
	}

static clsBankClient Find(string AccountNumber) 
{
		fstream MyFile;
		MyFile.open("Clients.txt", ios::in);
		if (MyFile.is_open()) 
		{
			string Line;
			while (getline(MyFile, Line))
			{
			    clsBankClient Client = _ConvertLineToClientObject(Line);
				if (Client._AccountNumber == AccountNumber) 
				{
					MyFile.close();
					return Client;
				}
			}
			return _GetEmptyClientObject();
		}
}
static clsBankClient Find(string AccountNumber, string PinCode) {
		fstream MyFile;
		MyFile.open("Clients.txt", ios::in);
		if (MyFile.is_open()) {

			string Line;

			while (getline(MyFile, Line))
			{
				clsBankClient Client = _ConvertLineToClientObject(Line);
				if (Client._AccountNumber == AccountNumber && Client._PinCode == PinCode) {
					MyFile.close();
					return Client;
				}

			}
			return _GetEmptyClientObject();
		}
	}

	enum enSaveResults { svFailedEmptyObject = 0, svSucceeded = 1 ,svAccountnumExiect=2};

	enSaveResults save() {
		switch (_Mode)
	    {
		case clsBankClient::EmptyMode:
			return enSaveResults::svFailedEmptyObject;
			break;
		case clsBankClient::UpdateMode:
			_Update();
			return enSaveResults::svSucceeded;
			break;
		case clsBankClient::AddNewClient:
			if (IsClientExist(AccountNumber))
			{
				return enSaveResults::svFailedEmptyObject;
				break;
			}
			else
			{
				_Addclient();
				_Mode = enMode::UpdateMode;
				return enSaveResults::svSucceeded;

			}
			break;
		default:
			break;
		}
	}

	static bool IsClientExist(string AccountNumber) {

		clsBankClient Client = clsBankClient::Find(AccountNumber);
		return (!Client.IsEmpty());
	}
	static clsBankClient GetAddClient(string accountnum) 
	{
		return clsBankClient (enMode::AddNewClient,
			"", "", "", "", accountnum,"",0 );
	}

	bool Delet() 
	{
		vector <clsBankClient> _vectorClient = _LoadClientDataFromFile();
		for (clsBankClient& c : _vectorClient)
		{
			if (c.AccountNumber == _AccountNumber)
			{
				c._markFORdelete = true;
				break;
			}
		}


		_SaveClientsDataToFile(_vectorClient);
		*this = _GetEmptyClientObject();
		return true;



	} 
	static vector <clsBankClient> GetClientList() 
	{
		return _LoadClientDataFromFile();
	}
	static double GetTotalBalances() 
	{
		vector<clsBankClient>vClients = GetClientList();
		double TotalBalances = 0;

		for (clsBankClient& C : vClients) {
			TotalBalances += C.AccountBalance;
		}
		return TotalBalances;
	}


	void Deposit(double Amount)
	{
		_AccountBalance +=  Amount;
		save();
	}

	bool Withdraw(double Amount)
	{
		if (Amount > _AccountBalance)
		{
			return false;
		}
		else
		{
			_AccountBalance -= Amount;
			save();
			return true;
		}

	}


};
