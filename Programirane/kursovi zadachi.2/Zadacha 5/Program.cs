using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_5
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<string> inputs = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                inputs.Add(input);
            }

            Dictionary<string, string> database = ProcessCommands(inputs);

            PrintDatabase(database);
            Console.ReadLine(); 
        }

        static Dictionary<string, string> ProcessCommands(List<string> inputs)
        {
            Dictionary<string, string> database = new Dictionary<string, string>();

            foreach (string input in inputs)
            {
                string[] command = input.Split();
                string action = command[0];
                string username = command[1];

                if (action == "register")
                {
                    string licensePlateNumber = command[2];
                    Register(database, username, licensePlateNumber);
                }
                else if (action == "unregister")
                {
                    Unregister(database, username);
                }
            }

            return database;
        }

        static void Register(Dictionary<string, string> database, string username, string licensePlateNumber)
        {
            if (database.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: already registered with plate number {database[username]}");
            }
            else
            {
                database[username] = licensePlateNumber;
                Console.WriteLine($"{username} registered {licensePlateNumber} successfully");
            }
        }

        static void Unregister(Dictionary<string, string> database, string username)
        {
            if (!database.ContainsKey(username))
            {
                Console.WriteLine($"ERROR: user {username} not found");
            }
            else
            {
                database.Remove(username);
                Console.WriteLine($"{username} unregistered successfully");
            }
        }

        static void PrintDatabase(Dictionary<string, string> database)
        {
            foreach (var entry in database)
            {
                Console.WriteLine($"{entry.Key} => {entry.Value}");
            }
        }
    }
}