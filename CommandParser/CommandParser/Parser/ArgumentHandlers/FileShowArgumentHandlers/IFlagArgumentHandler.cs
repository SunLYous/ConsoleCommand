using CommandParser.Commands.ShowModes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.FileShowArgumentHandlers;

public interface IFlagArgumentHandler
{
    IFlagArgumentHandler AddNext(IFlagArgumentHandler link);
    IShowMode? Handle(CommandIterator request);
}