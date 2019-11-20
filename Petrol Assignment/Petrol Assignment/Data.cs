using System;
using System.Collections.Generic;
using System.Timers;

namespace Petrol_Assignment
{
    class Data
    {
        //assignment of local variables and also Lists
        private static Timer timer;
        public static List<Vehicle> vehicles;
        public static List<Pump> pumps;
        public static int vehiclesLeft;
        static Random rng = new Random();


        public static void Initialise()
        {
            //Runs the stated methods
            InitialisePumps();
            InitialiseVehicles();
        }

        //Creates the vehicles
        private static void InitialiseVehicles()
        {
            vehicles = new List<Vehicle>();

            timer = new Timer();
            //Creates a new vehicle randomly every 1.5 to 2.2 seconds
            timer.Interval = rng.Next(1500, 2200);
            timer.AutoReset = true;
            // runs the create Vehicle method
            timer.Elapsed += CreateVehicle;
            timer.Enabled = true;
            timer.Start();

            //runs the AssignVehicleToPump method, It also runs this in program loop, adding here alleviated some vehicles leaving the pumps when there were pumps free
            AssignVehicleToPump();

            //Starts a new timer to remove the vehicle if its not serviced within stated timeframe.
            timer = new Timer();
            //Randomly generated time between 1 and 2 seconds
            timer.Interval = rng.Next(1000, 2000);
            timer.AutoReset = true;
            timer.Elapsed += RemoveVehicle;
            timer.Enabled = true;
            timer.Start();
        }

        //Creates new vehicles with random vehicle types, fuel types and fuel in tank.
        private static void CreateVehicle(object sender, ElapsedEventArgs e)
        {
            //Stops the vehicles within the queue going over 5.
            if (vehicles.Count < 5)
            {
                //Randomly generates a type for each new vehicle
                int type = rng.Next(0, 3);
                //creates a new Vehicle in the variable "v"
                Vehicle v = null;

                //A switch to assign different data based on the vehicle type
                switch (type)
                {
                    //creates a new car
                    case 0:
                        //assigns the vehicles variables fuel type selected randomly and fuel in tank is also generated at random
                        v = new Vehicle(AssignFuelType(rng.Next(0, 3)), 0, "Car", 40, rng.Next(1,10));

                        //calculates fuelling time based on tank size and fuel in tank
                        v.fuelTime = ((v.tankSize - v.fuelInTank) / 1.5) * 1000;
                        break;

                    //creates a new van    
                    case 1:
                        //within this case the fuel type selected can only be Diesel and LPG, also fuel in tank has different min/max values
                        v = new Vehicle(AssignFuelType(rng.Next(1, 3)), 0, "Van", 80, rng.Next(1, 20));
                        v.fuelTime = ((v.tankSize - v.fuelInTank) / 1.5) * 1000;
                        break;

                    //Creates a new HGV
                    case 2:
                        v = new Vehicle(AssignFuelType(1),0 , "HGV", 160, rng.Next(1, 40));
                        v.fuelTime = ((v.tankSize - v.fuelInTank) / 1.5) * 1000;
                        break;
                }
                vehicles.Add(v);
                                                                            
            }
            else
            {
                return;
            }
                    

        }

        //Removes Vehicles from the vehicle list
        public static void RemoveVehicle(object sender, ElapsedEventArgs e)
        {
            try
            {
                Vehicle v;
                v = vehicles[0];
                vehicles.Remove(v);
                vehiclesLeft++;
                return;
            }
            catch
            {
                return;
            }
        }
        
        //Assignment of fuel type for new vehicles
        public static string AssignFuelType(int type)
        {
            switch (type)
            {
                case 0:
                    return "Unleaded";
                case 1:
                    return "Diesel";
                case 2:
                    return "LPG";
                default:
                    return "Error";
            }
        }

        //Creation of pumps
        private static void InitialisePumps()
        {
            pumps = new List<Pump>();

            Pump p;

            // loops through creating pumps 1 to 9 and assigning pump numbers
            for (int i = 0; i < 9; i++)
            {
                //Increases pump number by 1 each time 
                int pumpNo = i + 1;
                p = new Pump(pumpNo);
                //adds new pumps to the list "pumps"
                pumps.Add(p);
            }
        }

        //Assigns Vehicles to a pump
        public static void AssignVehicleToPump()
        {
            Vehicle v;
            Pump p;
            
            //Breaks from the method if no vehicles are waiting to be assigned
            if (vehicles.Count == 0) { return; }

            //Loops through pumps 3, 2, 1 backwards thus creating the lane blocking pumps 2 and 3 if pump 1 is in use
            if (pumps[0].IsAvailable() == true)
            {
                for (int i = 2; i > -1; i--)
                {
                    if (vehicles.Count == 0) { return; }
                    p = pumps[i];


                    if (p.IsAvailable())
                    {
                        //Takes the first vehicle in the "vehicles list"
                        v = vehicles[0];
                        //Removes the vehicle from the list
                        vehicles.RemoveAt(0);
                        //Assigns both Vehicle data and pump data
                        p.AssignVehicle(v, p);

                    }

                    if (vehicles.Count == 0) { break; }

                }
            }

            //Same as above but for pumps  4-6
            else if (pumps[3].IsAvailable() == true)
            {
                if (vehicles.Count == 0) { return; }
                for (int i = 5; i > 2; i--)
                {
                    p = pumps[i];


                    if (p.IsAvailable())
                    {
                        v = vehicles[0];
                        vehicles.RemoveAt(0);
                        p.AssignVehicle(v, p);

                    }

                    if (vehicles.Count == 0) { break; }

                }
            }

            //Same as above but for pumps 7-9
            if (pumps[6].IsAvailable() == true)
            {
                if (vehicles.Count == 0) { return; }
                for (int i = 8; i > 5; i--)
                {
                    p = pumps[i];


                    if (p.IsAvailable())
                    {
                        v = vehicles[0];
                        vehicles.RemoveAt(0);
                        p.AssignVehicle(v, p);

                    }

                    if (vehicles.Count == 0) { break; }

                }
            }
        }
    }
}



    

