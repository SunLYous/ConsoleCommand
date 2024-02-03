using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.ConnectArgumentHandlers;

public class AddressHandler : ConnectArgumentHandlerBase
{
    public override bool Handle(CommandIterator request, ConnectInformation.Builder builder)
    {
        builder.WithAddress(request.Current);
        while (request.MoveNext())
        {
            if (Next?.Handle(request, builder) is not true)
            {
                return false;
            }
        }

        return true;
    }
    }