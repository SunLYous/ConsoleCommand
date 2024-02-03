using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.PathArgumentHandlers;

public interface IPathArgumentHandler
{
    IPathArgumentHandler AddNext(IPathArgumentHandler link);
    void Handle(CommandIterator request, PathInformation.Builder builder);
}