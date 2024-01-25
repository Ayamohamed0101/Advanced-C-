#pragma once
#include<bits/stdc++.h>
using namespace std;

class clsPerson {
private:
	string _FirstName;
	string _LastName;
	string _Email;
	string _Phone;

public:
	clsPerson(string firstname, string lastname, string phone, string email)
	{
		this->_FirstName = firstname;
		this->_LastName = lastname;
		this->_Email = email;
		this->_Phone = phone;
	}
	void set_firstname(string first) {
		this->_FirstName = first;
	}
	void set_LastName(string LastName) { this->_LastName = LastName; }
	void set_FirstName(string FirstName) { this->_FirstName = FirstName; }

	void set_Email(string Email) { this->_Email = Email; }
	void set_Phone(string Phone) { this->_Phone = Phone; }
	string get_FirstName() { return this->_FirstName; }
	string get_LastName() { return this->_LastName; }
	string get_Email() { return this->_Email; }
	string get_Phone() { return  this->_Phone; }
	string get_FullName() { return  this->_FirstName + " " + this->_LastName; }

	//declspec
	__declspec(property(get = get_FirstName, put = set_FirstName)) string FirstName;
	__declspec(property(get = get_LastName, put = set_LastName)) string LastName;
	__declspec(property(get = get_Email, put = set_Email)) string Email;
	__declspec(property(get = get_Phone, put = set_Phone)) string Phone;

	void Print()
	{
		cout << "\nInfo:";
		cout << "\n___________________";
		cout << "\nFirstName: " << this->_FirstName;
		cout << "\nLastName : " << this->_LastName;
		cout << "\nFull Name: " << this->get_FullName();
		cout << "\nEmail    : " << this->_Email;
		cout << "\nPhone    : " << this->_Phone;
		cout << "\n___________________\n";
	}








};