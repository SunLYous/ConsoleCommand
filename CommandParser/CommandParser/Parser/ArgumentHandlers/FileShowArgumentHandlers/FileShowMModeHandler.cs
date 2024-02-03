using CommandParser.Commands.InformationTypes;
using CommandParser.Commands.ShowModes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.FileShowArgumentHandlers;

public class FileShowMModeHandler : FileShowModeHandlerBase
{
    private const string Flag = "-m";
    private readonly IFlagArgumentHandler _flag;

    public FileShowMModeHandler(IFlagArgumentHandler flag)
    {
        _flag = flag;
    }

    public override bool Handle(CommandIterator request, FileShowInformation.Builder builder)
    {
        if (request.Current != Flag) return Next?.Handle(request, builder) ?? false;
        request.MoveNext();
        IShowMode? mode = _flag.Handle(request);
        if (mode is not null)
        {
            return true;
        }

        builder.WithMode(mode);

        return Next?.Handle(request, builder) ?? false;
    }
}