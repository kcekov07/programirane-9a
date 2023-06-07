using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_4
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();

            string input;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] productData = input.Split();
                string name = productData[0];
                decimal price = decimal.Parse(productData[1]);
                int quantity = int.Parse(productData[2]);

                if (products.ContainsKey(name))
                {
                    Product product = products[name];
                    product.Price = price;
                    product.Quantity += quantity;
                }
                else
                {
                    Product product = new Product
                    {
                        Name = name,
                        Price = price,
                        Quantity = quantity
                    };
                    products[name] = product;
                }
            }

            foreach (var product in products.Values)
            {
                decimal totalPrice = product.Price * product.Quantity;
                Console.WriteLine($"{product.Name} -> {totalPrice:f2}");
            }
            Console.ReadLine();
        }

        class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
        }
    }
}
