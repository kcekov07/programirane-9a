using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "1,2,5,7,8,9,0,-12,43,24";
            int[] numbers = new int[10]; // assuming there are 10 integers in the string
            int currentIndex = 0;
            int startIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ',')
                {
                    string numberString = input.Substring(startIndex, i - startIndex);
                    int number = 0;
                    for (int j = 0; j < numberString.Length; j++)
                    {
                        int digit = numberString[j] - '0';
                        number = number * 10 + digit;
                    }
                    numbers[currentIndex] = number;
                    currentIndex++;
                    startIndex = i + 1;
                }
            }

            string lastNumberString = input.Substring(startIndex);
            int lastNumber = 0;
            for (int j = 0; j < lastNumberString.Length; j++)
            {
                int digit = lastNumberString[j] - '0';
                lastNumber = lastNumber * 10 + digit;
            }
            Console.WriteLine(numbers[currentIndex] = lastNumber);
            Console.ReadLine();
        }
    }
}
