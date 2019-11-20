using System;
using System.Timers;

namespace Petrol_Assignment
{
    class Program
    {
        
        static void Main(string[] args)
        {
            //Runs the initialise method which creates both pumps and vehicles
            Data.Initialise();
            //new timer starting the program loop
            Timer timer = new Timer();
            timer.Interval = 900;
            timer.AutoReset = true; 
            timer.Elapsed += RunProgramLoop;
            timer.Enabled = true;
            timer.Start();

            Console.ReadLine();
        }

        //Program loop which runs through given methods to allow the app to run
        static void RunProgramLoop(object sender, ElapsedEventArgs e)
        {
            Console.Clear();
            Display.DrawVehicles();
            Console.WriteLine();
            Console.WriteLine();
            Display.DrawPumps();
            Data.AssignVehicleToPump();
            Display.Counters();
            Console.WriteLine();
            Display.ShowTransactions();
        }
    }
}
