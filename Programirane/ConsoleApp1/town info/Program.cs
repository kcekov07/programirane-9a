using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace town_info
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nameofcity = Console.ReadLine();
            int population = int.Parse(Console.ReadLine());
            int square = int.Parse(Console.ReadLine());

            Console.WriteLine($"Town {nameofcity} has population of {population} and area {square}square km");

            
        }
    }
}
