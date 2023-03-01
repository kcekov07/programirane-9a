using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace convert_meters_to_kilometres
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            double meters = double.Parse(Console.ReadLine());
            double km = meters /1000;
            Console.WriteLine($"{km:F2}") ;

            Console.ReadLine();
        }
    }
}
