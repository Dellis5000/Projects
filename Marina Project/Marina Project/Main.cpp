#include <cstring>
#include <iostream>
#include <cstring>
#include "MainMenu.h"
#include "List.h"

int main(void) {
	//Main used to initialise the program/menu 
	Menu* menu;
	menu = new Menu();
	menu->DisplayMenu();
	

	system("pause");
	return 0;
}