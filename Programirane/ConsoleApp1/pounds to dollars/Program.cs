﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pounds_to_dollars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Pounds = ");
            double pounds = double.Parse(Console.ReadLine());
            double dollars = pounds * 1.31;
            Console.WriteLine(dollars);

            Console.ReadLine();
        }
    }
}
