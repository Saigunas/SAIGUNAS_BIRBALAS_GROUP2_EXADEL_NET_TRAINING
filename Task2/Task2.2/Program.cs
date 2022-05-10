using System;

public class Program
{

    const int maxFileLength = 300;

    public static void Main(string[] args)
    {
        string file1Contents = System.IO.File.ReadAllText("..\\..\\..\\file1.txt");
        string file2Contents = System.IO.File.ReadAllText("..\\..\\..\\file2.txt");
        string file3Contents = System.IO.File.ReadAllText("..\\..\\..\\file3.txt");

        List<string> fileList = new List<string>() {file1Contents, file2Contents, file3Contents};
        List<string> changedFileList = new List<string>();

        var program = new Program();
        changedFileList = program.modifyList(fileList);

        string path = "..\\..\\..\\output.txt";
        File.WriteAllText(path, String.Empty);
        File.AppendAllLines(path, changedFileList);

        File.Delete("..\\..\\..\\file1.txt");
        File.Delete("..\\..\\..\\file2.txt");
        File.Delete("..\\..\\..\\file3.txt");

    }


    List<string> modifyList(List<string> fileList)
    {
        List<string> changedFileList = new List<string>();

        for (int i = 0; i < fileList.Count; i++)
        {
            string itemToChange = fileList[i];

            //Everything is applied separately for the sake of readability and easier modification.
            itemToChange = applyLengthLimit(itemToChange);
            itemToChange = reverseString(itemToChange);
            itemToChange = sortWordByUpperCase(itemToChange);
            itemToChange = filterString(itemToChange);


            changedFileList.Add(itemToChange);
        }

        changedFileList = changedFileList.OrderBy(x => x.Length).ToList();

        return changedFileList;
    }

    string filterString(string toFilter)
    {
        char[] characters = toFilter.ToArray();

        characters = Array.FindAll(characters, c => {
            return (char.IsWhiteSpace(c) || char.IsLetter(c));
        });

        string filteredString = new string(characters);

        return filteredString;
    }

    string sortWordByUpperCase(string toSort)
    {

        List<string> words = new List<string>();
        words.AddRange(toSort.Split(' '));

        for(int i = 0; i < words.Count; i++)
        {
            List<char> chars = new List<char>();
            chars.AddRange(words[i]);

            var sortedCharacters = chars.OrderBy(c => !char.IsUpper(c)).ToArray();
            words[i] = new string(sortedCharacters);
        }

        string sortedString = string.Join(" ", words);
        return sortedString;
    }

    string reverseString(string toReverse)
    {
        char[] characters = toReverse.ToArray();
        
        Array.Reverse(characters);
        string reversedString = new string(characters);

        return reversedString;
    }

    string applyLengthLimit(string toLimit)
    {
        if (toLimit.Length > 300)
        {
            toLimit = toLimit.Substring(0, maxFileLength);
        }
        return toLimit;
    }


}
