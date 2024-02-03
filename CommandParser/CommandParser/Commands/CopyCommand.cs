using CommandParser.Commands.InformationTypes;

namespace CommandParser.Commands;

public class CopyCommand : ICommand
{
    private readonly TwoPathInformation _information;

    public CopyCommand(TwoPathInformation information)
    {
        _information = information;
    }

    public ResultType Execute(Context context)
    {
        if (context.FileSystem is null || context.GlobalSystemPath is null || context.ParserPath is null)
        {
            return new ResultType.Loss();
        }

        ISystemPath? destinationSystemPath = context.ParserPath.GetDirectory(_information.DestinationSystemPath);
        ISystemPath? sourceSystemPath = context.ParserPath.GetDirectory(_information.SourceSystemPath);

        if (destinationSystemPath is null)
            return new ResultType.Loss();

        if (sourceSystemPath is not null) return new ResultType.Success();
        ISystemPath? fullPath = context.ParserPath.GetFullPath(_information.SourceSystemPath);

        if (fullPath is null)
            return new ResultType.Loss();

        return new ResultType.Success();
    }
}