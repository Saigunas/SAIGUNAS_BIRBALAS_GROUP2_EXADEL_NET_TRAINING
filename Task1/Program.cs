using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main(string[] args)
    {
        var a = 1;
        var text = "Number: ";

        for (; a < 10; a++)
        {
            Console.WriteLine(text + a);
            Console.ReadKey();
        }
    }
}