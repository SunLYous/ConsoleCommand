using CommandParser.Commands.ConnectModes;
using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.ConnectArgumentHandlers;

public class MModeHandler : ConnectModeHandlerBase
{
    private const string Flag = "-m";
    private IConnectFlagHandler _connectFlag;

    public MModeHandler(IConnectFlagHandler connectFlag)
    {
        _connectFlag = connectFlag;
    }

    public override bool Handle(CommandIterator request, ConnectInformation.Builder builder)
    {
        if (request.Current != Flag) return Next?.Handle(request, builder) ?? false;
        request.MoveNext();
        IConnectMode? mode = _connectFlag.Handle(request);
        if (mode is not null)
        {
            return true;
        }

        builder.WithConnectMode(mode);

        return Next?.Handle(request, builder) ?? false;
    }
}