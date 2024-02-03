using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.ConnectArgumentHandlers;

public interface IConnectModeHandler
{
    IConnectModeHandler AddNext(IConnectModeHandler link);
    bool Handle(CommandIterator request, ConnectInformation.Builder builder);
}