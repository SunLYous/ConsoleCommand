using CommandParser.Commands;
using CommandParser.Commands.InformationTypes;
using CommandParser.Commands.ShowModes;
using CommandParser.Iterator;
using CommandParser.Parser.ArgumentHandlers.FileShowArgumentHandlers;

namespace CommandParser.Parser.FileChain;

public class ShowHandler : FileHandlerBase
{
    private const string CommandKey = "SHOW";
    private readonly IFileShowArgumentHandler _nextChain;

    public ShowHandler(IFileShowArgumentHandler nextChain)
    {
        _nextChain = nextChain;
    }

    public override ICommand Handle(CommandIterator request)
    {
        if (request.Current.ToUpperInvariant() != CommandKey)
            return Next?.Handle(request) ?? new NotFoundCommand();
        var builder = new FileShowInformation.Builder();
        builder.WithMode(new ConsoleShowMode());
        request.MoveNext();
        if (!_nextChain.Handle(request, builder))
        {
            return new NotFoundCommand();
        }

        return new ShowCommand(builder.Build());
    }
}