using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadacha_5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bestPlayer = "";
            int bestPlayerGoals = 0;
            while (true)
            {
                string playerName = Console.ReadLine();
                if (playerName == "END")
                {
                    break;
                }
                int playerGoals = int.Parse(Console.ReadLine());
                if (playerGoals > bestPlayerGoals)
                {
                    bestPlayer = playerName;
                    bestPlayerGoals = playerGoals;
                }
                if (playerGoals >= 10)
                {
                    break;
                }
            }
            Console.WriteLine($"{bestPlayer} is the best player!");
            if (bestPlayerGoals >= 3)
            {
                Console.WriteLine($"He has scored {bestPlayerGoals} goals and made a hat-trick!!!");
            }
            else
            {
                Console.WriteLine($"He has scored {bestPlayerGoals} goals.");
            }
            Console.ReadLine();
        }
    }
}
