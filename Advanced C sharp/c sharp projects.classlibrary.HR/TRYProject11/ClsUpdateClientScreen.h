#pragma once
using namespace std;
#include "clsScreen.h"
#include "clsInputValidate.h"
#include<bits/stdc++.h>
#include "clsBankClient.h"
class ClsUpdateClientScreen : protected clsScreen
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
  static  void UpdateClient() {
      if (!CheckAccessRights(clsUser::enPermissions::pUpdateClients))
      {
          return;// this will exit the function and it will not continue
      }

      _DrawScreenHeader("\t  Updating Client Screen", "");

        string AccountNumber = "";
        cout << "\nPlease Enter client Account Number: ";
        AccountNumber = ClsInputValidate::ReadString();

        while (!clsBankClient::IsClientExist(AccountNumber)) {
            cout << "\nAccount number is not found, choose another one: ";
            AccountNumber = ClsInputValidate::ReadString();
        }

        clsBankClient Client1 = clsBankClient::Find(AccountNumber);
        Client1.Print();

        cout << "\n\nUpdate Client Info:";
        cout << "\n____________________\n";
        ReadClientInfo(Client1);

        clsBankClient::enSaveResults SaveResult = Client1.save();

        switch (SaveResult)
        {
        case clsBankClient::svFailedEmptyObject:
            cout << "\nError account was not saved because it's Empty";
            break;
        case clsBankClient::svSucceeded:
            cout << "\nAccount Updated Successfully :-)\n";
            Client1.Print();
            break;
        default:
            break;
        }
    }


};

