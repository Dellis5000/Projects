using System;
using System.Collections.Generic;
using System.Text;

namespace Artificial_Intelligence_Project
{
    class Constants
    {
        public static string selectedWord;

        public static char currentGuess;

        public static StringBuilder wordDisplay = new StringBuilder();

        public static int guesses, wordLength;
        public static Random rng = new Random();

        public static List<char> usedLetters = new List<char>(); //List containing all guessed letters
    }
}
