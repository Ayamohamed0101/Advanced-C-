#include <iostream>
#include "clsLoginScreen.h"
#include "clsCurrency.h"
#include "clsCurrencyExchangeMainScreen.h"

//using namespace std;
//#include<bits/stdc++.h>
//using namespace std;
//static void ReadClientInfo(clsBankClient& Client) {
//    cout << "\nEnter FirstName: ";
//
//    Client.FirstName = ClsInputValidate::ReadString();
//    cout << "\nEnter LastName: ";
//    Client.LastName = ClsInputValidate::ReadString();
//
//    cout << "\nEnter Email: ";
//    Client.Email = ClsInputValidate::ReadString();
//
//    cout << "\nEnter Phone: ";
//    Client.Phone = ClsInputValidate::ReadString();
//
//    cout << "\nEnter PinCode: ";
//    Client.PinCode = ClsInputValidate::ReadString();
//
//    cout << "\nEnter AccountBalance: ";
//    Client.AccountBalance = ClsInputValidate::ReadDblNumber();
//
//}
//void PrintClientRecordLine(clsBankClient Client)
//{
//
//    cout << "| " << setw(15) << left << Client.get_AccountNumber () ;
//    cout << "| " << setw(20) << left << Client.get_FullName();
//    cout << "| " << setw(15) << left << Client.Phone;
//    cout << "| " << setw(20) << left << Client.Email;
//    cout << "| " << setw(10) << left << Client.PinCode;
//    cout << "| " << setw(15) << left << Client.AccountBalance;
//
//}
//void ShowClientsList()
//{
//
//    vector <clsBankClient> vClients = clsBankClient::GetClientList();
//
//    cout << "\n\t\t\t\t\tClient List (" << vClients.size() << ") Client(s).";
//    cout << "\n_______________________________________________________";
//    cout << "_________________________________________\n" << endl;
//
//    cout << "| " << left << setw(15) << "Accout Number";
//    cout << "| " << left << setw(20) << "Client Name";
//    cout << "| " << left << setw(12) << "Phone";
//    cout << "| " << left << setw(20) << "Email";
//    cout << "| " << left << setw(10) << "Pin Code";
//    cout << "| " << left << setw(12) << "Balance";
//    cout << "\n_______________________________________________________";
//    cout << "_________________________________________\n" << endl;
//
//    if (vClients.size() == 0)
//        cout << "\t\t\t\tNo Clients Available In the System!";
//    else
//
//        for (clsBankClient &Client : vClients)
//        {
//
//            PrintClientRecordLine(Client);
//            cout << endl;
//        }
//
//    cout << "\n_______________________________________________________";
//    cout << "_________________________________________\n" << endl;
//
//}
//
//void PrintClientRecordBalanceLine(clsBankClient Client)
//{
//
//    cout << "| " << setw(15) << left << Client.get_AccountNumber();
//    cout << "| " << setw(40) << left << Client.get_FullName();
//    cout << "| " << setw(12) << left << Client.AccountBalance;
//
//}
//void ShowTotalBalances()
//{
//
//    vector <clsBankClient> vClients = clsBankClient::GetClientList();
//
//    cout << "\n\t\t\t\t\tBalances List (" << vClients.size() << ") Client(s).";
//    cout << "\n_______________________________________________________";
//    cout << "_________________________________________\n" << endl;
//
//    cout << "| " << left << setw(15) << "Accout Number";
//    cout << "| " << left << setw(40) << "Client Name";
//    cout << "| " << left << setw(12) << "Balance";
//    cout << "\n_______________________________________________________";
//    cout << "_________________________________________\n" << endl;
//
//    double TotalBalances = clsBankClient::GetTotalBalances();
//
//    if (vClients.size() == 0)
//        cout << "\t\t\t\tNo Clients Available In the System!";
//    else
//
//        for (clsBankClient Client : vClients)
//        {
//            PrintClientRecordBalanceLine(Client);
//            cout << endl;
//        }
//
//    cout << "\n_______________________________________________________";
//    cout << "_________________________________________\n" << endl;
//    cout << "\t\t\t\t\t   Total Balances = " << TotalBalances << endl;
//    cout << "\t\t\t\t\t   ( " << ClsUtil :: NumberToText(TotalBalances) << ")";
//}
int main() {
    clsMainScreen::ShowMainMenue();

    /*  while ( true )
      {
          clsLoginScreen ::ShowLoginScreen();

      }*/

      /*  while (true)
        {
            if (!clsLoginScreen::ShowLoginScreen())
            {
                break;

            }
        }*/

        //  clsManageUsersScreen::ShowManageUsersMenue();
      // clsMainScreen::ShowMainMenue();

}