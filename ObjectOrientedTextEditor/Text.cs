namespace ObjectOrientedTextEditor;

public class Text
{
    private List<string> text { get; set; }
    private int lineNumber { get; set; }

    public Text()
    {
        text = new List<string>();
        text.Add("");
        lineNumber = 0;
    }

    public List<string> GetText()
    {
        return text;
    }

    public void Append(string textToAdd)
    {
        text[lineNumber] += textToAdd;
    }

    public void StartNewLine()
    {
        text.Add("");
        lineNumber++;
    }

    public void UploadFromFile(string path)
    {
        var lines = File.ReadAllLines(path);
        text = new List<string>();
        for (int i = 0; i < lines.Length; i++)
        {
            text.Add(lines[i]);
        }
        lineNumber = lines.Length - 1;
    }

    public void PrintText()
    {
        for (int i = 0; i <= lineNumber; i++)
        {
            Console.WriteLine(text[i]);
        }
    }

    public void Insert(int line, int index, string newText)
    {
        string lineToChange = text[line];
        string firstPart = Substring(lineToChange, 0, index);
        string secPart = Substring(lineToChange, index, lineToChange.Length);
        text[line] = firstPart + newText + secPart;
    }

    public void DeleteText(int line, int index, int amountOfSymbols)
    {
        string lineToChange = text[line];
        string firstPart = Substring(lineToChange, 0, index);
        string secondPart = Substring(lineToChange, index + amountOfSymbols, lineToChange.Length);
        text[line] = firstPart + secondPart;
    }

    public string Copy(int line, int index, int amountOfSymbols)
    {
        return Substring(text[line], index, index + amountOfSymbols);
    }

    public void Save(string path)
    {
        StreamWriter sw = new StreamWriter(path);
        for (int i = 0; i <= lineNumber; i++)
        {
            sw.WriteLine(text[i]);
        }
        sw.Close();
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