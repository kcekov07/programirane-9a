using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace КОНТРОЛНА_РАБОТА_ПО_УВОД_В_ООП
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var cars = new List<Car>();

            Console.WriteLine("Input Car Data");                                                                                                                                                                       

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] data = input.Split('-');

                var car = new Car
                {
                    Manufacturer = data[0],
                    Model = data[1],
                    Color = data[2],
                    Year = int.Parse(data[3]),
                    FuelType = data[4],
                    PriceBGN = decimal.Parse(data[5])
                };

                cars.Add(car);
            }

            while (true)
            {
                Console.WriteLine("Select Command");

                string command = Console.ReadLine();

                if (command == "Exit")
                {
                    Console.WriteLine("Goodbye");
                    break;
                }

                string[] data = command.Split(' ');

                switch (data[0])
                {
                    case "MinPrice":
                        decimal minPrice = decimal.Parse(data[1]);
                        foreach (var car in cars)
                        {
                            if (car.PriceBGN >= minPrice)
                            {
                                Console.WriteLine(car);
                            }
                        }
                        break;

                    case "MaxPrice":
                        decimal maxPrice = decimal.Parse(data[1]);
                        foreach (var car in cars)
                        {
                            if (car.PriceBGN <= maxPrice)
                            {
                                Console.WriteLine(car);
                            }
                        }
                        break;

                    case "MinYear":
                        int minYear = int.Parse(data[1]);
                        foreach (var car in cars)
                        {
                            if (car.Year >= minYear)
                            {
                                Console.WriteLine(car);
                            }
                        }
                        break;

                    case "Manufacturer":
                        string manufacturer = data[1];
                        foreach (var car in cars)
                        {
                            if (car.Manufacturer == manufacturer)
                            {
                                Console.WriteLine(car);
                            }
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
            Console.ReadLine();
        }   } 
    class Car
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
        public string FuelType { get; set; }
        public decimal PriceBGN { get; set; }

        public override string ToString()
        {
            return $"{Color} {Manufacturer} {Model} {Year}: {PriceBGN:F2}";
        }
    }
}

