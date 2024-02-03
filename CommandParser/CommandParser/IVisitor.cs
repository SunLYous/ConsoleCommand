using CommandParser.FileSystems;

namespace CommandParser;

public interface IVisitor
{
    void Visit(SystemPath path);
    void Visit(SystemPathComposite composite);
}