using System;

namespace HangmanGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int maxAttempts = 10; 
            Console.WriteLine("Wisielec");
            Console.WriteLine("0. Wyjdź");
            Console.WriteLine("Wybierz poziom trudności:");
            Console.WriteLine("1. Łatwy 10 prób");
            Console.WriteLine("2. Średni 5 prób");
            Console.WriteLine("3. Trudny 2 próby");

            int Level = int.Parse(Console.ReadLine());

            if (Level == 0)
            {
                Console.WriteLine("Żegnaj :(");
                return;
            }
            else if (Level < 1 || Level > 3)
            {
                Console.WriteLine("Nie ma takiego poziomu zaczniemy od łatwego");
            }
            else
            {
                switch (Level)
                {
                    case 1:
                        maxAttempts = 10;
                        break;
                    case 2:
                        maxAttempts = 5;
                        break;
                    case 3:
                        maxAttempts = 2;
                        break;
                }
            }

            bool playAgain = true;

            while (playAgain)
            {
                string[] words = { "winda", "stół", "komputer", "obiekt", "programowanie", "kotlet", "szachy", "warcaby", "informatyka", "fizyka", "grzegrzółka", "skarpetka", "wyperswadować", "kebab", "dewolaj", "katowice", "podkładka", "zmywarka" };
                Random random = new Random();
                string wordGuess = words[random.Next(0, words.Length)];
                char[] guessedLetters = new char[wordGuess.Length];

                for (int i = 0; i < guessedLetters.Length; i++)
                {
                    guessedLetters[i] = '_';
                }

                int attempts = 0;
                bool wordGuessed = false;

                while (!wordGuessed && attempts < maxAttempts)
                {
                    Console.WriteLine("\nLiczba prób: " + (maxAttempts - attempts));
                    Console.WriteLine("Hasło: " + new string(guessedLetters));

                    Console.Write("Wpisz 0 aby wyjść: ");
                    char letter = Console.ReadLine()[0];

                    if (letter == '0')
                    {
                        Console.WriteLine("żegnaj :(");
                        return;
                    }

                    bool letterFound = false;
                    for (int i = 0; i < wordGuess.Length; i++)
                    {
                        if (wordGuess[i] == letter)
                        {
                            guessedLetters[i] = letter;
                            letterFound = true;
                        }
                    }

                    if (!letterFound)
                    {
                        attempts++;
                        Console.WriteLine("ŹLE!");
                    }

                    if (new string(guessedLetters) == wordGuess)
                    {
                        wordGuessed = true;
                    }
                }

                if (wordGuessed)
                {
                    Console.WriteLine("\nUdało ci się odgadnąć hasło gratulacje!!!!!!: " + wordGuess);
                }
                else
                {
                    Console.WriteLine("\nPorażka. Twoim hasłem było: " + wordGuess);
                }

                Console.Write("\nChcesz zagrać jeszcze raz? (t/n): ");
                char choice = Console.ReadLine()[0];

                if (choice != 't' && choice != 'T')
                {
                    playAgain = false;
                    Console.WriteLine("Żegnaj!");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}