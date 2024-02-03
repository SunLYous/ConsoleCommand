using CommandParser.Commands;
using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;
using CommandParser.Parser.ArgumentHandlers.SwapArgumentHandlers;

namespace CommandParser.Parser.FileChain;

public class CopyHandler : FileHandlerBase
{
    private const string CommandKey = "COPY";
    private readonly ISwapArgumentHandler _nextChain;

    public CopyHandler(ISwapArgumentHandler nextChain)
    {
        _nextChain = nextChain;
    }

    public override ICommand Handle(CommandIterator request)
    {
        if (request.Current.ToUpperInvariant() != CommandKey)
            return Next?.Handle(request) ?? new NotFoundCommand();
        var builder = new TwoPathInformation.Builder();
        request.MoveNext();
        _nextChain.Handle(request, builder);
        return new CopyCommand(builder.Build());
    }
}