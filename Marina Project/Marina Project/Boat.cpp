#include <cstdlib>
#include <iostream>
#include <cstring>
#include "Boat.h"
//Get and set Methods for a boat

string Boat::getOwnerName()
{
	return ownerName;
}

string Boat::getBoatName()
{
	return boatName;
}

string Boat::getBoatType()
{
	return boatType;
}

int Boat::getBoatLength()
{
	return boatLength;
}

void Boat::setOwnerName(string var)
{
	ownerName = var;
}

void Boat::setBoatName(string var)
{
	boatName = var;
}

void Boat::setBoatType(string var)
{
	boatType = var;
}

void Boat::setBoatLength(int var)
{
	boatLength = var;
}

