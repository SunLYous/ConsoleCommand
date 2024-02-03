using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.PathArgumentHandlers;

public class PathHandler : IPathArgumentHandler
{
    private IPathArgumentHandler? Next { get; set; }

    public IPathArgumentHandler AddNext(IPathArgumentHandler link)
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

    public void Handle(CommandIterator request, PathInformation.Builder builder)
    {
        builder.WithSystemPath(request.Current);
    }
}