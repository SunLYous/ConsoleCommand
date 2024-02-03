using CommandParser.FileSystems;

namespace CommandParser.Commands.ConnectModes;

public class ConnectLocalConnectMode : IConnectMode
{
    public IPathParser GetParserPath()
    {
      return new LocalPathParser();
    }

    public IFileSystem GetFileSystem()
    {
        return new FileLocalSystem();
    }
}