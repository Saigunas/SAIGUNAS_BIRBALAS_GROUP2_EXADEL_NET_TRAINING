using System;
using System.Linq;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class Program
{
    public static async Task Main(string[] args)
    {
        string file1Path = "..\\..\\..\\file1.txt";
        string file2Path = "..\\..\\..\\file2.txt";

        List<string> fileList = new List<string>() { file1Path, file2Path };

        bool showMenu = true;
        while (showMenu)
        {
            Console.WriteLine("Select the option: ");
            Console.WriteLine("1. Run calculation asynchronously");
            Console.WriteLine("2. Run calculation using different threads");
            Console.WriteLine("3. Exit");

            int selection = Convert.ToInt32(Console.ReadLine());

            switch (selection)
            {
                case 1:
                    await RunCalculationAppAsync(fileList);
                    break;
                case 2:
                    RunCalulationAppMultithread(fileList);
                    break;
                case 3:
                    showMenu = false;
                    break;
                default:
                    Console.WriteLine("Wrong choice");
                    break;
            }
        }
    }

    public static void RunCalulationAppMultithread (List<string> fileList)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        List<string> calculationResults = new List<string>();
        List<Task<string>> tasks = new List<Task<string>>();

        Thread thread1 = new Thread(() => calculationResults.Add(ProcessFile(fileList[0], "1")));
        Thread thread2 = new Thread(() => calculationResults.Add(ProcessFile(fileList[1], "2")));

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();

        watch.Stop();

        var elapsedMs = watch.ElapsedMilliseconds;

        Console.WriteLine("Multihread method");
        Console.WriteLine($"Time: {elapsedMs}ms");
        foreach (string result in calculationResults)
        {
            Console.WriteLine(result);
        }
    }

    public static async Task RunCalculationAppAsync(List<string> fileList)
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();

        List<string> calculationResults = new List<string>();
        List<Task<string>> tasks = new List<Task<string>>();

        for (int i = 0; i < fileList.Count; i++)
        {
            int tempIndex = i;
            tasks.Add(Task.Run(() =>
                ProcessFile(fileList[tempIndex], (tempIndex + 1).ToString())
            ));
        }

        var results = await Task.WhenAll(tasks);

        foreach(var result in results)
        {
            calculationResults.Add(result);
        }

        watch.Stop();

        var elapsedMs = watch.ElapsedMilliseconds;

        Console.WriteLine("Asynchronous method");
        Console.WriteLine($"Time: {elapsedMs}ms");
        foreach (string result in calculationResults)
        {
            Console.WriteLine(result);
        }
    }

    public static string ProcessFile(string filePath, string fileName)
    {
        var lines = File.ReadAllLines(filePath);

        //Get numbers
        List<double> numbers = ExtractNumbers(lines[0]);

        //Get sign
        string sign = lines[1];

        //Apply calculation
        string calculationProcedure = CalculateNumbers(numbers, sign);
        return ($"Data from file {fileName}: {calculationProcedure}");
    }

    public static List<double> ExtractNumbers(string numberString)
    {
        List<double> numbers = new List<double>();
        numbers = numberString.Split(',').Select(Double.Parse).ToList();

        return numbers;
    }

    public static string CalculateNumbers(List<double> numbers, string sign)
    {
        string calculationProcedure = "";
        double calculatedNumber = numbers[0];
        switch (sign)
        {
            case "+":
                {
                    for (int i = 1; i < numbers.Count; i++)
                    {
                        calculationProcedure += numbers[i];
                        if(i + 1 < numbers.Count)
                        {
                            calculationProcedure += "+";
                        }

                        calculatedNumber += numbers[i];
                    }
                    break;
                }
            case "-":
                {
                    for (int i = 1; i < numbers.Count; i++)
                    {
                        calculationProcedure += numbers[i];
                        if (i + 1 < numbers.Count)
                        {
                            calculationProcedure += "-";
                        }

                        calculatedNumber -= numbers[i];
                    }
                    break;
                }
            case "*":
                {
                    for (int i = 1; i < numbers.Count; i++)
                    {
                        calculationProcedure += numbers[i];
                        if (i + 1 < numbers.Count)
                        {
                            calculationProcedure += "*";
                        }

                        calculatedNumber *= numbers[i];
                    }
                    break;
                }
            case "/":
                {
                    for (int i = 1; i < numbers.Count; i++)
                    {
                        calculationProcedure += numbers[i];
                        if (i + 1 < numbers.Count)
                        {
                            calculationProcedure += "/";
                        }

                        calculatedNumber /= numbers[i];
                    }
                    break;
                }
            default:
                {
                    Console.WriteLine($"{sign} is not accepted as an operator, use +,-,*,/.");
                    System.Environment.Exit(-1);
                    break;
                }
        }

        calculationProcedure += $" = {calculatedNumber}";

        return calculationProcedure;
    }
}
