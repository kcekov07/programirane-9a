using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace metodi_i_clasove
{
    public class Class1
    {
        public static int GetSum(int a, int b)
        {

            int result = a + b;
            return result;
        }
         public static int GetSumofallNumbers(int a, int b)
        {
            int sum = 0;
            for (int i = a + 1; i < b; i++)
            {
                sum += i;
            }

            return sum;
        }
        public static int[] MakeArrayofNumsBetween(int a, int b)
        {
            int[] array = new int[b - a + 1];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = a + i;
            }

            return array;
        }
        public static void PrintOddNUmbersBetween(int a, int b)
        {
            for (int i = a; i < b; i++)
            {
                if (i % 2 != 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        public static void PrintEvenNumsBetween(int a, int b)
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

