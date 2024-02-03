namespace CommandParser;

public record ParseResult
{
    private ParseResult() { }

    public sealed record ErrorInput : ParseResult;

    public sealed record Success : ParseResult;
}