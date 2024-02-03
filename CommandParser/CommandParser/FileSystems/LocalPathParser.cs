namespace CommandParser.FileSystems;

public class LocalPathParser : IPathParser
{
    public ISystemPath? GetDirectory(string path)
    {
        if (Directory.Exists(path) && Path.IsPathRooted(path))
        {
            return new SystemPath(path);
        }

        return null;
    }

    public ISystemPath? CheckJoinPath(ISystemPath globalPath, ISystemPath checkPath)
    {
        string fullCheckPath = Path.GetFullPath(checkPath.PathDirectory);
        return fullCheckPath.StartsWith(checkPath.PathDirectory, StringComparison.OrdinalIgnoreCase)
            ? new SystemPath(fullCheckPath)
            : null;
    }

    public ISystemPath GetFullPath(string path)
    {
        return new SystemPath(Path.GetFullPath(path));
    }
}