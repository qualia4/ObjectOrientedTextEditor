using System.IO;
using ObjectOrientedTextEditor;

var text = new Text();
var clipboard = new Clipboard();
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
        case "8":
        {
            Console.WriteLine("Enter line, index and amount of symbols to delete:");
            var request = Console.ReadLine().Split(" ");
            var line = int.Parse(request[0]);
            var index = int.Parse(request[1]);
            var length = int.Parse(request[2]);
            text.DeleteText(line, index, length);
            break;
        }

        case "11":
        {
            Console.WriteLine("Enter line, index and amount of symbols to copy:");
            var request = Console.ReadLine().Split(" ");
            var line = int.Parse(request[0]);
            var index = int.Parse(request[1]);
            var length = int.Parse(request[2]);
            clipboard.SetText(text.Copy(line, index, length));
            break;
        }
        case "12":
        {
            Console.WriteLine("Enter coordinates(line and index) to past:");
            var coordinates = Console.ReadLine().Split(" ");
            var line = int.Parse(coordinates[0]);
            var index = int.Parse(coordinates[1]);
            text.Insert(line, index, clipboard.GetText());
            break;
        }
        case "13":
        {
            Console.WriteLine("Enter line, index and amount of symbols to cut:");
            var request = Console.ReadLine().Split(" ");
            var line = int.Parse(request[0]);
            var index = int.Parse(request[1]);
            var length = int.Parse(request[2]);
            text.Copy(line, index, length);
            text.DeleteText(line, index, length);
            break;
        }
        case "14":
        {
            Console.WriteLine("Enter coordinates(line and index):");
            var coordinates = Console.ReadLine().Split(" ");
            var line = int.Parse(coordinates[0]);
            var index = int.Parse(coordinates[1]);
            Console.WriteLine("Enter text to insert:");
            var textToInsert = Console.ReadLine();
            text.DeleteText(line, index, textToInsert.Length);
            text.Insert(line, index, textToInsert);
            break;
        }
    }
}