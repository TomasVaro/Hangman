using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            bool keepPlaying = true;
            while (keepPlaying)
            {
                Console.Clear();
                Console.WriteLine("Väkommen till Hänga Gubbe. Du har 10 försök för att komma fram till rätt ord.\n");
                string[] words = {"Soffa", "Blåbär", "Gummi", "Trevlig", "Under", "Läser", "Programmering", "Lista", "Slumpmässigt", "Sätter",
                "Inlevelse", "Beskrivning", "Veckoslut", "Vinterdäck", "Långfärdsskridskor", "Grävutrustning", "Sparkcykel", "Norrsken", "Höstfärger", "Mandelblom",
                "Längtan", "Pensionerad", "Gammal", "Filosofisk", "Huvudled", "Riktlinjer", "Verkstad", "Vommen", "Ordvits", "Bohusleden"};
                Random rand = new Random();
                int index = rand.Next(words.Length);
                string secretWord = words[index].ToLower();
                string[] wordArray = new string[secretWord.Length]; Console.Write("Hemliga ordet: ");
                writeWordArray(secretWord, wordArray);                

                bool tenGuesses = true;
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("\nGissa på en bokstav eller hela ordet. " + (10 - i) + " försök kvar.");
                    string userInput = Console.ReadLine().ToLower();
                    if (userInput.Length == 1)
                    {
                        CheckLetter(userInput);
                    }
                    else if(userInput.Length == 0)
                    {
                        Console.WriteLine();
                    }
                    else if(userInput == secretWord)
                    {
                        Console.WriteLine("Grattis! Du lyckades gissa rätt ord (" + secretWord + ") på " + (i + 1) + " försök!");
                        tenGuesses = false;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ordet du angav var inte rätt ord!");
                    }
                }
                while (tenGuesses)
                {
                    Console.WriteLine("\nDu lyckades inte gissa rätt ord på 10 gissningar!");
                    tenGuesses = false;
                }

                Console.WriteLine("\nVill du prova igen? (j/n)");
                bool running = true;
                while (running)
                {
                    string choice = Console.ReadKey().KeyChar.ToString();
                    Console.WriteLine();
                    if (choice == "n")
                    {
                        keepPlaying = false;
                        break;
                    }
                    else if (choice != "j")
                    {
                        Console.WriteLine("\nDu måste välja j eller n. Försök igen!");
                    }
                    else
                    {
                        running = false;
                    }
                }
            }
        }
        static void writeWordArray(string secretWord, string[] wordArray)
        {
            for (int j = 0; j < secretWord.Length; j++)
            {
                wordArray[j] = " _ ";
            }
            foreach (string s in wordArray)
            {
                Console.Write(s);
            }
            Console.WriteLine();
        }
        static string CheckLetter(string userGuessLetter)
        {

            return userGuessLetter;
        }
    }
}
