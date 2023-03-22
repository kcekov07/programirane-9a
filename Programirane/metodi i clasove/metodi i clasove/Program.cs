using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodi_i_clasove
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {


                Console.WriteLine("Избери опция:");
                Console.WriteLine("==============");
                Console.WriteLine("1)GetSum");
                Console.WriteLine("2)GetSumofallNumbers");
                Console.WriteLine("3)MakeArrayofNumsBetween");
                Console.WriteLine("4)PrintOddNUmbersBetween");
                Console.WriteLine("5)PrintEvenNumsBetween");
                string options = Console.ReadLine();
                Console.WriteLine("Въведете стойности");
                Console.WriteLine("===============");
                int a = int.Parse(Console.ReadLine());
                int b = int.Parse(Console.ReadLine());

                if (options == "1")
                {
                    Console.WriteLine(Class1.GetSum(a, b));
                }
                else if (options == "2")
                {
                    Console.WriteLine(Class1.GetSumofallNumbers(a, b));
                }
                else if (options == "3")
                {
                    int[] result = Class1.MakeArrayofNumsBetween(a, b);
                    Console.WriteLine(string.Join(",", result));
                }
                else if (options == "4")
                {
                    Class1.PrintOddNUmbersBetween(a, b);

                }
                else if (options == "5")
                {
                    Class1.PrintEvenNumsBetween(a, b);
                }

            }

        }


    }
       
}
