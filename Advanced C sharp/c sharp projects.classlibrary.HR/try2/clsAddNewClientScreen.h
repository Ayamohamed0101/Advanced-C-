
#pragma once
using namespace std;
#include "clsScreen.h"
#include "clsInputValidate.h"
#include"clsBankClient.h"
#include<bits/stdc++.h>
class clsAddNewClientScreen:protected clsScreen 
{

private:
    static void _PrintClient(clsBankClient Client)
    {
        cout << "\nClient Card:";
        cout << "\n___________________";
        cout << "\nFirstName   : " << Client.FirstName;
        cout << "\nLastName    : " << Client.LastName;
        cout << "\nFull Name   : " << Client.get_FullName();
        cout << "\nEmail       : " << Client.Email;
        cout << "\nPhone       : " << Client.Phone;
        cout << "\nAcc. Number : " << Client.get_AccountNumber();
        cout << "\nPassword    : " << Client.PinCode;
        cout << "\nBalance     : " << Client.AccountBalance;
        cout << "\n___________________\n";

    }

    static void ReadClientInfo(clsBankClient& Client) {
        cout << "\nEnter FirstName: ";

        Client.FirstName = ClsInputValidate::ReadString();
        cout << "\nEnter LastName: ";
        Client.LastName = ClsInputValidate::ReadString();

        cout << "\nEnter Email: ";
        Client.Email = ClsInputValidate::ReadString();

        cout << "\nEnter Phone: ";
        Client.Phone = ClsInputValidate::ReadString();

        cout << "\nEnter PinCode: ";
        Client.PinCode = ClsInputValidate::ReadString();

        cout << "\nEnter AccountBalance: ";
        Client.AccountBalance = ClsInputValidate::ReadDblNumber();

    }

public:
    static void AddNewClient() {

        _DrawScreenHeader("\t  Add New Client Screen", "");
        string AccountNumber = "";
        cout << "\nPlease Enter client Account Number: ";
        AccountNumber = ClsInputValidate::ReadString();

        while (clsBankClient::IsClientExist(AccountNumber))
        {
            cout << "\nAccount number is already exist, choose another one: ";
            AccountNumber = ClsInputValidate::ReadString();
        }
        clsBankClient addclient = clsBankClient::GetAddClient(AccountNumber);
        // repare mode then fill object with data

        cout << "\n\adding new Client Info:";
        cout << "\n____________________\n";
        ReadClientInfo(addclient);

        clsBankClient::enSaveResults SaveResult;
        SaveResult = addclient.save();
        switch (SaveResult)
        {
        case clsBankClient::svFailedEmptyObject:
            cout << "\nError account was not saved because it's Empty";
            break;
        case clsBankClient::svSucceeded:
            cout << "\nAccount added Successfully :-)\n";
            _PrintClient (addclient);
            break;
        case clsBankClient::svAccountnumExiect:
            cout << "\nError account was not saved because account number is used!\n";
            break;
        default:
            break;
        }
    }



};

