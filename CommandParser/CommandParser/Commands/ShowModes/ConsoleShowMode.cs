namespace CommandParser.Commands.ShowModes;

public class ConsoleShowMode : IShowMode
{
    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}