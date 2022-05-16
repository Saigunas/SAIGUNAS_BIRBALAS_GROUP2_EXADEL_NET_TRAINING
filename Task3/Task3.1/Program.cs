using System;

public class Program
{
    public static void Main(string[] args)
    {
        char[] alphabetEn = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        Dictionary<char, LinkedList<string>> namesDictionary =
                        new Dictionary<char, LinkedList<string>>();

        for(var i = 0; i < alphabetEn.Length; i++)
        {
            namesDictionary.Add(alphabetEn[i], new LinkedList<string> { });
        }

        Queue<string> lastNames = new Queue<string>();
        lastNames.Enqueue("John");
        lastNames.Enqueue("jen");
        lastNames.Enqueue("Morgana");
        lastNames.Enqueue("Emily");
        lastNames.Enqueue("A");
        lastNames.Enqueue("sunny");

        while (lastNames.Count > 0)
        {
            var name = lastNames.Dequeue();
            FindDictionaryEntry(ref namesDictionary, name);
        }

        foreach (KeyValuePair<char, LinkedList<string>> entry in namesDictionary)
        {
            Console.Write($"{entry.Key}: ");

            foreach(var lastName in entry.Value)
            {
                Console.Write($"{lastName} ");
            }

            Console.WriteLine();
        }
    }

    public static void FindDictionaryEntry(ref Dictionary<char, LinkedList<string>> dictionary, string name)
    {
        var firstChar = name.FirstOrDefault();
        firstChar = Char.ToLower(firstChar);

        dictionary[firstChar].AddLast(name);
    }
}