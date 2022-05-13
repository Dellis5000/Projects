using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafpack
{
    public partial class UserInput : Form
    {
        private float inputValue, upperBound, lowerBound;
        private string inputType;
        
        public UserInput(string type, float lower, float upper)
        {
            InitializeComponent(); //Initialise the form
            inputType = type; // setting of variables
            upperBound = upper;
            lowerBound = lower;

            label1.Text = "";
            label1.Text = Convert.ToString("Enter a " + inputType + lowerBound + " and " + upperBound); //Displays to user with customised text dependant on method
                                
        }

        private void UserInput_Load(object sender, EventArgs e)
        {

        }        

        private void Button2_Click(object sender, EventArgs e) //Method if user clicks cancel
        {            
            inputValue = 999999999; //Number used to identify if user clicks cancel
            this.Close();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        public float GetInput()
        {
            return inputValue; 
        }       

        private void Button1_Click(object sender, EventArgs e)
        {
           
            inputValue = float.Parse(textBox1.Text); //set the textbox text based on tranform type
                           
            if (inputValue >= lowerBound && inputValue <= upperBound) //Check the input is within upper and lower bounds
            {                
                this.Close();                
            }
            else
            {
                MessageBox.Show("Please input a number between" + lowerBound + " and " + upperBound); //Displays if userinputs incorrectly                   
                this.Close();
                UserInput userInput = new UserInput(inputType, lowerBound,upperBound); //Creates a new form for new input
                userInput.TopMost = true;
                userInput.Show();
            }           
        }
    }
}
