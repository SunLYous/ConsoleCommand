namespace CommandParser.FileSystems;

public class SystemPathComposite : ISystemPath
{
    private List<ISystemPath> _children;

    public SystemPathComposite(string path)
    {
        PathDirectory = path;
        _children = new List<ISystemPath>();
    }

    public string PathDirectory { get; }

    public void AddChild(ISystemPath child)
    {
        _children.Add(child);
    }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
        foreach (ISystemPath path in _children)
        {
            path.Accept(visitor);
        }
    }

    public IReadOnlyList<ISystemPath> GetChildren()
    {
        return _children.AsReadOnly();
    }
}