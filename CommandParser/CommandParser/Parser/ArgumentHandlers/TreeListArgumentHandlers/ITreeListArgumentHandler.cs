using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.TreeListArgumentHandlers;

public interface ITreeListArgumentHandler
{
    ITreeListArgumentHandler AddNext(ITreeListArgumentHandler link);
    ParseResult Handle(CommandIterator request, TreeListInformation.Builder builder);
}