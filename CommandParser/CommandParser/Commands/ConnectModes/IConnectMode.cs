using CommandParser.FileSystems;

namespace CommandParser.Commands.ConnectModes;

public interface IConnectMode
{
    IPathParser GetParserPath();
    IFileSystem GetFileSystem();
}