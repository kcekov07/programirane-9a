using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha_za_povishavane
{
    internal class Program
    {
        static void Main()
        {
            string encryptedMessage = Console.ReadLine();
            string command = Console.ReadLine();

            while (command != "Decode")
            {
                string[] commandArgs = command.Split('|');
                string operation = commandArgs[0];

                switch (operation)
                {
                    case "Move":
                        int numberOfLetters = int.Parse(commandArgs[1]);
                        encryptedMessage = MoveLetters(encryptedMessage, numberOfLetters);
                        break;
                    case "Insert":
                        int index = int.Parse(commandArgs[1]);
                        string value = commandArgs[2];
                        encryptedMessage = InsertValue(encryptedMessage, index, value);
                        break;
                    case "ChangeAll":
                        string substring = commandArgs[1];
                        string replacement = commandArgs[2];
                        encryptedMessage = ReplaceSubstring(encryptedMessage, substring, replacement);
                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine($"The decrypted message is: {encryptedMessage}");
            Console.ReadLine();
        }

        static string MoveLetters(string message, int numberOfLetters)
        {
            numberOfLetters %= message.Length;
            string firstPart = message.Substring(0, numberOfLetters);
            string secondPart = message.Substring(numberOfLetters);
            return secondPart + firstPart;
        }

        static string InsertValue(string message, int index, string value)
        {
            return message.Insert(index, value);
        }

        static string ReplaceSubstring(string message, string substring, string replacement)
        {
            return message.Replace(substring, replacement);
        }
       
    }
}
