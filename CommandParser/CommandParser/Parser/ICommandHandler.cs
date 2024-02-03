using CommandParser.Commands;
using CommandParser.Iterator;

namespace CommandParser.Parser;

public interface ICommandHandler
{
    ICommandHandler AddNext(ICommandHandler link);
    ICommand Handle(CommandIterator request);
}