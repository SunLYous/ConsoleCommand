namespace CommandParser;

public interface ISystemPath
{
    string PathDirectory { get; }
    void Accept(IVisitor visitor);
}