#pragma once
#include <string>
#include "Boat.h"

using namespace std;

struct Node
{
	//Node Constructors
	Boat input;
	Node* next;
};