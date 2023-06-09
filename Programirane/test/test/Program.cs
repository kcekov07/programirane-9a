using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var products = new Dictionary<string, int>();
            products.Add("Printer",3 );
            products.Add("WashingMashine", 1);
            products.Add("Books", 4);
            products.Add("Bottle", 7);
            products.Add("Car ", 4);
            products.Add("Quitar", 5);
            products.Add("Screwdriver", 3);
            products.Add("Bananas", 16);
            products.Add("Slingshot", 2);

            foreach(KeyValuePair<string, int> item in products)
            {
                Console.WriteLine("Item:{0},Quantity:{1}",item.Key,item.Value);
            }

            Console.ReadLine();
        }
    }
}
