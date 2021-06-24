//Basic system import
using System;

//Contains interfaces and classes that define generic collections                               https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic?view=net-5.0
using System.Collections.Generic;

//Provides classes and interfaces that support queries that use Language-Integrated Query       https://docs.microsoft.com/en-us/dotnet/api/system.linq?view=net-5.0
using System.Linq;


using System.Text;
 
namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            //Label to go back to start when game finishes
            START:

            int ExitVar = 0;
            int tries = 11;
            //Clears the console so the game runs with good formatting
            Console.Clear();
            
            //Writes a welcome message
            Console.WriteLine("###########################");
            Console.WriteLine("### Welcome to Hangman! ###");
            Console.WriteLine("###########################");
            
            //formatting so text is easy to read
            Console.WriteLine();

            //prints your tries
            Console.WriteLine($"You have {tries} tries remaining");
            Console.WriteLine();

            //wordlist
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
                Console.WriteLine();
                Console.WriteLine(guess);
                Console.WriteLine();
            //Prompts the user for input and ads it to the array if correct
            while (true)
            {   
                //Condition to do tries --
                bool InArray = true;

                //label to return to if there are multiple letters
                MultiLettr:

                //prompts user
                Console.Write("Please enter your guess: ");

                //user input string
                string playerGuessStr = Console.ReadLine();
                
                //checks playerGuess length
                if (playerGuessStr.Length > 1){
                    Console.Clear();

                    Console.WriteLine("###########################");
                    Console.WriteLine("### Welcome to Hangman! ###");
                    Console.WriteLine("###########################");
            
                    //formatting so text is easy to read
                    Console.WriteLine();

                    Console.WriteLine($"You have {tries} tries remaining");
                    Console.WriteLine();
                
                    Console.WriteLine("Word Status");
                    Console.WriteLine();
                    Console.WriteLine(guess);
                    Console.WriteLine();
                    Console.WriteLine("Please enter a single letter!");
                    Console.WriteLine();
                    goto MultiLettr;
                }

                if (playerGuessStr.Length < 1){
                    Console.Clear();

                    Console.WriteLine("###########################");
                    Console.WriteLine("### Welcome to Hangman! ###");
                    Console.WriteLine("###########################");
            
                    //formatting so text is easy to read
                    Console.WriteLine();

                    Console.WriteLine($"You have {tries} tries remaining");
                    Console.WriteLine();
                
                    Console.WriteLine("Word Status");
                    Console.WriteLine();
                    Console.WriteLine(guess);
                    Console.WriteLine();
                    Console.WriteLine("Please enter a letter!");
                    Console.WriteLine();
                    goto MultiLettr;
                }

                //coverts string input to a char
                char playerGuess = char.Parse(playerGuessStr);

                
                
                //checks whether the player's guess is the same as one or more of the letters in the word
                for (int j = 0; j < mysteryWord.Length; j++)
                {
                    if (playerGuess == mysteryWord[j]){
                        guess[j] = playerGuess;
                    }
                }

                if (mysteryWord.Contains(playerGuess) == false){
                    Console.WriteLine("That was not a letter in this word, please try again");
                    InArray = false;
                }

                if (InArray == false){
                    tries --;
                }

                //clears console so nothing remains
                Console.Clear();
            
                //Writes a welcome message
                Console.WriteLine("###########################");
                Console.WriteLine("### Welcome to Hangman! ###");
                Console.WriteLine("###########################");
            
                //formatting so text is easy to read
                Console.WriteLine();

                Console.WriteLine($"You have {tries} tries remaining");
                Console.WriteLine();
                
                Console.WriteLine("Word Status");
                Console.WriteLine();

                Console.WriteLine(guess);
                Console.WriteLine();

                if (tries == 0){
                    Console.WriteLine("Sorry you ran out of guesses, the word was: " + mysteryWord);
                    break;
                }

                if (guess.SequenceEqual(mysteryWord) == true){
                    Console.WriteLine("Good job, you guessed the word!");
                    Console.WriteLine();
                    Console.WriteLine("Wanna start again?");
                    Console.WriteLine();
                    Console.WriteLine("[Y]es            [N]o");

                    while(true){

                    string keyChoice = Console.ReadLine();

                    //Respone to the preferred key choice
                    switch (keyChoice)
                {
                    case "y":
                        //Makes it go back to the start of the game
                        goto START;
                
                    case "Y":
                        //Same as above just capital
                        goto START;
                
                    case "n":
                        //Writes a goodbye message and then breaks the loop
                        Console.WriteLine(" see you soon!");
                        ExitVar ++;
                        break;

                    case "N":
                        //Same as above just capital
                        Console.WriteLine(" see you soon!");
                        ExitVar ++;
                        break;

                    default:
                        Console.WriteLine(" That isn't a valid key, enter y or n");
                        continue; //restart the loop
                }
                break;
                }
                if(ExitVar == 1){
                    break;
                }
            }
        }
    }
}
}