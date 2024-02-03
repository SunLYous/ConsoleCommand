using CommandParser.FileSystems;

namespace CommandParser.Parser;

public class ConsoleVisitor : IVisitor
{
    public void Visit(SystemPath path)
    {
        Console.WriteLine(path.PathDirectory);
    }

    public void Visit(SystemPathComposite composite)
    {
        Console.WriteLine(composite.PathDirectory);
        Console.WriteLine("     ");
    }
}