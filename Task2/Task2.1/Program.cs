using System;

public class Program
{

    const int roundDecimal = 2;

    public static void Main(string[] args)
    {
        int a, b;

        while (true)
        {
            Console.Write("Input a: ");
            a = int.Parse(Console.ReadLine());


            if (a >= 0 && a <= 5)
            {
                break;
            }
            Console.WriteLine("Variable 'a' must be in the range 0 <= a <= 5");
        }

        while (true)
        {
            Console.Write("Input b: ");
            b = int.Parse(Console.ReadLine());

            if (b >= 0 && b <= 100)
            {
                break;
            }
            Console.WriteLine("Variable “b” must be in the range 0 <= b <= 100");
        }


        var program = new Program();

        program.outputValues(program.getFactorial(a), program.getNaturalLog(b));
    }

    private double getFactorial(int a)
    {
        double factorial = 1;
        for (int i = a; i > 0; i--)
        {
            factorial *= i;
        }

        factorial *= 0.05;
        factorial = Math.Round(factorial, roundDecimal);

        return factorial;
    }

    private double getNaturalLog(int b)
    {
        double naturalLog = Math.Log(b);
        naturalLog = Math.Round(naturalLog, roundDecimal);

        return naturalLog;
    }

    private void outputValues(double a, double b)
    {

        /*
         * Numbers are already formatted to 2 decimals, but 'ToString' ensures that whole numbers are displayed with .00 (e.g. 1.00)
         */

        Console.Write($"\nNumber 'a' = {a.ToString("0.00")} and ");

        if (a < b)
        {
            Console.Write("less than");
        }
        if (a > b)
        {
            Console.Write("more than");
        }
        if (a == b)
        {
            Console.Write("equals");
        }

        Console.Write($" number 'b' = {b.ToString("0.00")}\n");
    }
}
