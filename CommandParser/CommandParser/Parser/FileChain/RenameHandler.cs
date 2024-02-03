using CommandParser.Commands;
using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;
using CommandParser.Parser.ArgumentHandlers.RenameArgumentHandlers;

namespace CommandParser.Parser.FileChain;

public class RenameHandler : FileHandlerBase
{
    private const string CommandKey = "RENAME";
    private const int SizeCommand = 4;
    private readonly IRenameArgumentHandler _nextChain;

    public RenameHandler(IRenameArgumentHandler nextChain)
    {
        _nextChain = nextChain;
    }

    public override ICommand Handle(CommandIterator request)
    {
        if (request.Current.ToUpperInvariant() != CommandKey || request.Count != SizeCommand)
            return Next?.Handle(request) ?? new NotFoundCommand();
        var builder = new RenameInformation.Builder();
        request.MoveNext();
        _nextChain.Handle(request, builder);
        return new RenameCommand(builder.Build());
    }
}