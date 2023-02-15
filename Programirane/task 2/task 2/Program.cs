using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int wagoncount = int.Parse(Console.ReadLine());
            int [] peopleInWagons = new int[wagoncount];
            int totalpeole = 0;

            for (int i = 0; i < wagoncount; i++)
            {
                peopleInWagons[i]= int.Parse(Console.ReadLine());
                totalpeole+= peopleInWagons[i];
            }

            Console.WriteLine(string.Join(" ",peopleInWagons));
            Console.WriteLine(totalpeole);


            

        }
    }
}
