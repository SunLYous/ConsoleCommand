using CommandParser.Commands;
using CommandParser.Iterator;

namespace CommandParser.Parser.TreeChain;

public abstract class TreeHandlerBase : ITreeHandler
{
    protected ITreeHandler? Next { get; private set; }
    public ITreeHandler AddNext(ITreeHandler link)
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