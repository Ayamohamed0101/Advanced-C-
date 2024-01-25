#pragma once
#include<iostream>
#include"clsPerson.h"
#include"clsString.h"
#include <vector>
#include <string>
#include <fstream>
#include"clsMainScreen.h"
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
	string static _PrepareLogInRecord(double ammount, clsBankClient client1, clsBankClient client2,
		string username, string Seperator = "#//#")
	{
		string TransferLoginRecord = "";
		TransferLoginRecord += ClsDate::GetSystemDateTimeString() + Seperator;
		TransferLoginRecord += client1.get_AccountNumber() + Seperator;
		TransferLoginRecord += client2.get_AccountNumber() + Seperator;
		TransferLoginRecord += to_string(ammount) + Seperator;
		TransferLoginRecord += to_string(client1.get_AccountBalance()) + Seperator;
		TransferLoginRecord += to_string(client2.get_AccountBalance()) + Seperator;
		TransferLoginRecord += username;

		return TransferLoginRecord;
	}
	struct  stTrnsferLogRecord;

	static  stTrnsferLogRecord _ConvertTransferLogLineToRecord(string Line, string Seperator = "#//#")
	{
		stTrnsferLogRecord TrnsferLogRecord;

		vector <string> vTrnsferLogRecordLine = ClsString::Split(Line, Seperator);
		TrnsferLogRecord.DateTime = vTrnsferLogRecordLine[0];
		TrnsferLogRecord.SourceAccountNumber = vTrnsferLogRecordLine[1];
		TrnsferLogRecord.DestinationAccountNumber = vTrnsferLogRecordLine[2];
		TrnsferLogRecord.Amount = stod(vTrnsferLogRecordLine[3]);
		TrnsferLogRecord.srcBalanceAfter = stod(vTrnsferLogRecordLine[4]);
		TrnsferLogRecord.destBalanceAfter = stod(vTrnsferLogRecordLine[5]);
		TrnsferLogRecord.UserName = vTrnsferLogRecordLine[6];

		return TrnsferLogRecord;

	}



	//private client functions
	static clsBankClient _ConvertLineToClientObject(string Line, string Seperator = "#//#")
	{
		vector<string> vClientData;

		vClientData = ClsString::Split(Line, Seperator );

	return clsBankClient(enMode::UpdateMode, vClientData[0], vClientData[1]
	, vClientData[2], vClientData[3], vClientData[4], vClientData[5], stod(vClientData[6]));
	}

	static string _ConvertClientObjecttoLine(clsBankClient Client, string Seperator = "#//#") 
	{
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

	static vector<clsBankClient> _LoadClientDataFromFile() 
	{
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

	void _Update() 
	{
		vector<clsBankClient>_vClients;
		_vClients = _LoadClientDataFromFile();

		for ( clsBankClient & C : _vClients) 
		{
			if (C.get_AccountNumber () == get_AccountNumber()) 
			{
				C = *this;///////
				break;
			}
		}
		_SaveClientsDataToFile(_vClients);
	}
	void  _AddDataLineToFile(string stDataLine)
	{
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
	struct stTrnsferLogRecord
	{
		string DateTime;
		string SourceAccountNumber;
		string DestinationAccountNumber;
		float Amount;
		float srcBalanceAfter;
		float destBalanceAfter;
		string UserName;

	};

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
		cout << "\nFullName    :" << this->get_FullName();
		cout << "\nEmail       :" << this->get_Email();
		cout << "\nPhone       :" << this->get_Phone();
		cout << "\nAcc. Number :" << this->_AccountNumber;
		cout << "\nPassword    :" << this->_PinCode;
		cout << "\nBalance     :" << this->_AccountBalance;
		cout << "\n-------------------";
	}
		void PrintclientCardTransfer() {
		cout << "\nClient Card:";
		cout << "\n-------------------";
		cout << "\nFullName    :" << this->get_FullName();
		cout << "\nAcc number  :" << this->AccountNumber;

		cout << "\n Account balance  :" << this->AccountBalance;
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
		if (MyFile.is_open()) 
		{

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
				// if true 
				// mean the obj is fill with data
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

	static bool IsClientExist( string AccountNumber ) 
	{

		clsBankClient Client = clsBankClient::Find(AccountNumber);
		// return client which is fill 
		// or empty 
		// then check 
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

		// save to file first ,then make empty object 
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

	static void RegisterTransferLogIn(double ammount, clsBankClient client1, clsBankClient client2,
		string username, string Seperator = "#//#")
	{

		string  stDataLine = _PrepareLogInRecord(ammount,client1,client2,username);

		fstream MyFile;
		MyFile.open("LoginRegister.txt", ios::out | ios::app);

		if (MyFile.is_open())
		{

			MyFile << stDataLine << endl;

			MyFile.close();
		}

	}


///////////////////

	string _PrepareTransferLogRecord(float Amount, clsBankClient DestinationClient,
		string UserName, string Seperator = "#//#")
	{
		string TransferLogRecord = "";
		TransferLogRecord += ClsDate::GetSystemDateTimeString() + Seperator;
		TransferLogRecord += get_AccountNumber() + Seperator;
		TransferLogRecord += DestinationClient.get_AccountNumber() + Seperator;
		TransferLogRecord += to_string(Amount) + Seperator;
		TransferLogRecord += to_string(AccountBalance) + Seperator;
		TransferLogRecord += to_string(DestinationClient.AccountBalance) + Seperator;
		TransferLogRecord += UserName;
		return TransferLogRecord;
	}

	void _RegisterTransferLog(float Amount, clsBankClient DestinationClient, string UserName)
	{

		string stDataLine = _PrepareTransferLogRecord(Amount, DestinationClient, UserName);

		fstream MyFile;
		MyFile.open("TransferLog.txt", ios::out | ios::app);

		if (MyFile.is_open())
		{

			MyFile << stDataLine << endl;

			MyFile.close();
		}

	}

	bool Transfer(float Amount, clsBankClient& DestinationClient, string UserName)
	{
		if (Amount > AccountBalance)
		{
			return false;
		}
		Withdraw(Amount);


		DestinationClient.Deposit(Amount);
		_RegisterTransferLog(Amount, DestinationClient, UserName);

		return true;
	}


	static  vector <stTrnsferLogRecord> GetTransfersLogList()
	{
		vector <stTrnsferLogRecord> vTransferLogRecord;

		fstream MyFile;
		MyFile.open("TransfersLog.txt", ios::in);//read Mode

		if (MyFile.is_open())
		{

			string Line;

			stTrnsferLogRecord TransferRecord;

			while (getline(MyFile, Line))
			{

				TransferRecord = _ConvertTransferLogLineToRecord(Line);

				vTransferLogRecord.push_back(TransferRecord);

			}

			MyFile.close();

		}

		return vTransferLogRecord;

	}


};
