using CommandParser.Commands;
using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;
using CommandParser.Parser.ArgumentHandlers.SwapArgumentHandlers;

namespace CommandParser.Parser.FileChain;

public class MoveHandler : FileHandlerBase
{
    private const string CommandKey = "MOVE";
    private const int SizeCommand = 4;
    private readonly ISwapArgumentHandler _nextChain;

    public MoveHandler(ISwapArgumentHandler nextChain)
    {
        _nextChain = nextChain;
    }

    public override ICommand Handle(CommandIterator request)
    {
        if (request.Current.ToUpperInvariant() != CommandKey || request.Count != SizeCommand)
            return Next?.Handle(request) ?? new NotFoundCommand();
        var builder = new TwoPathInformation.Builder();
        request.MoveNext();
        _nextChain.Handle(request, builder);
        return new MoveCommand(builder.Build());
    }
}