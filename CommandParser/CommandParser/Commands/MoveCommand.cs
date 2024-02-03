using CommandParser.Commands.InformationTypes;

namespace CommandParser.Commands;

public class MoveCommand : ICommand
{
    private readonly TwoPathInformation _information;

    public MoveCommand(TwoPathInformation information)
    {
        _information = information;
    }

    public ResultType Execute(Context context)
    {
        if (context.FileSystem is null || context.GlobalSystemPath is null || context.ParserPath is null)
        {
            return new ResultType.Loss();
        }

        ISystemPath? globalPath = context.ParserPath.GetDirectory(_information.DestinationSystemPath);
        ISystemPath? globalPathTwo = context.ParserPath.GetDirectory(_information.SourceSystemPath);
        if (globalPathTwo is null)
            return new ResultType.Loss();
        if (globalPath is null)
        {
            ISystemPath? fullPath = context.ParserPath.GetFullPath(_information.DestinationSystemPath);
            if (fullPath is null)
            {
                return new ResultType.Loss();
            }
            else
            {
                if (!fullPath.PathDirectory.StartsWith(context.GlobalSystemPath.PathDirectory, StringComparison.OrdinalIgnoreCase))
                {
                    return new ResultType.Loss();
                }

                context.FileSystem.Move(new SystemPath(fullPath.PathDirectory), globalPathTwo);
                return new ResultType.Success();
            }
        }

        context.FileSystem.Move(globalPath, globalPathTwo);
        return new ResultType.Success();
    }
}