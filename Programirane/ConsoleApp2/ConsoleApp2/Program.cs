

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
            string input = Console.ReadLine();
            var numbers= input.Split(' ').Select(x=>double.Parse(x)).ToList();
            var result = new Dictionary<double, int>();

            foreach (var num in numbers) 
            {
                if (result.ContainsKey(num))
                {
                    result[num] += 1;
                }
                else
                {
                    result[num] = 1;
                }              
                           }


            foreach (var kvp in result)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value} ");
            }


            Console.ReadLine(); 
        }
    }
}
