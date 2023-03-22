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
                    Console.WriteLine(GetSum(a, b));
                }
                else if (options == "2")
                {
                    Console.WriteLine(GetSumofallNumbers(a, b));
                }
                else if (options == "3")
                {
                    int[] result = MakeArrayofNumsBetween(a, b);
                    Console.WriteLine(string.Join(",", result));
                }
                else if (options == "4")
                {
                    PrintOddNUmbersBetween(a, b);

                }
                else if (options == "5")
                {
                    PrintEvenNumsBetween(a, b);
                }

            }
                Console.ReadLine();
        }



        static int GetSum(int a, int b)
        {

            int result = a + b;
            return result;
        }
        static int GetSumofallNumbers(int a, int b)
        {
            int sum = 0;
            for (int i = a + 1; i < b; i++)
            {
                sum += i;
            }

            return sum;
        }
        static int[] MakeArrayofNumsBetween(int a, int b)
        {
            int[] array = new int[b - a + 1];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = a + i;
            }

            return array;
        }
        static void PrintOddNUmbersBetween(int a, int b)
        {
            for (int i = a; i < b; i++)
            {
                if(i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        static void PrintEvenNumsBetween(int a, int b)
        {
            for (int i = a; i < b; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
