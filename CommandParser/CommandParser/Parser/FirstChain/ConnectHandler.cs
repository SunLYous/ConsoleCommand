using CommandParser.Commands;
using CommandParser.Commands.ConnectModes;
using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;
using CommandParser.Parser.ArgumentHandlers.ConnectArgumentHandlers;

namespace CommandParser.Parser.FirstChain;

public class ConnectHandler : CommandHandlerBase
{
    private const string CommandKey = "CONNECT";
    private const int SizeCommand = 4;
    private readonly IConnectArgumentHandler _nextChain;

    public ConnectHandler(IConnectArgumentHandler nextChain)
    {
        _nextChain = nextChain;
    }

    public override ICommand Handle(CommandIterator request)
    {
        if (request.Current.ToUpperInvariant() != CommandKey || request.Count != SizeCommand)
            return Next?.Handle(request) ?? new NotFoundCommand();

        var builder = new ConnectInformation.Builder();
        builder.WithConnectMode(new ConnectLocalConnectMode());
        request.MoveNext();
        if (!_nextChain.Handle(request, builder))
        {
            return new NotFoundCommand();
        }

        return new ConnectCommand(builder.Build());
    }
}