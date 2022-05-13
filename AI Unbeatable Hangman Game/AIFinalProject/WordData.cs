using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Artificial_Intelligence_Project
{
    class WordData
    {
        public static List<string> words;

        public static List<int> letterPositition = new List<int>();
        public static List<string> wordsComparison = new List<string>();
        public static List<string> optimisedWords = new List<string>();

        public static void ConstructInitialWordlist()
        {
            words = System.IO.File.ReadLines("dictionary.txt").ToList(); //construct intitial wordlist from dictionary.txt

            words.RemoveAll(words => words.Length != Constants.wordLength);//Removes all words not of the input wordlength

            if (words.Count <= 0)//loops if the wordlist contains no words until a list with words is selected
            {
                do
                {
                    words = System.IO.File.ReadLines("dictionary.txt").ToList(); //rebuilds the list as it has been set to 0 in error

                    Console.WriteLine("Not enough words of that length please enter a new length of the word");
                    Constants.wordLength = Convert.ToInt32(Console.ReadLine());

                    words.RemoveAll(words => words.Length != Constants.wordLength);

                } while (words.Count <= 0);
            }
            optimisedWords.AddRange(words);
        }

        public static void OptimiseWordlist()
        {                               
                words.Clear();
                words.AddRange(optimisedWords);
                optimisedWords.Clear();
                wordsComparison.Clear();

                foreach (string word in words.ToList())//loop through every word in the wordlist
                {
                    foreach (char letter in word)//loops through every character in the word
                    {
                        if (letter == Constants.currentGuess)
                        {
                            wordsComparison.Add(word);
                            words.Remove(word);
                            break;
                        }
                        else
                        {
                        }
                    }
                }
                if (wordsComparison.Count > words.Count)
                {
                    optimisedWords.AddRange(wordsComparison);

                }
                else
                {
                    optimisedWords.AddRange(words);

                }
            }
            

        public static void EditWordList()
        {
            string wordContents = Constants.wordDisplay.ToString();
            letterPositition.Clear();
            //Method to remove all words that do not have correct letters at positions shown to user
            for (int x = 0; x < wordContents.Length; x++)//loop through every character that has currently been displayed
            {
                if (Convert.ToString(wordContents[x]) == "-" )//Ignore any characters that are unshown to the player
                {

                }
                else if (wordContents[x] == Constants.currentGuess)
                {
                    letterPositition.Add(x);
                }
                else 
                {

                }

            }
            foreach(string word in optimisedWords.ToList())
            {
                foreach(int position in letterPositition)
                {
                    if (word[position] != Constants.currentGuess)
                    {
                        optimisedWords.Remove(word);
                    }
                    else
                    {

                    }
                }
            }

        }

        //Method to remove any words with duplications of letters already guessed
        public static void RemoveMultipleLetters()
        {

            string wordContents = Constants.wordDisplay.ToString();
            letterPositition.Clear();
            //Method to remove all words that do not have correct letters at positions shown to user
            for (int x = 0; x < wordContents.Length; x++)//loop through every character that has currently been displayed
            {
                if (wordContents[x] == Constants.currentGuess)
                {
                    letterPositition.Add(x);
                }
                else
                {

                }
            }
            foreach (string word in optimisedWords.ToList()) // to finish removiing duplicates
            {
                int letterCount = 0;
                int letterCountSelected = 0;
                foreach (char letter in Constants.selectedWord) // check how many of correctly guessed letters were in the word
                {
                    if(letter == Constants.currentGuess)
                    {
                        letterCountSelected++;
                    }
                }
                foreach (int position in letterPositition)
                {
                    if (word[position] == Constants.currentGuess)
                    {
                        letterCount++;
                    }
                    else
                    {

                    }
                }
                if (letterCountSelected > letterCount)
                {
                    optimisedWords.Remove(word);
                }
            }
        }

        public static void SelectWord()
        {
            Constants.selectedWord = WordData.optimisedWords[Constants.rng.Next(0, WordData.optimisedWords.Count)];
        }

    }
}