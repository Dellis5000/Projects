using System;


namespace Petrol_Assignment
{
    class Vehicle
    {
        // setting variables for the class
        public string fuelType;
        public double fuelTime, tankSize, fuelInTank;
        public string vehicleType;
        public static int nextCarID = 0;
        public int carID;
        
        // sets the variables for each new vehicle generated
        public Vehicle(string ftp, double ftm, string vtp, double tsz, double fit)
        {
            fuelType = ftp;
            fuelTime = ftm;
            vehicleType = vtp;
            tankSize = tsz;
            fuelInTank = fit;
            carID = nextCarID++;
            
        }
    }
}
