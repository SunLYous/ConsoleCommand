using CommandParser.Commands.InformationTypes;

namespace CommandParser.Commands.ShowModes;

public class ShowCommand : ICommand
{
    private readonly FileShowInformation _information;

    public ShowCommand(FileShowInformation information)
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

            context.FileSystem.Show(new SystemPath(fullPath), _information.Mode);
            return new ResultType.Success();
        }

        if (!File.Exists(globalPath.PathDirectory))
            return new ResultType.Loss();

        context.FileSystem.Show(globalPath, _information.Mode);
        return new ResultType.Success();
    }
}