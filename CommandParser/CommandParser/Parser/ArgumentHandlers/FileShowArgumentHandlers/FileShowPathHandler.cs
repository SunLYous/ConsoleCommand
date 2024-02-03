using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.FileShowArgumentHandlers;

public class FileShowPathHandler : IFileShowArgumentHandler
{
    private IFileShowModeHandler? Next { get; set; }

    public IFileShowModeHandler AddNext(IFileShowModeHandler link)
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

    public bool Handle(CommandIterator request, FileShowInformation.Builder builder)
    {
        builder.WithSystemPath(request.Current);

        while (request.MoveNext())
        {
            if (!(Next?.Handle(request, builder) ?? false))
            {
                return false;
            }
        }

        return true;
    }
}