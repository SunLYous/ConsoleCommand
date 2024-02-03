using CommandParser.Commands.InformationTypes;
using CommandParser.FileSystems;

namespace CommandParser.Commands;

public class ConnectCommand : ICommand
{
    private readonly ConnectInformation _information;

    public ConnectCommand(ConnectInformation information)
    {
        _information = information;
    }

    public ResultType Execute(Context context)
    {
        IPathParser pathParser = _information.ConnectMode.GetParserPath();
        context.GlobalSystemPath = pathParser.GetDirectory(_information.Address);
        if (context.GlobalSystemPath is null)
        {
            return new ResultType.Loss();
        }

        context.FileSystem = _information.ConnectMode.GetFileSystem();
        context.ParserPath = _information.ConnectMode.GetParserPath();
        return new ResultType.Success();
    }
}