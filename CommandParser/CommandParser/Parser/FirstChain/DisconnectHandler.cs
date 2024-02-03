using CommandParser.Commands;
using CommandParser.Iterator;

namespace CommandParser.Parser.FirstChain;

public class DisconnectHandler : CommandHandlerBase
{
    private const string CommandKey = "DISCONNECT";
    private const int SizeCommand = 1;

    public override ICommand Handle(CommandIterator request)
    {
        if (request.Count == SizeCommand && request.Current.ToUpperInvariant() == CommandKey)
        {
            return new DisconnectCommand();
        }

        return Next?.Handle(request) ?? new NotFoundCommand();
    }
}