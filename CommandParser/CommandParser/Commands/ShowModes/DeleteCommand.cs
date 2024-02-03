using CommandParser.Commands.InformationTypes;

namespace CommandParser.Commands.ShowModes;

public class DeleteCommand : ICommand
{
    private readonly PathInformation _information;

    public DeleteCommand(PathInformation information)
    {
        _information = information;
    }

    public ResultType Execute(Context context)
    {
        if (context.FileSystem is null || context.GlobalSystemPath is null || context.ParserPath is null)
        {
            return new ResultType.Loss();
        }

        ISystemPath? globalPath = context.ParserPath.GetDirectory(_information.SystemPath);
        if (globalPath is null)
        {
            string fullPath = Path.GetFullPath(_information.SystemPath);
            if (!fullPath.StartsWith(context.GlobalSystemPath.PathDirectory, StringComparison.OrdinalIgnoreCase))
            {
                return new ResultType.Loss();
            }

            context.FileSystem.Delete(new SystemPath(fullPath));
            return new ResultType.Success();
        }

        context.FileSystem.Delete(globalPath);
        return new ResultType.Success();
    }
}