#include <cstdlib>
#include <iostream>
#include <fstream>
#include <cstring>
#include <iostream>
#include <string>
#include <Windows.h>
#include <iomanip>
#include "List.h"
#include "Node.h"

using namespace std;

extern List boatList; // giving access to the global boatlist

// Method for the addition of new Nodes(boats) to boatlist or the holding bay list
void List::InsertNewNode(Boat a) {
	Node* temp;
	temp = new Node;
	temp->input = a;
	temp->next = head;
	head = temp;
}

//Method used to display the contents of a list
void List::Display() {
	Node* p;// Pointer to a node
	p = head;//points to the head of the list
	while(p!=NULL){
		cout << "Owner Name: " << p->input.getOwnerName() << " ";//displaying of each content of a Node
		cout << "Boat Length: " << p->input.getBoatLength() << " ";
		cout << "Boat Name: " << p->input.getBoatName() << " ";
		cout << "Boat Type: " << p->input.getBoatType() << "\n";
		p = p->next;//Moves to the next node in the list
	}
}

//Method to save currently stored nodes in the list to the text file
void List::Save() {
	ofstream outFile;
	
	outFile.open("BoatList.txt", ofstream::out | ofstream::trunc);//creation of the link to the text file, also clears the text file before inputting the contents of the list
	Node* p;
	p = head;
	while (p != NULL) {//Loops while the Node has contents
		outFile << p->input.getOwnerName() << " ";//Input of each seperate variable of a Node
		outFile << p->input.getBoatLength() << " ";
		outFile << p->input.getBoatName() << " ";
		outFile << p->input.getBoatType() << "\n ";
		p = p->next;//Moves to the next Node
		
	}
	outFile.close(); //Closes the connection to the text file
}


//Method to Delete bookings from the boatlist
void List::DeleteBooking(string a) {
	Node* p;
	List holdingBay; // creation of the Holding Bay list
	p = head;
	if (p == NULL) {//checks if the boatlist contains any current bookings returns to menu if list is empty
		cout << "No current bookings returing to menu" << endl;
		return;
	}
	//Loop to check through the current Nodes in the list
	while (p != NULL) {
		if (p->input.getOwnerName() == a) {
			//display the booking being removed to the user
			cout << "Booking found" << endl;
			cout << "Owner Name: " << p->input.getOwnerName() << " ";
			cout << "Boat Length: " << p->input.getBoatLength() << " ";
			cout << "Boat Name: " << p->input.getBoatName() << " ";
			cout << "Boat Type: " << p->input.getBoatType() << "\n";
			cout << "Booking has been deleted boat is now leaving the marina" << "\n";
			Sleep(4000);

			//deletion of the selected record
			Node* temp = new Node;
			temp = head;
			head = p->next;
			delete temp;
			Sleep(2000);

			//Moving boats within the holding bay to the marina
			system("CLS");
			cout << "Boats within the holding bay are now being moved back to the marina" << endl;
			holdingBay.MoveBookings();
			//deletion of the holding bay records so as none are duplicated upon next deletion
			holdingBay.Delete();
				
			Sleep(4000);
			system("CLS");
			return;

			
		}
		else {
			system("CLS");
			//loop through the list of boats moving the desired deletion to the front of the list(Marina) and other boats into the holding bay 
			cout << "The following boat has been moved to the holding bay" << endl;
			cout << "Owner Name: " << p->input.getOwnerName() << " ";
			cout << "Boat Length: " << p->input.getBoatLength() << " ";
			cout << "Boat Name: " << p->input.getBoatName() << " ";
			cout << "Boat Type: " << p->input.getBoatType() << "\n";
			Sleep(2000);
			system("CLS");

			//moving of boats to holding bay
			holdingBay.InsertNewNode(p->input);
			//deletion of the boat from the Marina once it is moved to the holding bay
			Node* temp = new Node;
			temp = head;
			head = p->next;
			p = head;
			delete temp;
			

		}
	}
	cout << "Booking not found moving boats back to marina and returning to menu";
	holdingBay.MoveBookings();
	Sleep(2000);
	system("CLS");
}
//Method to calculate the total length of all boats in the marina to calculate the amount of space left
int List::BoatSpace(int b) {
	Node* p;
	p = head;
	while (p != NULL) {
		b = b + p->input.getBoatLength();
		p = p->next;

	}
	return b;
}

//Method to move boats within the holding bay back into the main boatlist(Marina)
void List::MoveBookings() {
	Node* p;
	p = head;
	while (p != NULL) {
		boatList.InsertNewNode(p->input);
		p = p->next;
		}

}

//method to delete all records within a list
void List::Delete() {
	Node* temp = new Node;
	temp = head;
	head = temp->next;	
	delete temp;

}

