namespace CommandParser.Commands;

public class NotFoundCommand : ICommand
{
    public ResultType Execute(Context context)
    {
        return new ResultType.Loss();
    }
}