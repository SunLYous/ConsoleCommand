using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.FileShowArgumentHandlers;

public abstract class FileShowModeHandlerBase : IFileShowModeHandler
{
    protected IFileShowModeHandler? Next { get; set; }

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

    public abstract bool Handle(CommandIterator request, FileShowInformation.Builder builder);
}