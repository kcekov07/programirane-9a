using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadacha_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int startFirst = start / 1000;
            int startSecond = (start / 100) % 10;
            int startThird = (start / 10) % 10;
            int startFourth = start % 10;

            int endFirst = end / 1000;
            int endSecond = (end / 100) % 10;
            int endThird = (end / 10) % 10;
            int endFourth = end % 10;

            for (int i = startFirst; i <= endFirst; i++)
            {
                for (int j = startSecond; j <= endSecond; j++)
                {
                    for (int k = startThird; k <= endThird; k++)
                    {
                        for (int l = startFourth; l <= endFourth; l++)
                        {
                            if (i % 2 != 0 && j % 2 != 0 && k % 2 != 0 && l % 2 != 0)
                            {
                                Console.Write($"{i}{j}{k}{l} ");
                            }
                        }
                    }
                }
            }
            Console.ReadLine(       );
    }   }
}
