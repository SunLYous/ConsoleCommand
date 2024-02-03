using CommandParser.Commands;
using CommandParser.Iterator;

namespace CommandParser.Parser.TreeChain;

public interface ITreeHandler
{
    ITreeHandler AddNext(ITreeHandler link);
    ICommand Handle(CommandIterator request);
}