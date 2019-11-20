using System;
using System.Timers;
using System.Collections.Generic;


namespace Petrol_Assignment
{
    class Display
    {
        //Assigning local variables 
        private static double totalULDispensed,totalDiesDispensed,totalLPGDispensed;
        private static double totalULPrice, totalDiesPrice, totalLPGPrice, commission;
        
        //creating the new list "transactions" which holds all transaction data
        public static List<Transaction> transactions = new List<Transaction>();

        //Draws vehicles currently waiting within the console
        public static void DrawVehicles()
        {
            //Assigns the Vehicle list to the variable "v"
            Vehicle v;

            Console.WriteLine("Vehicles Queue:");
            
            //loops through the list of Vehicles based on how many elements are in the list
            for (int i = 0; i < Data.vehicles.Count; i++)
            {
                v = Data.vehicles[i];
                Console.Write("#{0} Fuel Type: {1} | ", v.carID, v.fuelType);                            

            }
        }
        
        //Draws the pumps and also if they are free or busy within the console
        public static void DrawPumps()
        {
            //assigns the pump list to the variable "p"
            Pump p;

            Console.WriteLine("Pumps Status:");

            //loops through all 9 pumps
            for (int i = 0; i < 9; i++)
            {
                p = Data.pumps[i];

                Console.Write("Pump #{0} ", i + 1);
                //If/else dependant on if the pump is currently available or not
                if (p.IsAvailable()) { Console.Write("FREE"); }
                else { Console.Write("BUSY"); }
                Console.Write(" | ");

                //Skips down a line every 3 pumps to create rows of "1,2,3", "4,5,6" and "7,8,9"
                if (i % 3 == 2) { Console.WriteLine(); }

            }

        }

        //Counters displaying vehicles fuelled, fuel totals, commission and vehicles left before fuelling.
        public static void Counters()
        {
            Console.WriteLine();
            //Uses the "vehiclesfueled" variable within pumps to display amount of vehicles fuelled
            Console.WriteLine("Total vehicles fueled {0}", Pump.vehiclesFueled);
            Console.WriteLine();

            //Pulls across the variable allowing calculations on it without corrupting the needed data.
            totalULDispensed = Pump.totalUL;
            //Displays the fuel total for Unleaded
            Console.WriteLine("The total Unleaded dispensed is {0}", totalULDispensed);
            
            //Calculation based upon the price of fuel to give total cost.
            totalULPrice = totalULDispensed * 1.196;
            //Rounds the variable "totalULPrice" to 2 decimal places to make it user friendly
            totalULPrice = Math.Round(totalULPrice, 2);
            //displays total cost of unleaded
            Console.WriteLine("Total cost of unleaded dispensed £{0}", totalULPrice);
            Console.WriteLine();

            //Same as above except for Diesel
            totalDiesDispensed = Pump.totalDiesel;
            Console.WriteLine("The total Diesel dispensed is {0}", totalDiesDispensed);

            totalDiesPrice = totalDiesDispensed * 1.120;
            totalDiesPrice = Math.Round(totalDiesPrice, 2);
            Console.WriteLine("Total cost of Diesel dispensed £{0}", totalDiesPrice);
            Console.WriteLine();

            //Same as above except for LPG
            totalLPGDispensed = Pump.totalLPG;
            Console.WriteLine("The total LPG dispensed is {0}", totalLPGDispensed);

            totalLPGPrice = totalLPGDispensed * 1.050;
            totalLPGPrice = Math.Round(totalLPGPrice, 2);
            Console.WriteLine("Total cost of LPG dispensed £{0}", totalLPGPrice);

            //Calculates the commission from each total price and adds them together
            commission = (totalULPrice / 100) + (totalLPGPrice / 100) + (totalDiesPrice / 100);
            //Rounds the commission to 2 decimal places
            commission = Math.Round(commission, 2);
            Console.WriteLine();

            //Displays total commission
            Console.WriteLine("Total commission earned this session £{0}", commission);
            Console.WriteLine();

            //Displays Vehicles left before fuelling
            Console.WriteLine("Vehicles left before being Fuelled {0}", Data.vehiclesLeft);
            Console.WriteLine();
        }

        //Creates new transaction with data sent from the pump class
        public static void NewTransaction(Vehicle v, Pump p)
        {
            //creates the new transaction in the transaction list
            Transaction transaction = new Transaction();
            //assignment of the variables
            transaction.Pump = p.currentPump;
            transaction.Vehicle = v;
            transactions.Add(transaction);
        }

        //Displaying the transactions to the console
        public static void ShowTransactions()
        {
            int stopAtIndex = 0;
            
            //If statement stops the list of transactions being greater than 5 as there would be too much data to display
            if (transactions.Count > 5)
            {
                stopAtIndex = transactions.Count - 5;
            }
            
            //loops through the transactions
            for (int i = transactions.Count - 1; i >= stopAtIndex; i--)
            {
                double transactionLitres;
                //displays transaction information
                Console.WriteLine("Transaction list:");
                Console.WriteLine("Pump number {0} | ", transactions[i].Pump.pumpNumber);
                Console.WriteLine("Vehicle Type:{0}", transactions[i].Vehicle.vehicleType);
                Console.WriteLine("Fuel type: {0}", transactions[i].Vehicle.fuelType);
                //calculates the transaction litres based off fuel time
                transactionLitres = transactions[i].Vehicle.fuelTime / 1000 * 1.5;
                Console.WriteLine("Total litres dispensed {0}", transactionLitres);
                Console.WriteLine();
            }
        }

    }
}

