using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int total = 0;
            while (n != 0) 
            {
                total += n % 10;
                n = n / 10;
            }
            Console.WriteLine(total);
        }
    }
}
