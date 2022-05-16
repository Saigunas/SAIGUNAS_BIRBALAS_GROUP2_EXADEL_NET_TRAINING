using System;
public class Program
{

    protected class BracketPair
    {

        private char _openBracket;
        public char OpenBracket { get { return _openBracket; } }

        private char _closedBracket;
        public char CloseBracket { get { return _closedBracket; } }

        public BracketPair(char openBracket, char closedBracket)
        {
            this._openBracket = openBracket;
            this._closedBracket = closedBracket;
        }

    }


    public static void Main(string[] args)
    {

        Console.WriteLine("Type the text you want to be inspected:");
        string textToInspect = Console.ReadLine();

        string roundBrackets = "()";
        string squareBrackets = "[]";
        string curlyBrackets = "{}";


        var listOfBracketsToCheck = new List<BracketPair>();
        listOfBracketsToCheck.Add(new BracketPair(roundBrackets[0], roundBrackets[1]));
        listOfBracketsToCheck.Add(new BracketPair(squareBrackets[0], squareBrackets[1]));
        listOfBracketsToCheck.Add(new BracketPair(curlyBrackets[0], curlyBrackets[1]));



        var program = new Program();


        string bracketsAllowed = "";
        foreach (var brackets in listOfBracketsToCheck)
        {
            bracketsAllowed += brackets.OpenBracket.ToString() + brackets.CloseBracket.ToString();
        }
 
        string filteredText = program.FilterString(textToInspect, bracketsAllowed);


        bool isTextCorrect = true;
        foreach(var brackets in listOfBracketsToCheck)
        {
            isTextCorrect = program.IsBracketUsageCorrect(filteredText, brackets, listOfBracketsToCheck);
            if(!isTextCorrect)
            {
                break;
            }
        }

        program.PrintText(filteredText, isTextCorrect);

    }


    public void PrintText(string filteredText, bool isTextCorrect)
    {
        Console.Write(filteredText);
        if (isTextCorrect)
        {
            Console.WriteLine(" - true");
        }
        if (!isTextCorrect)
        {
            Console.WriteLine(" - false");
        }
    }

    protected bool IsBracketUsageCorrect(string textToCheck, BracketPair bracketsToCheck, List<BracketPair> bracketList)
    {

        bool isTextCorrect = true;
        int timesOpenBracketUsed = 0;
        int timesCloseBracketUsed = 0;

        //find if there are equal numbers of open and close brackets
        //if not return false
        List<char> textCharacters = new List<char>(textToCheck);
        for (int i = 0; i < textCharacters.Count; i++)
        {
            char c = textCharacters[i];


            if (c == bracketsToCheck.OpenBracket)
            {
                timesOpenBracketUsed++;
            }
            if (c == bracketsToCheck.CloseBracket)
            {
                timesCloseBracketUsed++;

                //Make sure there are no close brackets before open brackets
                //if ")" before "("
                if (timesCloseBracketUsed > timesOpenBracketUsed)
                {
                    isTextCorrect = false;
                    return isTextCorrect;
                }

            }

        }

        //if isTextCorrect == true that means all the brackets have all correct pairs
        if (timesCloseBracketUsed != timesOpenBracketUsed)
        {
            isTextCorrect = false;
        }


        //Iterate over the text once again to find the pairs and
        //check inside of the bracket pair, so { ( } ) results to false
        if (isTextCorrect == true)
        {
            var unresolvedBracketIndexes = new List<int>();

            for (int i = 0; i < textCharacters.Count; i++)
            {

                if (textCharacters[i] == bracketsToCheck.OpenBracket)
                {
                    unresolvedBracketIndexes.Add(i);
                }

                if (textCharacters[i] ==  bracketsToCheck.CloseBracket)
                {
                    int indexOpenBracket = unresolvedBracketIndexes.LastOrDefault();
                    int indexCloseBracket = i;

                    //from "(asd)" to "asd"
                    List<char> textsInParanthesis = textCharacters.GetRange(indexOpenBracket + 1, indexCloseBracket - indexOpenBracket - 1);
                    var textFromParanthesis = new string(textsInParanthesis.ToArray());

                    //Recursive for every type of brackets there are
                    foreach (var brackets in bracketList)
                    {
                        isTextCorrect = IsBracketUsageCorrect(textFromParanthesis, brackets, bracketList);
                        if (!isTextCorrect)
                        {
                            return isTextCorrect;
                        }
                    }

                    unresolvedBracketIndexes.RemoveAt(unresolvedBracketIndexes.Count - 1);
                }
            }

        }

        return isTextCorrect;
    }

    public string FilterString(string toFilter, string allowedCharacters)
    {
        string filteredText = string.Empty;

        char[] textCharacters = toFilter.ToCharArray();
        for (int i = 0; i < textCharacters.Length; i++)
        {
            char c = textCharacters[i];
            if (allowedCharacters.Contains(c))
            {
                filteredText += c;
            }
        }

        return filteredText;
    }
}

///LOGIC FOR BRACKET MATCHING
/*
 * find if there are equal numbers of open and close brackets
if not return false
make sure there are no close brackets before open brackets

if textIsCorrect = true that means all the brackets have all correct pairs

iterate over list
find open bracket
push index to unresolved list
maybe find open bracket
push index to unresolved list

maybe find close bracket
get index of close bracket
get last index from unresolved list

if there are no brackets return to caller
else
create new list with what is inside the brackets

for everytype of brackets there are call repeat with that other type of bracket
*/