using CommandParser.Commands.InformationTypes;
using CommandParser.FileSystems;
using CommandParser.Parser;

namespace CommandParser.Commands;

public class ListCommand : ICommand
{
    private readonly TreeListInformation _information;

    public ListCommand(TreeListInformation information)
    {
        _information = information;
    }

    public ResultType Execute(Context context)
    {
        if (context.FileSystem is null || context.GlobalSystemPath is null || context.ParserPath is null)
        {
            return new ResultType.Loss();
        }

        SystemPathComposite directoryStructure =
            context.FileSystem.TreeList(context.GlobalSystemPath.PathDirectory, _information.Depth, 0);
        IVisitor consoleVisitor = new ConsoleVisitor();

        directoryStructure.Accept(consoleVisitor);

        return new ResultType.Success();
    }
}