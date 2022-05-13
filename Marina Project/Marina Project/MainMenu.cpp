#include <string>
#include <iostream>
#include <fstream>
#include <cstdio>
#include <iomanip>
#include <istream>
#include <stdlib.h>
#include <Windows.h>
#include "MainMenu.h"
#include "Boat.h"
#include"List.h"


using namespace std;
//Declaration of global variables
List boatList;
int marinaSpace = NULL;
bool populateBoatlist = false;

//Main method displays the Menu with choices
void Menu::DisplayMenu()
{
	int menuChoice;		
	//populate list from text file
	
	if (!populateBoatlist) {
		//while statement used to ensure the boatlist is only populated from the text file once
		ifstream myfile;
		myfile.open("BoatList.txt", ios::in);
		if (myfile.fail()) {
			cout << "No previous records found loading Menu";
			Sleep(2000);
			system("CLS");

			
		}
		while (true) {
			//Loops throught the file until eof creating boats for the text within the file
			string ownername, boatname, boattype;
			int boatlength;
			Boat* b = new Boat;
			if (myfile >> ownername >> boatlength >> boatname >> boattype) {
				b->setOwnerName(ownername);
				b->setBoatLength(boatlength);
				b->setBoatName(boatname);
				b->setBoatType(boattype);
				boatList.InsertNewNode(*b);
			}
			else {
				break;
			}
			
		}
		populateBoatlist = true;
		myfile.close();
	}

	
	
	//Assignment of the marina space 
	marinaSpace = 150;
	int totalBoatLength = 0;
	totalBoatLength = boatList.BoatSpace(totalBoatLength);
	marinaSpace = marinaSpace - totalBoatLength;

	//Display of menu choices
	cout << "Welcome to the Marina Booking System" << endl;
	cout << "---------------------------------------------" << endl;
	cout << "Please select an option from the list below" << endl;
	cout << "1: Record a New Booking." << endl;
	cout << "2: Delete a Booking." << endl;
	cout << "3: Display all Current Records and Marina Space." << endl;
	cout << "4: Exit the Booking System." << endl;

	cin >> menuChoice;
	//Checks user input 
	//Record new booking
	if (menuChoice == 1) {
		system("CLS");
		NewBooking();
	}
	//Deletion
	else if (menuChoice == 2) {
		system("CLS");
		DeleteBooking();
 	}
	//Display of all booking
	else if (menuChoice == 3) {
		system("CLS");
		DisplayBooking();
	}
	//Exit
	else if (menuChoice == 4) {
		cout << "Thank you for using the Marina Booking System" << endl;
		//write the current bookings to a file for storage
		boatList.Save();

		exit(0);
	}
	//Used if user entry incorrect
	else
	{
		cout << "Incorrect Entry Please Reselect" << endl;
	}
}

//Method for creation of a new booking
void Menu::NewBooking() {
	//assignment of local variables
	string ownerName, boatName, boatType, boatInput; // assignment of variables
	int boatLength, months, bookingPrice, bookConfirm, typeConfirm;
	double boatDepth;	
	bool finished = false;

	
	Boat* boat = new Boat; //creation of a new boat 

	//Input of boat length 
	cout << "Please enter the Boat Length" << endl;
	cin >> boatLength;
	while (cin.fail()) {
		cout << "Incorrect entry enter boat length as a number" << endl;
		cin.clear();
		cin.ignore();
		cin >> boatLength;
	}

	//checking there is space for the boat in the marina
	if (boatLength <= marinaSpace && boatLength <= 15) {
		boat->setBoatLength(boatLength);
	}
	else {
		//If it doesnt fit takes the user back to the menu
		cout << "Your boat will not fit in the marina sorry" << endl;
		cout << "Returning to Menu" << endl;
		Sleep(3000);
		system("CLS");
		DisplayMenu();
	}

	//input of boat draft and checking it fits in the marina
	cout << "Please enter the Boat draft in metres" << endl;
	cin >> boatDepth;

	while (cin.fail()) { //checking for an integer input
		cout << "Incorrect entry enter boat draft as a number" << endl;
		cin.clear();
		cin.ignore();
		cin >> boatDepth;
	}

	if (boatDepth >= 5) {
		//If it doesnt fit takes the user back to the menu
		cout << "Your boat will not fit in the marina sorry" << endl;
		cout << "Returning to Menu" << endl;
		Sleep(3000);
		system("CLS");
		DisplayMenu();
	}

	cout << "Please enter the duration of the stay in months" << endl;
	cin >> months;

	while (cin.fail()) { //checking for an integer input
		cout << "Incorrect entry enter length of stay as a number" << endl;
		cin.clear();
		cin.ignore();
		cin >> months;
	}
	//calculation of a booking price and checking if the user would like to continue the booking
	bookingPrice = boatLength* months * 10;
	cout << "Price of booking " << bookingPrice << "pounds" << endl;
	cout << "would you like to continue with the booking: 1 = yes or 2 = no)" << endl;

	//checking of user input to confirm the booking use of a loop to reiterate if incorrect entry
	do {

		cin >> bookConfirm;

		switch (bookConfirm) {

		case 1:
			cout << "Enter your details for the booking" << endl;
			finished = true;
			break;
		case 2:
			cout << "Booking terminated returning to Main Menu" << endl;
			finished = true;
			Sleep(2000);
			system("CLS");
			DisplayMenu();
		default:
			cin.clear();
			cin.ignore();
			system("CLS");
			cout << "invalid input please input 1 for yes or 2 for no" << endl;

		}
	} while (!finished);

	finished = false;//resets bool to use in next switch
    
	//setting of boats variables from user input
	cout << "Please enter the Boat Owners Name" << endl;
	cin.ignore(); //clear the enter input
	getline(cin, ownerName);
	boat->setOwnerName(ownerName);

	cout << "Please enter the Boats Name" << endl;
	getline(cin, boatName);
	boat->setBoatName(boatName);

	//switch to assign boat type
	
	do {
		cout << "Please enter the Boat Type 1) Motor, 2) Sailing or 3) Narrow)" << endl;
		
		cin >> typeConfirm;
		switch (typeConfirm) {

		case 1:
			boatType = "Motor";
			boat->setBoatType(boatType);
			finished = true;
			break;
		case 2:
			boatType = "Sailing";
			boat->setBoatType(boatType);
			finished = true;
			break;
		case 3:
			boatType = "Narrow";
			boat->setBoatType(boatType);
			finished = true;
			break;
		default:
			cin.clear();
			cin.ignore();
			system("CLS");
			cout << "Invalid input please select from 1) Motor, 2) Sailing or 3) Narrow" << endl;
		}
	} while (!finished);

		cout << "Boat has Been Booked in" << endl;
		boatList.InsertNewNode(*boat);
	
	Sleep(3000);
	system("CLS");
	DisplayMenu();

}

//Booking deletion
void Menu::DeleteBooking() {
	//takes user input of an owners name to find the boat for deletion
	string name;
	cout << "Current bookings List:" << endl;
	boatList.Display(); //Displays current booking for user
	cout << "Please input the owner name of the booking you would like to delete(Case Sensitive)" << endl;
	cin >> name;
	boatList.DeleteBooking(name);

	DisplayMenu();
}


//Bookings Display
void Menu::DisplayBooking() {
	system("CLS");
	cout << "Current Marina space is: " << marinaSpace << endl;
	cout << "Current boats docked in the Marina:" << endl;
	boatList.Display();
	system("PAUSE");
	system("CLS");
	DisplayMenu();
}


    
	


	

