namespace CommandParser.FileSystems;

public interface IPathParser
{
    ISystemPath? GetDirectory(string path);
    ISystemPath? CheckJoinPath(ISystemPath globalPath, ISystemPath checkPath);
    ISystemPath? GetFullPath(string path);
}