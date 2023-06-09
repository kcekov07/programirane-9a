using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zadacha_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>()
        {
            { "shards", 0 },
            { "fragments", 0 },
            { "motes", 0 }
        };

            SortedDictionary<string, int> junkItems = new SortedDictionary<string, int>();

            string obtainedItem = "";

            while (obtainedItem == "")
            {
                string[] input = Console.ReadLine().Split(' ');

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1].ToLower();

                    if (keyMaterials.ContainsKey(material))
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            obtainedItem = material;
                            keyMaterials[material] -= 250;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkItems.ContainsKey(material))
                            junkItems[material] = 0;

                        junkItems[material] += quantity;
                    }
                }
            }

            PrintResults(obtainedItem, keyMaterials, junkItems);
            Console.ReadLine();
        }

        static void PrintResults(string obtainedItem, Dictionary<string, int> keyMaterials, SortedDictionary<string, int> junkItems)
        {
            var prizes = new Dictionary<string, string>  {
            { "shards", "Shadowmourne" },
            { "fragments", "Valanyr" },
            { "motes", "Dragonwrath" }
        };


            Console.WriteLine($"{prizes[obtainedItem]} obtained!");

            var remainingMaterials = keyMaterials
                .OrderByDescending(m => m.Value)
                .ThenBy(m => m.Key)
                .ToList();

            foreach (var material in remainingMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            foreach (var item in junkItems)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
