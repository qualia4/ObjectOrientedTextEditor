namespace ObjectOrientedTextEditor;

public class Clipboard
{
    private string _text;

    public Clipboard()
    {
        _text = "";
    }

    public string GetText()
    {
        return _text;
    }

    public void SetText(string textToCopy)
    {
        _text = textToCopy;
    }
}