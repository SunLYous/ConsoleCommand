using CommandParser.Commands;
using CommandParser.Iterator;
using CommandParser.Parser.TreeChain;

namespace CommandParser.Parser.FirstChain;

public class TreeHandler : CommandHandlerBase
{
    private const string CommandKey = "TREE";
    private readonly ITreeHandler _nextChain;

    public TreeHandler(ITreeHandler nextChain)
    {
        _nextChain = nextChain;
    }

    public override ICommand Handle(CommandIterator request)
    {
        if (request.Current.ToUpperInvariant() != CommandKey) return Next?.Handle(request) ?? new NotFoundCommand();
        request.MoveNext();
        return _nextChain.Handle(request);
    }
}