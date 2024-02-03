using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.SwapArgumentHandlers;

public class SwapHandler : ISwapArgumentHandler
{
    private ISwapArgumentHandler? Next { get; set; }

    public ISwapArgumentHandler AddNext(ISwapArgumentHandler link)
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

    public void Handle(CommandIterator request, TwoPathInformation.Builder builder)
    {
        builder.WithSourceSystemPath(request.Current);
        request.MoveNext();
        builder.WithDestinationSystemPath(request.Current);
        Next?.Handle(request, builder);
    }
}