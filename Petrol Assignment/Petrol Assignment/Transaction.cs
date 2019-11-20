using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petrol_Assignment
{
    //Assigns the pump and vehicle to each transaction and assigns the variables for transactions.
    class Transaction
    {
        private Pump pump;
        private Vehicle vehicle;

        //gets and sets the pump data within each transaction
        public Pump Pump
        {
            get
            {
                return pump;
            }
            set
            {
                pump = value;
            }
        }
        //Gets and sets the vehicle data within each transaction
        public Vehicle Vehicle
        {
            get
            {
                return vehicle;
            }
            set
            {
                vehicle = value; 
            }
        }   
        //creates a public transaction allowing it to be used within other classes.
        public Transaction()
        {
        }
    }
}
