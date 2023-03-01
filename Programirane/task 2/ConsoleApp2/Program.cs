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
            string n = Console.ReadLine();
            int total = 0;
            for (int i = 0; i < n.Length; i++)
            {
                total = total + (n[i] - '0');
            }
            Console.WriteLine(total);
            Console.ReadLine();
               
        }
    }
}
