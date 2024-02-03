namespace CommandParser.Commands;

public class DisconnectCommand : ICommand
{
    public ResultType Execute(Context context)
    {
        Environment.Exit(0);
        return new ResultType.Success();
    }
}