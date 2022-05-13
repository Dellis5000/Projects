#pragma once
#include <string>
#include "Node.h"
#include "Boat.h"

class List{
private:
	Node* head, * tail; // Node pointers to head and tail
public:
	List() // default constructor
	{
		head = NULL;
		tail = NULL;
	}
	//definitiion of list functions
	void InsertNewNode(Boat a);
	void Display();
	void Save();
	void DeleteBooking(string a);
	void MoveBookings();
	int BoatSpace(int b);
	void Delete();
	};
