namespace CommandParser;

public class SystemPath : ISystemPath
{
    public SystemPath(string path)
    {
        PathDirectory = path;
    }

    public string PathDirectory { get; set; }
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}