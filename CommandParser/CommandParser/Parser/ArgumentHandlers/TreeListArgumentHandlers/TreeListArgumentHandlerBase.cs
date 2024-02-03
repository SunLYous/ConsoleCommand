using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.TreeListArgumentHandlers;

public abstract class TreeListArgumentHandlerBase : ITreeListArgumentHandler
{
    protected ITreeListArgumentHandler? Next { get; set; }

    public ITreeListArgumentHandler AddNext(ITreeListArgumentHandler link)
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

    public abstract ParseResult Handle(CommandIterator request, TreeListInformation.Builder builder);
}