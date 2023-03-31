using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace @class
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p1= new Person();
            p1.Name = "Asen";
            p1.Age = 16;

            Person p2 = new Person();
            p2.Name = "nikola";
            p2.Age = 18;

            Person p3= new Person();
            p3.Name = "nikola";
            p3.Age = 18;

            p1.AgeUp();
            p1.AgeUp();

            Person[] people = {p1,p2,p3};
            for (int i = 0; i < people.Length; i++)
            {
                if (people[i].Age<18)
                {
                people[i].AgeUp();
                }
            }
            p1.RecordMyId("dwdwdwdw");
            p1.PrintMyId();

            Console.ReadLine();
        }
    }
}
public class Person
{
    private string Id = "";
    public string Name { get; set; }
    public int Age { get; set; } = 10;

    public void AgeUp ()
    {
        Age++;
        Console.WriteLine($"{Name} aged up and now is {Age} years old");
    }
    public void PrintMyId()
    {
        Console.WriteLine("*****"+Id.Substring(3,4)+"*****");
    }
    public void RecordMyId(string id)
    {
       Id = id;
    }
}
