using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadacha_3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int window = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            string delivery = Console.ReadLine();

            double price = 0;

            if (window < 10)
            {
                Console.WriteLine("Invalid order");
                Console.ReadLine();
                return; 
            }

            if (type == "90X130")
            {
                price = window * 110;
                if (window > 30 && window < 60)
                {
                    price = price - (price * 0.05);
                }
                else if (window > 60)
                {
                    price -= (price * 0.08);
                }
            }
            else if (type == "100X150")
            {
                price = window * 140;
                if (window > 40 && window < 80)
                {
                    price = price * (1 - 0.06);
                }
                else if (window > 80)
                {
                    price = price * (1 - 0.10);
                }
            }
            else if (type == "130X180")
            {
                price = window * 190;
                if (window > 20 && window < 50)
                {
                    price = price - (price * 0.07);
                }
                else if (window > 50)
                {
                    price = price - (price * 0.12);
                }
            }
            else if (type == "200X300")
            {
                price = window * 250;
                if (window > 25 && window < 50)
                {
                    price = price - (price * 0.09);
                }
                else if (window > 50)
                {
                    price = price - (price * 0.14);
                }
            }

            if (delivery == "With delivery")
            {
                price += 60;
            }

            if (window > 99)
            {
                price *= (1 - 0.04);
            }

            Console.WriteLine($"{price:f2} BGN");

            Console.ReadLine();
        }
    }
}

    

