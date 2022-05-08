using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var text = "Number: ";

        for (var a = 1; a < 10; a++)
        {
            Console.WriteLine(text + a);
            Console.ReadKey();
        }
    }
}
