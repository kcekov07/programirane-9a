using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace masivi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the array elements: ");
            string[] inputArr = Console.ReadLine().Split();
            int[] arr = Array.ConvertAll(inputArr, int.Parse);
            Console.Write("Enter the number of rotations: ");
            int rotations = int.Parse(Console.ReadLine());

            
            Console.WriteLine("Original array:");
            PrintArray(arr);

          
            int n = arr.Length;
            rotations %= n;
            for (int i = 0; i < rotations; i++)
            {
                int first = arr[0];
                for (int j = 0; j < n - 1; j++)
                {
                    arr[j] = arr[j + 1];
                }
                arr[n - 1] = first;
            }

            
            Console.WriteLine("Rotated array:");
            PrintArray(arr);
        }

        static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }


    }

    
}

