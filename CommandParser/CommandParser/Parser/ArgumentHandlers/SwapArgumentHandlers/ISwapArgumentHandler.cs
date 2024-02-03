using CommandParser.Commands.InformationTypes;
using CommandParser.Iterator;

namespace CommandParser.Parser.ArgumentHandlers.SwapArgumentHandlers;

public interface ISwapArgumentHandler
{
    ISwapArgumentHandler AddNext(ISwapArgumentHandler link);
    void Handle(CommandIterator request, TwoPathInformation.Builder builder);
}