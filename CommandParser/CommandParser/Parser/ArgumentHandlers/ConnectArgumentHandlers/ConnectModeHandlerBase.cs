using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.ConnectArgumentHandlers;

public abstract class ConnectModeHandlerBase : IConnectModeHandler
{
    protected IConnectModeHandler? Next { get; private set; }

    public IConnectModeHandler AddNext(IConnectModeHandler link)
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

    public abstract bool Handle(CommandIterator request, ConnectInformation.Builder builder);
}