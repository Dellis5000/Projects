using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Artificial_Intelligence_Project
{
    class Program
    {
        static bool showWordlist = false;
        static bool correctguess = true;
        static void Main(string[] args)
        {

            StartGame();
            Guessing();


            Console.WriteLine("Unlucky the word was: " + Constants.selectedWord);
        }

        public static void StartGame()
        {
            Console.WriteLine("Welcome to Guess the Word");
            Console.WriteLine("Please enter the length of the word:");
            Constants.wordLength = Convert.ToInt32(Console.ReadLine());

            WordData.ConstructInitialWordlist();

            Console.WriteLine("Please enter the amount of guesses:");
            Constants.guesses = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Would you like to display the number of words remaining in the wordlist? (Y/N)");
            string showWordlistInput = Console.ReadLine();

            showWordlistInput.ToLower();

            if (showWordlistInput == "y")
            {
                showWordlist = true;
            }
            else if (showWordlistInput == "n")
            {
                showWordlist = false;
            }
            else
            {
                do
                {
                    Console.WriteLine("Incorrect Entry please select Y or N");
                    Console.WriteLine("Would you like to display the number of words remaining in the wordlist? (Y/N)");
                    showWordlistInput = Console.ReadLine();

                    showWordlistInput.ToLower();

                    if (showWordlistInput == "y")
                    {
                        showWordlist = true;
                        return;
                    }
                    else if (showWordlistInput == "n")
                    {
                        showWordlist = false;
                        return;
                    }
                    else
                    {

                    }
                } while (showWordlistInput != "y" || showWordlistInput != "n");


              

            }
        }

        public static void Guessing()
        {
            
            do
            {
                //WordData.SelectWord();
               
                Console.WriteLine("Please guess a letter");//Prompting user for guess input
                Constants.currentGuess = Convert.ToChar(Console.ReadLine()); //assignment of guessed letter to a variable
                               
                Constants.usedLetters.Add(Constants.currentGuess); //Adds the letter guessed to the list of guessed letters


                WordData.OptimiseWordlist();
                if (correctguess == true)
                {
                    WordData.SelectWord();
                }
                else
                {

                }
                BuildWordDisplay();
                
               
                if (Constants.selectedWord == Convert.ToString(Constants.wordDisplay))
                {
                    Console.WriteLine("Congratulations you won");
                    return;
                }
                else if (Constants.selectedWord.Contains(Constants.currentGuess)) // checks if the word contains the letter guessed
                {
                    WordData.EditWordList();// Edit wordlist to ensure the words left have the correct characters as the positions shown to user
                    //WordData.SelectWord();
                    if (showWordlist == true)
                    {
                        Console.WriteLine("Current words in Wordlist are " + WordData.optimisedWords.Count());

                    }
                    BuildWordDisplay();
                    //text and variable manipulations for a correct guess
                    correctguess = true;
                    Console.WriteLine("Your guess was correct!");//Display to tell the user the guess was correct
                    foreach (var array in Constants.usedLetters) //loops through the used letters list
                        Console.WriteLine("Letters guessed: " + string.Join("", array)); // Displays the list of used letters to the user

                    WordData.RemoveMultipleLetters();
                    Console.WriteLine("Word:" + Constants.wordDisplay);


                }
                else
                {
                    WordData.EditWordList();
                    if (showWordlist == true)
                    {
                        Console.WriteLine("Current words in Wordlist are " + WordData.optimisedWords.Count());

                    }
                    
                    correctguess = false;
                    Console.WriteLine("Incorrect Guess try again");

                    foreach (var array in Constants.usedLetters)
                        Console.WriteLine("Letters guessed: " + string.Join(" ", array));

                    Console.WriteLine("Word:" + Constants.wordDisplay);
                }

                Constants.guesses -= 1;
                Console.WriteLine("You have " + Constants.guesses + " guesses remaining.");

            } while (Constants.guesses != 0);

        }

        public static void BuildWordDisplay()
        {
            Constants.wordDisplay.Clear(); //clears the word display to show the updated correct letters
            foreach (char letter in Constants.selectedWord)
                if (Constants.usedLetters.Contains(letter))
                {
                    Constants.wordDisplay.Append(letter);

                }
                else
                {
                    Constants.wordDisplay.Append('-');

                }
        }

    }
}
