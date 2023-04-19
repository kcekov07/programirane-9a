using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many peopele are in the boat");
            int n = int.Parse(Console.ReadLine());
            Person[] arr = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(',');
                Person person = new Person();
                person.FirstName = input[0];
                person.LastName = input[1];
                person.Age = int.Parse(input[2]);
                person.Adress = input[3];
                arr[i] = person;


            }

            Console.WriteLine("Whose information do you want?");
            int index = int.Parse(Console.ReadLine());
            if (index >= 0 && index < arr.Length)
            {
                Person requestedPerson = arr[index];
                requestedPerson.WriteInfo();
            }
            else
            {
                Console.WriteLine("Gledai si rabotata");
            }
            Console.ReadLine();


        }


    }
    public class Person
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }

        public void WriteInfo()
        {
            Console.WriteLine($"I am {FirstName[0]}. {LastName}.I am {Age} years old and I live in {Adress}");
        }

    }
}
