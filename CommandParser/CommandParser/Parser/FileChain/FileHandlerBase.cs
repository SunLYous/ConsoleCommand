using CommandParser.Commands;
using CommandParser.Iterator;

namespace CommandParser.Parser.FileChain;

public abstract class FileHandlerBase : IFileHandler
{
    protected IFileHandler? Next { get; private set; }
    public IFileHandler AddNext(IFileHandler link)
    {
        if (Next is null)
        {
            Next = link;
        }
        else
        {
            Next.AddNext(link);
        }

        return link;
    }

    public abstract ICommand Handle(CommandIterator request);
}