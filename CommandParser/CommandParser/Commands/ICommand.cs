namespace CommandParser.Commands;

public interface ICommand
{
    ResultType Execute(Context context);
}