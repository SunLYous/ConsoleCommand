using CommandParser.Commands;
using CommandParser.Commands.InformationTypes;
using CommandParser.Commands.ShowModes;
using CommandParser.Iterator;
using CommandParser.Parser.ArgumentHandlers.PathArgumentHandlers;

namespace CommandParser.Parser.FileChain;

public class DeleteHandler : FileHandlerBase
{
    private const string CommandKey = "DELETE";
    private readonly IPathArgumentHandler _nextChain;

    public DeleteHandler(IPathArgumentHandler nextChain)
    {
        _nextChain = nextChain;
    }

    public override ICommand Handle(CommandIterator request)
    {
        if (request.Current.ToUpperInvariant() != CommandKey)
            return Next?.Handle(request) ?? new NotFoundCommand();
        var builder = new PathInformation.Builder();
        request.MoveNext();
        _nextChain.Handle(request, builder);
        return new DeleteCommand(builder.Build());
    }
}