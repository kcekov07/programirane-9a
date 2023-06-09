using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovi_zadachi._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a string:");
            string input = Console.ReadLine();

            Dictionary<char, int> charCounts = CountCharacters(input);

            Console.WriteLine("Character Counts:");
            foreach (KeyValuePair<char, int> kvp in charCounts)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
            Console.ReadLine();
        }

        static Dictionary<char, int> CountCharacters(string input)
        {
            Dictionary<char, int> charCounts = new Dictionary<char, int>();

            foreach (char c in input)
            {
                if (c != ' ')
                {
                    if (charCounts.ContainsKey(c))
                    {
                        charCounts[c]++;
                    }
                    else
                    {
                        charCounts[c] = 1;
                    }
                }
            }

            return charCounts;
           
        }

       
    }
   
}
