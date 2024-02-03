using CommandParser.Commands;
using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;
using CommandParser.Parser.ArgumentHandlers.PathArgumentHandlers;

namespace CommandParser.Parser.TreeChain;

public class GotoHandler : TreeHandlerBase
{
    private const string CommandKey = "GOTO";
    private const int SizeCommand = 3;
    private readonly IPathArgumentHandler _nextChain;

    public GotoHandler(IPathArgumentHandler nextChain)
    {
        _nextChain = nextChain;
    }

    public override ICommand Handle(CommandIterator request)
    {
        if (request.Current.ToUpperInvariant() != CommandKey || request.Count != SizeCommand)
            return Next?.Handle(request) ?? new NotFoundCommand();
        var builder = new PathInformation.Builder();
        request.MoveNext();
        _nextChain.Handle(request, builder);
        return new GotoCommand(builder.Build());
    }
}