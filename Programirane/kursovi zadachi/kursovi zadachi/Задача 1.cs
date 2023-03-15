using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovi_zadachi
{
    internal class Program
    {
        static void Main(string[] args)
        {



            string airlineName = Console.ReadLine();
            int adultTickets = int.Parse(Console.ReadLine());
            int childTickets = int.Parse(Console.ReadLine());
            double adultTicketPrice = double.Parse(Console.ReadLine());
            double serviceFee = double.Parse(Console.ReadLine());

            double childTicketPriceots = 0.7 * adultTicketPrice;
            double childTicketPrice = adultTicketPrice - childTicketPriceots;
            double adultTicketTotalPrice = adultTicketPrice + serviceFee;
            double childTicketTotalPrice = childTicketPrice + serviceFee;

            double adultTicketsTotal = adultTickets * adultTicketTotalPrice;
            double childTicketsTotal = childTickets * childTicketTotalPrice;

            double totalProfit = adultTicketsTotal + childTicketsTotal;
            double agencyProfit = 0.2 * totalProfit;

            Console.WriteLine("The profit of your agency from {0} tickets is {1:F2} lv.", airlineName, agencyProfit);
            Console.ReadLine();
        }
    }
}

        
    
    

