using CommandParser.Commands.ConnectModes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.ConnectArgumentHandlers;

public class LocalConnectHandler : IConnectFlagHandler
{
    private const string Command = "local";
    private IConnectFlagHandler? Next { get; set; }
    public IConnectFlagHandler AddNext(IConnectFlagHandler link)
    {
        if (Next is null)
        {
            Next = link;
        }
        else
        {
            Next.AddNext(link);
        }

        return link;
    }

    public IConnectMode? Handle(CommandIterator request)
    {
        if (request.Current == Command)
        {
            return new ConnectLocalConnectMode();
        }

        return Next?.Handle(request) ?? null;
    }
}