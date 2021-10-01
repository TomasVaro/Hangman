﻿using System;
using System.Collections.Generic;
using System.Text;

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
                string[] secretWords = {"Soffa", "Blåbär", "Gummi", "Trevlig", "Under", "Läser", "Programmering", "Lista", "Slumpmässigt", "Sätter",
                "Inlevelse", "Beskrivning", "Veckoslut", "Vinterdäck", "Långfärdsskridskor", "Grävutrustning", "Sparkcykel", "Norrsken", "Höstfärger", "Mandelblom",
                "Längtan", "Pensionerad", "Gammal", "Filosofisk", "Huvudled", "Riktlinjer", "Verkstad", "Vommen", "Ordvits", "Bohusleden"};
                Random rand = new Random();
                int index = rand.Next(secretWords.Length);
                string secretWord = secretWords[index].ToLower();
                StringBuilder incorrectLetters = new StringBuilder();
                StringBuilder lettersGuessed = new StringBuilder(null);
                char[] correctLettersArray = new char[secretWord.Length];
                correctLettersArray.AsSpan().Fill('_');
                Console.WriteLine("Hemliga ordet: " + string.Join(" ", correctLettersArray));
                int remainingGuesses;

                for (remainingGuesses = 10; remainingGuesses > 0; remainingGuesses--)
                {
                    Console.WriteLine("\nGissa på en bokstav eller hela ordet. " + remainingGuesses + " försök kvar.");
                    string userInput = Console.ReadLine().ToLower();
                    Console.Clear();
                    if (userInput.Length == 1)
                    {
                        bool check = true;
                        for (int j = 0; j < lettersGuessed.Length; j++)
                        {
                            if (lettersGuessed[j] == char.Parse(userInput))
                            {
                                Console.WriteLine("Du har redan gissat på denna bokstav (" + userInput + "). Försök igen!");
                                Console.WriteLine("Hemliga ordet: " + string.Join(" ", correctLettersArray));
                                Console.WriteLine("Du har gissat på följade felaktiga bokstäver: " + incorrectLetters);
                                remainingGuesses++;
                                check = false;
                                break;
                            }
                        }
                        if (check)
                        {
                            remainingGuesses = checkSecretWordUserInput(secretWord, userInput, correctLettersArray, lettersGuessed, incorrectLetters, remainingGuesses);
                            int count = 0;
                            for (int i = 0; i < correctLettersArray.Length; i++)
                            {
                                if (correctLettersArray[i] == '_')
                                {
                                    break;
                                }
                                else
                                {
                                    count++;
                                    if(count == correctLettersArray.Length)
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Grattis! Du lyckades gissa rätt ord (" + secretWord + ") på " + (10 - remainingGuesses) + " felaktiga försök!");
                                        remainingGuesses = 0;
                                    }
                                }
                            }
                        }
                    }
                    else if(userInput.Length == 0)
                    {
                        Console.WriteLine("Du skrev inte in något. Försök igen!");
                        Console.WriteLine("Hemliga ordet: " + string.Join(" ", correctLettersArray));
                        remainingGuesses++;
                    }
                    else if(userInput == secretWord)
                    {
                        Console.WriteLine("Grattis! Du lyckades gissa rätt ord (" + userInput + ") på " + (10 - remainingGuesses) + " felaktiga försök!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ordet du angav var inte rätt ord!\n"); 
                        Console.WriteLine("Hemliga ordet: " + string.Join(" ", correctLettersArray));
                        Console.WriteLine("Du har gissat på följade felaktiga bokstäver: " + incorrectLetters);
                    }
                }
                if(remainingGuesses == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Du lyckades inte gissa rätt ord (" + secretWord + ") på 10 gissningar!");
                }

                Console.WriteLine("\nVill du prova igen? (j/n)");
                while (true)
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
                        break;
                    }
                }
            }
        }

        static int checkSecretWordUserInput(string secretWord, string userInput, char[] correctLettersArray, StringBuilder lettersGuessed, StringBuilder incorrectLetters, int remainingGuesses)
        {
            lettersGuessed.Append(userInput);
            bool run = true;
            int count = 0;
            for(int i = 0; i < secretWord.Length; i++)
            {
                if (secretWord[i] == char.Parse(userInput))
                {
                    correctLettersArray[i] = char.Parse(userInput);
                    if(incorrectLetters.Length > 0 && count < 1 && i != 0)
                    {
                        incorrectLetters.Length--;
                        remainingGuesses++;
                    }
                    count++;
                    run = false;
                }
                else if(run)
                {
                    incorrectLetters.Append(userInput);
                    run = false;
                }
            }
            Console.WriteLine("Hemliga ordet: " + string.Join(" ", correctLettersArray));
            Console.WriteLine("Du har gissat på följade felaktiga bokstäver: " + incorrectLetters);            
            return remainingGuesses;
        }
    }
}
