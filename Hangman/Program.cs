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
                for (int j = 0; j < secretWord.Length; j++)
                {
                    wordArray[j] = " _ ";
                }
                foreach (string s in wordArray)
                {
                    Console.Write(s);
                }
                Console.WriteLine();
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("\nGissa på en bokstav eller hela ordet. " + (10 - i) + " försök kvar.");
                    string userInput = Console.ReadLine().ToLower();
                    if (userInput.Length == 1)
                    {
                        CheckLetter(userInput);
                    }
                    else if(userInput == secretWord)
                    {
                        Console.WriteLine("Grattis! Du lyckades gissa rätt ord (" + secretWord + ") på " + i + " försök!");
                    }
                }
                Console.WriteLine("\nDu lyckades inte gissa rätt ord på 10 gissningar!\nVill du prova igen? (j/n)");
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
        static string CheckLetter(string userGuessLetter)
        {

            return userGuessLetter;
        }
    }
}
