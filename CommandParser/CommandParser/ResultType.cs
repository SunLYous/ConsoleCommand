namespace CommandParser;

public record ResultType
{
    private ResultType() { }

    public sealed record Loss : ResultType;

    public sealed record Success : ResultType;
}