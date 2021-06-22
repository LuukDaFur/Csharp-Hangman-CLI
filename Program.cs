//Basic system import
using System;

//Contains interfaces and classes that define generic collections                               https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-5.0
using System.Collections.Generic;

//Provides classes and interfaces that support queries that use Language-Integrated Query       https://docs.microsoft.com/en-us/dotnet/api/system.linq?view=net-5.0
using System.Linq;

//
using System.Text;
 
namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            //Clears the console so the game runs with good formatting
            Console.Clear();
            
            //Writes a welcome message
            Console.WriteLine("###########################");
            Console.WriteLine("### Welcome to Hangman! ###");
            Console.WriteLine("###########################");
            
            //formatting so text is easy to read
            Console.WriteLine();
            string[] listwords = new string[10];
            listwords[0] = "sheep";
            listwords[1] = "goat";
            listwords[2] = "computer";
            listwords[3] = "america";
            listwords[4] = "watermelon";
            listwords[5] = "icecream";
            listwords[6] = "jasmine";
            listwords[7] = "pineapple";
            listwords[8] = "orange";
            listwords[9] = "mango";

            //gets a random integer that selects the word
            Random randGen = new Random();
            var idx = randGen.Next(0, 9);
            string mysteryWord = listwords[idx];
            char[] guess = new char[mysteryWord.Length];

            //Fills an array which shows the word's status with guessed letters
            for (int p = 0; p < mysteryWord.Length; p++)
                guess[p] = '*';
                Console.WriteLine("Word Status");
                Console.WriteLine(guess);
                
                //More formatting
                Console.WriteLine();
            //Prompts the user for input and ads it to the array if correct
            while (true)
            {   
                Console.WriteLine("Make sure to only enter one letter at a time!");
                Console.Write("Please enter your guess: ");
                char playerGuess = char.Parse(Console.ReadLine());
                for (int j = 0; j < mysteryWord.Length; j++)
                {
                    if (playerGuess == mysteryWord[j])
                        guess[j] = playerGuess;
                }
                Console.WriteLine(guess);
            }
        }
    }
}