namespace ObjectOrientedTextEditor;

public class TextAnalyzer
{
    private Text _text;

    public TextAnalyzer(Text textToAnalyze)
    {
        _text = textToAnalyze;
    }

    public void Search(string textToSearch)
    {
        var lengthOfSearch = textToSearch.Length;
        var index = 0;
        foreach (var str in _text.GetText())
        {
            for (int i = 0, j = lengthOfSearch;
                 i < str.Length && j < str.Length + 1; i++, j++)
            {
                if (Substring(str, i, j) == textToSearch)
                {
                    Console.Write("[" + index + ";" + i + "] ");
                }
            }
            index++;
        }
        Console.WriteLine();
    }

    string Substring(string str, int start, int end)
    {
        string result = "";
        for (int i = start; i < end; i++)
        {
            result += str[i];
        }
        return result;
    }
}