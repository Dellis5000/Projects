using System;
using System.Timers;

namespace Petrol_Assignment
{
    class Pump
    {
        //assigning local variables
        public Vehicle currentVehicle = null;
        public Pump currentPump;
        public int pumpNumber;
        public static int vehiclesFueled;
        public static double totalUL, totalDiesel, totalLPG;
        
                
        //assigns each pump generated its variable "pumpnumber"
        public Pump(int pn)
        {
            pumpNumber = pn;
        }
        
        //Checks a pumps availability using a bool if it has a vehicle assigned or none
        public bool IsAvailable()
        {

            return currentVehicle == null;
        }
        
        //Gives the pump the data to calculate fuel time and fuel dispensed. Assigned vehicle and pump data from the assignvehicle to pump method within data
        public void AssignVehicle(Vehicle v, Pump p)
        {
            currentVehicle = v;
            currentPump = p;
                       

            Timer timer = new Timer();
            //setting the timer interval based upon the vehicles fuel time
            timer.Interval = v.fuelTime;
            timer.AutoReset = false;
            //Series of methods run after timer elapses to get fuel totals,transaction data, vehicles fuelled and release the vehicle
            timer.Elapsed += FuelTotal;
            timer.Elapsed += Trans;
            timer.Elapsed += ReleaseVehicle;
            timer.Elapsed += VehiclesFueled;
            timer.Enabled = true;
            timer.Start();
            
        }

        //Creates fuel totals for each type of fuel, if statements assign the data to the correct fuel type
        public void FuelTotal(object sender, ElapsedEventArgs e)
        {
            if (currentVehicle.fuelType == "Unleaded")
            {
                //adds to total unleaded
                totalUL = totalUL + (currentVehicle.fuelTime / 1000) * 1.5;
            }
            else if (currentVehicle.fuelType == "Diesel")
            {
                //adds to total Diesl
                totalDiesel = totalDiesel + (currentVehicle.fuelTime / 1000) * 1.5;
            }
            else if (currentVehicle.fuelType == "LPG")
            {
                //adds to total LPG
                totalLPG = totalLPG + (currentVehicle.fuelTime / 1000) * 1.5;
                
            }          

        }

        //Releases the current vehicle from the pump, freeing the pump and also deleting the vehicle
        public void ReleaseVehicle(object sender, ElapsedEventArgs e)
        {
            currentVehicle = null;
        }

        //Increases the running total of vehicles fuelled every time a vehicle finishes fuelling
        public void VehiclesFueled (object sender, ElapsedEventArgs e)
        {
            //Increases the variable "vehiclesFueled" by 1
            vehiclesFueled++;
        }

        //Sends the vehicle and pump data to create a new transaction with the correct data for each vehicle fuelled
        public void Trans(object sender, ElapsedEventArgs e)
        {
           //calls the method NewTransaction within display assigning the variables of currentvehicle and currentpump
            Display.NewTransaction(currentVehicle, currentPump);
        }
        
    }
}
