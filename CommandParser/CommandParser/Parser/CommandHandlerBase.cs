using CommandParser.Commands;
using CommandParser.Iterator;

namespace CommandParser.Parser;

public abstract class CommandHandlerBase : ICommandHandler
{
    protected ICommandHandler? Next { get; private set; }
    public ICommandHandler AddNext(ICommandHandler link)
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