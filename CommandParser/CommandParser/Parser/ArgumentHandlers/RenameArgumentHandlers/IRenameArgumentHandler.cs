using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.RenameArgumentHandlers;

public interface IRenameArgumentHandler
{
    IRenameArgumentHandler AddNext(IRenameArgumentHandler link);
    void Handle(CommandIterator request, RenameInformation.Builder builder);
}