using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.FileShowArgumentHandlers;

public interface IFileShowModeHandler
{
    IFileShowModeHandler AddNext(IFileShowModeHandler link);
    bool Handle(CommandIterator request, FileShowInformation.Builder builder);
}