using CommandParser.Commands;
using CommandParser.Iterator;

namespace CommandParser.Parser.FileChain;

public interface IFileHandler
{
    IFileHandler AddNext(IFileHandler link);
    ICommand Handle(CommandIterator request);
}