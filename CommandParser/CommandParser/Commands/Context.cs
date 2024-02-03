using CommandParser.FileSystems;

namespace CommandParser.Commands;

public class Context
{
    public ISystemPath? GlobalSystemPath { get; set; }
    public IPathParser? ParserPath { get; set; }
    public IFileSystem? FileSystem { get; set; }
}