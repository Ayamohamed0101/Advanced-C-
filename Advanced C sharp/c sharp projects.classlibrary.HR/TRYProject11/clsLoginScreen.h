
#pragma once

#include <iostream>
#include "clsScreen.h"
#include "clsUser.h"
#include <iomanip>
#include "clsMainScreen.h"
#include "Global.h"

class clsLoginScreen :protected clsScreen
{

private:

    static  bool _Login()
    {
        bool LoginFaild = false;

        string Username, Password;
        short LoginFaildCount = 0;
        do
        {

            if (LoginFaild)
            {
                LoginFaildCount++;
                cout << "\nInvlaid Username/Password!\n\n";
                cout << "\nYou have " << (3 - LoginFaildCount)
                    << " Trial(s) to login.\n\n";
            }
            if (LoginFaildCount == 3)
            {
                cout << "\nYour are Locked after 3 faild trails \n\n";
                return false;
            }



            cout << "Enter Username? ";
            cin >> Username;

            cout << "Enter Password? ";
            cin >> Password;

            CurrentUser = clsUser::Find(Username, Password);

            LoginFaild = CurrentUser.IsEmpty();

        } while (LoginFaild);

        CurrentUser.RegisterLogIn();
       clsMainScreen::ShowMainMenue();
       return true;
    }


    
public:


    static bool ShowLoginScreen()
    {
        system("cls");
        _DrawScreenHeader("\t  Login Screen", "");
       return _Login();

    }

};
