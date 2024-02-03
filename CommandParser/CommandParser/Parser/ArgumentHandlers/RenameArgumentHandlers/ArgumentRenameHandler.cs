using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.RenameArgumentHandlers;

public class ArgumentRenameHandler : IRenameArgumentHandler
{
    private IRenameArgumentHandler? Next { get; set; }

    public IRenameArgumentHandler AddNext(IRenameArgumentHandler link)
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

    public void Handle(CommandIterator request, RenameInformation.Builder builder)
    {
        builder.WithSystemPath(request.Current);
        request.MoveNext();
        builder.WithName(request.Current);
        Next?.Handle(request, builder);
    }
}