using CommandParser.Commands.InformationTypes;

namespace CommandParser.Commands;

public class GotoCommand : ICommand
{
    private readonly PathInformation _information;

    public GotoCommand(PathInformation information)
    {
        _information = information;
    }

    public ResultType Execute(Context context)
    {
        if (context.FileSystem is null || context.GlobalSystemPath is null || context.ParserPath is null)
        {
            return new ResultType.Loss();
        }

        if (!_information.SystemPath.StartsWith(
                context.GlobalSystemPath.PathDirectory,
                StringComparison.OrdinalIgnoreCase))
        {
            return new ResultType.Loss();
        }

        context.GlobalSystemPath =
            context.FileSystem.TreeGoto(context.GlobalSystemPath, new SystemPath(_information.SystemPath));

        return new ResultType.Success();
    }
}