#pragma once
#include <string>

using namespace std;

class Boat{
public:
	//defining class variables
	string ownerName;
	string boatName;
	string boatType;
	int boatLength;

	//constructors
	string getOwnerName();
	string getBoatName();
	string getBoatType();
	int getBoatLength();

	void setOwnerName(string);
	void setBoatName(string);
	void setBoatType(string);
	void setBoatLength(int);
};