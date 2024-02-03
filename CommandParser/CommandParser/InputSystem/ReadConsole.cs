namespace CommandParser.InputSystem;

public class ReadConsole : IRead
{
    public IEnumerable<string> Read()
    {
        string? text = Console.ReadLine();
        if (text is not null)
            return text.Split(' ');
        return new List<string>();
    }
}