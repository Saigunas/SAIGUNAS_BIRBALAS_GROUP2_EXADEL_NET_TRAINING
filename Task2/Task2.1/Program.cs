using System;

public class Program
{

    private const int _roundDecimal = 2;

    public static void Main(string[] args)
    {
        int inputA, inputB;

        while (true)
        {
            Console.Write("Input a: ");
            inputA = int.Parse(Console.ReadLine());


            if (inputA >= 0 && inputA <= 5)
            {
                break;
            }
            Console.WriteLine("Variable 'a' must be in the range 0 <= a <= 5");
        }

        while (true)
        {
            Console.Write("Input b: ");
            inputB = int.Parse(Console.ReadLine());

            if (inputB >= 0 && inputB <= 100)
            {
                break;
            }
            Console.WriteLine("Variable “b” must be in the range 0 <= b <= 100");
        }


        var program = new Program();

        program.OutputValues(program.GetFactorial(inputA), program.GetNaturalLog(inputB));
    }

    private double GetFactorial(int number)
    {
        double factorial = 1;
        for (int i = number; i > 0; i--)
        {
            factorial *= i;
        }

        factorial *= 0.05;
        factorial = Math.Round(factorial, _roundDecimal);

        return factorial;
    }

    private double GetNaturalLog(int number)
    {
        double naturalLog = Math.Log(number);
        naturalLog = Math.Round(naturalLog, _roundDecimal);

        return naturalLog;
    }

    private void OutputValues(double numberA, double numberB)
    {

        /*
         * Numbers are already formatted to 2 decimals, but 'ToString' ensures that whole numbers are displayed with .00 (e.g. 1.00)
         */

        Console.Write($"\nNumber 'a' = {numberA.ToString("0.00")} and ");

        if (numberA < numberB)
        {
            Console.Write("less than");
        }
        if (numberA > numberB)
        {
            Console.Write("more than");
        }
        if (numberA == numberB)
        {
            Console.Write("equals");
        }

        Console.Write($" number 'b' = {numberB.ToString("0.00")}\n");
    }
}
