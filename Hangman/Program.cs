using System;
using System.Collections.Generic;

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
                Console.WriteLine("Väkommen till Hänga Gubbe. Du har 10 försök för att komma fram till rätt ord.");
                string[] words = {"Soffa", "Blåbär", "Gummi", "Trevlig", "Under", "Läser", "Programmering", "Lista", "Slumpmässigt", "Sätter",
                "Inlevelse", "Beskrivning", "Veckoslut", "Vinterdäck", "Långfärdsskridskor", "Grävutrustning", "Sparkcykel", "Norrsken", "Höstfärger", "Mandelblom",
                "Längtan", "Pensionerad", "Gammal", "Filosofisk", "Huvudled", "Riktlinjer", "Verkstad", "Vommen", "Ordvits", "Bohusleden"};
                Random rand = new Random();
                int index = rand.Next(words.Length);
                string secretWord = words[index].ToLower();
                char[] wordArray = new char[secretWord.Length];
                writeWordArray(secretWord, wordArray);

                List<string> inputLettersList = new List<string>();
                bool tenGuesses = true;
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Gissa på en bokstav eller hela ordet. " + (10 - i) + " försök kvar.");
                    string userInput = Console.ReadLine().ToLower();
                    if (userInput.Length == 1)
                    {
                        foreach (string n in inputLettersList)
                        {
                            if (n == userInput)
                            {
                                Console.WriteLine("\nDu har redan gissat på denna bokstav. Försök igen!");
                                i--;
                                inputLettersList.Remove(userInput);
                                break;
                            }
                        }
                        inputLettersList.Add(userInput);
                        writeWordArray(secretWord, wordArray);
                    }
                    else if(userInput.Length == 0)
                    {
                        Console.WriteLine("Du skrev inte inte in något. Försök igen!");
                        i--;
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
                        writeWordArray(secretWord, wordArray);
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
        static void writeWordArray(string secretWord, char[] wordArray)
        {
            Console.Write("\nHemliga ordet: ");
            for (int j = 0; j < secretWord.Length; j++)
            {
                wordArray[j] = char.Parse("_");
            }
            foreach (char s in wordArray)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
        }
        static string CheckLetter(List<string> inputLetersString, string userGuessLetter)
        {
            for (int i = 0; i < inputLetersString.Count; i++)
            {
                if (userGuessLetter == inputLetersString[i])
                {
                    Console.WriteLine("\nDu har redan gissat på denna bokstav. Försök igen!");

                }
            }
            inputLetersString.Add(userGuessLetter);
            return userGuessLetter;
        }
    }
}
