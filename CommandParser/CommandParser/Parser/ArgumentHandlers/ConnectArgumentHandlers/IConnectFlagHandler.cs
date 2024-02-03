using CommandParser.Commands.ConnectModes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.ConnectArgumentHandlers;

public interface IConnectFlagHandler
{
    IConnectFlagHandler AddNext(IConnectFlagHandler link);
    IConnectMode? Handle(CommandIterator request);
}