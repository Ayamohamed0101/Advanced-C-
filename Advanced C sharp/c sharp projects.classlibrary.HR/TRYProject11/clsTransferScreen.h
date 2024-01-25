//#pragma once
//#include<bits/stdc++.h>
//using namespace std ;
//#include"clsScreen.h"
//#include"clsBankClient.h"
//#include "Global.h"
//class clsTransferScreen : protected clsScreen
//{
//private:
//	string _PrepareLogInRecord(double ammount,clsBankClient client1,clsBankClient client2,
//		string username,string Seperator = "#//#")
//	{
//		string TransferLoginRecord = "";
//		TransferLoginRecord += ClsDate::GetSystemDateTimeString() + Seperator;
//		TransferLoginRecord += client1.get_AccountNumber() + Seperator;
//		TransferLoginRecord += client2.get_AccountNumber() + Seperator;
//		TransferLoginRecord += to_string(ammount) + Seperator;
//		TransferLoginRecord += to_string(client1.get_AccountBalance()) + Seperator;
//		TransferLoginRecord += to_string(client2.get_AccountBalance()  ) + Seperator;
//		TransferLoginRecord += username;
//
//		return TransferLoginRecord;
//	}
//
//
//public:
//	
//
//	static void transferFROMTo()
//	{
//		
//
//		string accountNUm1 = "";
//		cout << "Enter account num to Transfer From : " << endl;
//		accountNUm1= ClsInputValidate::ReadString();
//		while (!clsBankClient::IsClientExist(accountNUm1))
//		{
//			cout << " NOT EXICT , Enter  AGAIN  account num to Transfer From : " << endl;
//			accountNUm1 = ClsInputValidate::ReadString();
//		}
//		clsBankClient client1 = clsBankClient::Find(accountNUm1);
//		client1.PrintclientCardTransfer(); 
//		cout << endl;
//		cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
//
//		///////////////////////////////
//
//		string accountNUm2 = "";
//		cout << "Enter account num to Transfer TO: " << endl;
//		accountNUm2= ClsInputValidate::ReadString();
//		while (!clsBankClient::IsClientExist(accountNUm2))
//		{
//			cout << " NOT EXICT , Enter  AGAIN  account num to Transfer From : " << endl;
//			accountNUm2= ClsInputValidate::ReadString();
//		}
//	 	clsBankClient client2 = clsBankClient::Find(accountNUm2);
//	 	client2.PrintclientCardTransfer();
//		cout << endl;
//
//		cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
//
//		//////////////////////////////
//
//		double Amount = 0;
//		cout << "\nPlease enter transfer amount? ";
//		Amount = ClsInputValidate:: ReadDblNumber();
//		while(Amount > client1.AccountBalance)
//		{
//			cout << "amout exceeds than balaance enter again ";
//			Amount  = ClsInputValidate::ReadDblNumber();
//
//		}
//		cout << endl;
//		cout << "~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
//		cout << "\nAre you sure you want to perform this transfer? ";
//		char Answer = 'n';
//		cin >> Answer;
//
//		if (Answer == 'Y' || Answer == 'y')
//		{
//			client1.Withdraw(Amount);
//			client2.Deposit(Amount);
//			cout << "\nAmount Deposited Successfully.\n";
//
//		}
//		else
//		{
//			cout << "\nOperation was cancelled.\n";
//		}
//
//
// 		string name = CurrentUser.get_FullName();
// 		clsBankClient::RegisterTransferLogIn(Amount, client1, client2, name);
//
//
//		client1.PrintclientCardTransfer();
//		cout << endl <<"~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" << endl;
//
//		client2.PrintclientCardTransfer();
//	
//	}
//	
//
//};
#pragma once
#include <iostream>
#include "clsScreen.h"
#include "clsPerson.h"
#include "clsBankClient.h"
#include "clsInputValidate.h"
#include"Global.h"
class clsTransferScreen :protected clsScreen
{

private:
	static void _PrintClient(clsBankClient Client)
	{
		cout << "\nClient Card:";
		cout << "\n___________________\n";
		cout << "\nFull Name   : " << Client.get_FullName();
		cout << "\nAcc. Number : " << Client.get_AccountNumber();
		cout << "\nBalance     : " << Client.AccountBalance;
		cout << "\n___________________\n";

	}

	static string _ReadAccountNumber()
	{
		string AccountNumber;
		cout << "\nPlease Enter Account Number to Transfer From: ";
		AccountNumber = ClsInputValidate::ReadString();
		while (!clsBankClient::IsClientExist(AccountNumber))
		{
			cout << "\nAccount number is not found, choose another one: ";
			AccountNumber = ClsInputValidate::ReadString();
		}
		return AccountNumber;
	}

	static float ReadAmount(clsBankClient SourceClient)
	{
		float Amount;

		cout << "\nEnter Transfer Amount? ";

		Amount = ClsInputValidate::ReadfloatNumber();

		while (Amount > SourceClient.AccountBalance)
		{
			cout << "\nAmount Exceeds the available Balance, Enter another Amount ? ";
			Amount = ClsInputValidate::ReadDblNumber();
		}
		return Amount;
	}

public:

	static void ShowTransferScreen()
	{

		_DrawScreenHeader("\tTransfer Screen", "");

		clsBankClient SourceClient = clsBankClient::Find(_ReadAccountNumber());

		_PrintClient(SourceClient);

		clsBankClient DestinationClient = clsBankClient::Find(_ReadAccountNumber());

		_PrintClient(DestinationClient);

		float Amount = ReadAmount(SourceClient);


		cout << "\nAre you sure you want to perform this operation? y/n? ";
		char Answer = 'n';
		cin >> Answer;
		if (Answer == 'Y' || Answer == 'y')
		{
			if (SourceClient.Transfer(Amount, DestinationClient , CurrentUser. UserName ))
			{
				
				cout << "\nTransfer done successfully\n";
			}
			else
			{
				
				cout << "\nTransfer Faild \n";
			}
		}

		_PrintClient(SourceClient);
		_PrintClient(DestinationClient);


	}

};

