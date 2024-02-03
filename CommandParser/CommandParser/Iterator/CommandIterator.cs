using System.Collections;

namespace CommandParser.Iterator;

public class CommandIterator : IEnumerator
{
    private readonly List<string> _commandParts;
    private int _position;

    public CommandIterator(IEnumerable<string> commands)
    {
        _commandParts = new List<string>(commands);
    }

    public int Count => _commandParts.Count;

    public string Current => _commandParts[_position];

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (_position >= _commandParts.Count - 1) return false;
        _position++;
        return true;
    }

    public void Reset()
    {
        _position = 0;
    }
}