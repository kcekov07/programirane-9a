public class Program
{
    public static void Main()
    {
        Console.WriteLine("Input 3 words");
        Console.Write("Input first word:");
        string w1 = Console.ReadLine();
        Console.Write("Input second word:");
        string w2 = Console.ReadLine();
        Console.Write("Input third word:");
        string w3 = Console.ReadLine();

        Console.Write("Which Word Do You Like?(1,2,3) ");
        var w = int.Parse(Console.ReadLine());

        if (w == 1)
        {
            Console.WriteLine("Your Word Is " + w1);
        }
        if (w == 2)
        {
            Console.WriteLine("Your Word Is " + w2);
        }
        if (w == 3)
        {
            Console.WriteLine("Your Word Is " + w3);
        }



    }


}

