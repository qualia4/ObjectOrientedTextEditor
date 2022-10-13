using System.IO;
using ObjectOrientedTextEditor;

var text = new Text();
var textAnalyzer = new TextAnalyzer(text);
bool toContinue = true;
while (toContinue)
{
    Console.WriteLine("Enter the command:");
    var command = Console.ReadLine();
    switch (command)
    {
        case "0":
        {
            toContinue = false;
            break;
        }
        case "1":
        {
            Console.WriteLine("Enter text to append:");
            var newText = Console.ReadLine();
            text.Append(newText);
            break;
        }
        case "2":
        {
            text.StartNewLine();
            Console.WriteLine("New line started!");
            break;
        }
        case "3":
        {
            Console.WriteLine("Enter file path:");
            string path = Console.ReadLine();
            text.Save(path);
            Console.WriteLine("File saved!");
            break;
        }

        case "4":
        {
            Console.WriteLine("Enter file path:");
            string path = Console.ReadLine();
            text.UploadFromFile(path);
            break;
        }
        case "5":
        {
            text.PrintText();
            break;
        }
        case "6":
        {
            Console.WriteLine("Enter line and index:");
            var coordinates = Console.ReadLine().Split(' ');
            var line = int.Parse(coordinates[0]);
            var index = int.Parse(coordinates[1]);
            Console.WriteLine("Enter text to insert:");
            var newText = Console.ReadLine();
            text.Insert(line, index, newText);
            break;
        }
        case "7":
        {
            Console.WriteLine("Enter text to search:");
            var textToSearch = Console.ReadLine();
            textAnalyzer.Search(textToSearch);
            break;
        }
    }
}