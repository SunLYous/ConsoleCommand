using CommandParser.Commands;
using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;
using CommandParser.Parser.ArgumentHandlers.TreeListArgumentHandlers;

namespace CommandParser.Parser.TreeChain;

public class ListHandler : TreeHandlerBase
{
    private const string CommandKey = "LIST";
    private const int SizeCommand = 4;
    private readonly ITreeListArgumentHandler _nextChain;

    public ListHandler(ITreeListArgumentHandler nextChain)
    {
        _nextChain = nextChain;
    }

    public override ICommand Handle(CommandIterator request)
    {
        if (request.Current.ToUpperInvariant() != CommandKey || request.Count != SizeCommand)
            return Next?.Handle(request) ?? new NotFoundCommand();
        var builder = new TreeListInformation.Builder();
        request.MoveNext();

        if (_nextChain.Handle(request, builder) is ParseResult.ErrorInput)
        {
            return new NotFoundCommand();
        }

        return new ListCommand(builder.Build());
    }
}