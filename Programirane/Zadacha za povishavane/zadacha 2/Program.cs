using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace zadacha_2
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            string pattern = @"([#|])([A-Za-z\s]+)\1(\d{2}\/\d{2}\/\d{2})\1(\d+)\1";
            MatchCollection matches = Regex.Matches(input, pattern);

            int totalCalories = 0;
            List<FoodItem> foodItems = new List<FoodItem>();

            foreach (Match match in matches)
            {
                string itemName = match.Groups[2].Value;
                string expirationDate = match.Groups[3].Value;
                int calories = int.Parse(match.Groups[4].Value);

                FoodItem foodItem = new FoodItem(itemName, expirationDate, calories);
                foodItems.Add(foodItem);

                totalCalories += calories;
            }

            int days = totalCalories / 2000;
            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (FoodItem foodItem in foodItems)
            {
                Console.WriteLine(foodItem.ToString());
            }
            Console.ReadLine();
        }
    }

    class FoodItem
    {
        public string ItemName { get; }
        public string ExpirationDate { get; }
        public int Calories { get; }

        public FoodItem(string itemName, string expirationDate, int calories)
        {
            ItemName = itemName;
            ExpirationDate = expirationDate;
            Calories = calories;
        }

        public override string ToString()
        {
            return $"Item: {ItemName}, Best before: {ExpirationDate}, Nutrition: {Calories}";
        }
    }
}
