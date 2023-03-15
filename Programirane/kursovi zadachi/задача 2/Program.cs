using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace задача_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceOver20kg = double.Parse(Console.ReadLine());
            double weight = double.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());
            int bagsCount = int.Parse(Console.ReadLine());

            double price = 0;

            if (weight <= 10)
            {
                price = 0.2 * priceOver20kg;
            }
            else if (weight <= 20)
            {
                price = 0.5 * priceOver20kg;
            }
            else
            {
                price = double.Parse(Console.ReadLine());
            }

            if (days > 30)
            {
                price *= 1.1;
            }
            else if (days >= 7)
            {
                price *= 1.15;
            }
            else
            {
                price *= 1.4;
            }

            price *= bagsCount;

            Console.WriteLine($"The total price of bags is: {price:f2} lv.");
            Console.ReadLine();
        }
    }
}
