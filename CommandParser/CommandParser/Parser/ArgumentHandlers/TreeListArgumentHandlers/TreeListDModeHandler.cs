using System.Globalization;
using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.TreeListArgumentHandlers;

public class TreeListDModeHandler : TreeListArgumentHandlerBase
{
    private const string ModeName = "-d";

    public override ParseResult Handle(CommandIterator request, TreeListInformation.Builder builder)
    {
        if (request.Current == ModeName)
        {
            request.MoveNext();
            if (int.TryParse(request.Current, NumberStyles.Integer, CultureInfo.InvariantCulture, out int tmp))
            {
                builder.WithDepth(tmp);
            }
            else
            {
                return new ParseResult.ErrorInput();
            }
        }

        request.MoveNext();
        return Next?.Handle(request, builder) ?? new ParseResult.Success();
    }
}