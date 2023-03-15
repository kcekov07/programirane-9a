using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "1,2,5,7,8,9,0,-12,43,24";
            int[] numbers = new int[10]; // assuming there are 10 integers in the string
            int currentIndex = 0;
            int currentNumber = 0;
            bool isNegative = false;

            // Parse each integer from the input string
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (c == '-')
                {
                    isNegative = true;
                }
                else if (c >= '0' && c <= '9')
                {
                    int digit = c - '0';
                    currentNumber = currentNumber * 10 + digit;
                }
                else if (c == ',')
                {
                    if (isNegative)
                    {
                        currentNumber = -currentNumber;
                        isNegative = false;
                    }
                    numbers[currentIndex] = currentNumber;
                    currentIndex++;
                    currentNumber = 0;
                }
            }
            // Parse the last integer in the input string
            if (isNegative)
            {
                currentNumber = -currentNumber;
            }
            numbers[currentIndex] = currentNumber;

            // Increment even numbers by 1 and odd numbers by 2
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    numbers[i] += 1;
                }
                else
                {
                    numbers[i] += 2;
                }
            }

            // Print the array separated by commas
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write(numbers[i]);
                if (i < numbers.Length - 1)
                {
                    Console.Write(",");
                }
            }
            Console.ReadLine();
        }
    }
}
