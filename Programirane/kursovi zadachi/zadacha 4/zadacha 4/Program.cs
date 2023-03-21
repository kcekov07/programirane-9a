using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadacha_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int totalPoints = 0;
            int redBalls = 0;
            int orangeBalls = 0;
            int yellowBalls = 0;
            int whiteBalls = 0;
            int otherColors = 0;
            int dividedBlackBalls = 0;

            for (int i = 0; i < n; i++)
            {
                string color = Console.ReadLine();

                switch (color)
                {
                    case "red":
                        redBalls++;
                        totalPoints += 5;
                        break;
                    case "orange":
                        orangeBalls++;
                        totalPoints += 10;
                        break;
                    case "yellow":
                        yellowBalls++;
                        totalPoints += 15;
                        break;
                    case "white":
                        whiteBalls++;
                        totalPoints += 20;
                        break;
                    case "black":
                        dividedBlackBalls++;
                        totalPoints /= 2;
                        break;
                    default:
                        otherColors++;
                        break;
                }
            }

            Console.WriteLine($"Total points: {totalPoints}");
            Console.WriteLine($"Red balls: {redBalls}");
            Console.WriteLine($"Orange balls: {orangeBalls}");
            Console.WriteLine($"Yellow balls: {yellowBalls}");
            Console.WriteLine($"White balls: {whiteBalls}");
            Console.WriteLine($"Other colors picked: {otherColors}");
            Console.WriteLine($"Divides from black balls: {dividedBlackBalls}");
            Console.ReadLine();
        }
    }
}
