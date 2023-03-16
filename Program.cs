using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadacha_4
{
    internal class Program
    {
        
        
            static void Main(string[] args)
            {
                Random random = new Random();
                int randomNumber = random.Next(1, 101);
                int numberOfGuesses = 0;
                bool isGameOver = false;

                Console.WriteLine("Welcome to the guessing game!");
                Console.WriteLine("I am thinking of a number between 1 and 100.");
                Console.WriteLine("You have 5 tries to guess the number.");

                while (!isGameOver && numberOfGuesses < 5)
                {
                    Console.Write("Guess the number: ");
                    string input = Console.ReadLine();
                    int guess;
                    if (int.TryParse(input, out guess))
                    {
                        numberOfGuesses++;
                        if (guess < randomNumber)
                        {
                            Console.WriteLine("Your guess is too low.");
                        }
                        else if (guess > randomNumber)
                        {
                            Console.WriteLine("Your guess is too high.");
                        }
                        else
                        {
                            Console.WriteLine("Congratulations! You guessed the number in {0} tries.", numberOfGuesses);
                            isGameOver = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }
                }

                if (!isGameOver)
                {
                    Console.WriteLine("Sorry, you did not guess the number. The number was {0}.", randomNumber);
                }

                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
            }
        

    }
}

