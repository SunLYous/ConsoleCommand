using CommandParser.Commands;
using CommandParser.Iterator;
using CommandParser.Parser.FileChain;

namespace CommandParser.Parser.FirstChain;

public class FileHandler : CommandHandlerBase
{
    private const string CommandKey = "FILE";
    private readonly IFileHandler _nextChain;

    public FileHandler(IFileHandler nextChain)
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