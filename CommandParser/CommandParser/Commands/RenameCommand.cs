using CommandParser.Commands.InformationTypes;

namespace CommandParser.Commands;

public class RenameCommand : ICommand
{
    private readonly RenameInformation _information;

    public RenameCommand(RenameInformation information)
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
            ISystemPath? fullPath = context.ParserPath.GetFullPath(_information.SystemPath);
            if (fullPath is null)
            {
                return new ResultType.Loss();
            }
            else
            {
                if (!fullPath.PathDirectory.StartsWith(
                    context.GlobalSystemPath.PathDirectory,
                    StringComparison.OrdinalIgnoreCase))
                {
                    return new ResultType.Loss();
                }

                context.FileSystem.Rename(new SystemPath(fullPath.PathDirectory), _information.Name);
                return new ResultType.Success();
            }
        }

        context.FileSystem.Rename(globalPath, _information.Name);
        return new ResultType.Success();
    }
}