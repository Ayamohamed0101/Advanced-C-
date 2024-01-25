#pragma once
using namespace std;
#include "clsScreen.h"
#include "clsInputValidate.h"
#include<bits/stdc++.h>
#include "clsBankClient.h"
class clsDeleteClientScreen:protected clsScreen
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


public:

   static void ShowDeleteClientScreen (){
       if (!CheckAccessRights(clsUser::enPermissions::pDeleteClient))
       {
           return;// this will exit the function and it will not continue
       }

       _DrawScreenHeader("\tDeleting Client Screen ", "");
            string AccountNumber = "";
            cout << "\nPlease Enter client Account Number: ";
            AccountNumber = ClsInputValidate::ReadString();
        
            while (!clsBankClient::IsClientExist(AccountNumber))
            {
                cout << "\nAccount number is already exist, choose another one: ";
                AccountNumber = ClsInputValidate::ReadString();
            }
            clsBankClient client1 = clsBankClient::Find(AccountNumber);
            client1.Print();
          
            cout << "\nAre you sure you want to delete this client y/n? ";
            char Answer = 'n';
            cin >> Answer;
            if (Answer == 'y' || Answer == 'Y')
            {
                if (client1.Delet()) {
                    cout << "\nClient Deleted Susseccfully :-)\n";
                    client1.Print();
                }
                else 
                {
                    cout << "\nError Client Was not Deleted\n";
                }
            }
        
        }
        


};

