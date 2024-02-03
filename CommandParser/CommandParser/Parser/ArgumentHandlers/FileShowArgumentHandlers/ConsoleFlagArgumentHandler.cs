using CommandParser.Commands.ShowModes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.FileShowArgumentHandlers;

public class ConsoleFlagArgumentHandler : IFlagArgumentHandler
{
    private const string Command = "console";
    private IFlagArgumentHandler? Next { get; set; }

    public IFlagArgumentHandler AddNext(IFlagArgumentHandler link)
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

    public IShowMode? Handle(CommandIterator request)
    {
        if (request.Current == Command)
        {
            return new ConsoleShowMode();
        }

        return Next?.Handle(request) ?? null;
    }
}