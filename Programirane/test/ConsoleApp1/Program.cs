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
            Dictionary<string,int> products1 = new Dictionary<string,int>();
            products1["book"] = 1;
            products1["car"] = 1;
            products1["Printer"] = 1;

            if (!products1.ContainsValue(1))
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                foreach (var kv in products1 )
                {
                    if (kv.Value == 1)
                    {
                        Console.WriteLine(kv.Key);
                    }
                }
            }
           
            Console.ReadLine();
        }
    }
}
