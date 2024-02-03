using CommandParser.Commands;
using CommandParser.Iterator;
using CommandParser.Parser.ArgumentHandlers.ConnectArgumentHandlers;
using CommandParser.Parser.ArgumentHandlers.FileShowArgumentHandlers;
using CommandParser.Parser.ArgumentHandlers.PathArgumentHandlers;
using CommandParser.Parser.ArgumentHandlers.RenameArgumentHandlers;
using CommandParser.Parser.ArgumentHandlers.SwapArgumentHandlers;
using CommandParser.Parser.ArgumentHandlers.TreeListArgumentHandlers;
using CommandParser.Parser.FileChain;
using CommandParser.Parser.FirstChain;
using CommandParser.Parser.TreeChain;

namespace CommandParser;

public static class Program
{
    public static void Main()
    {
        var context = new Context();
        var l = new List<string>() { "connect", "www", "-m", "local" };
        var iterator = new CommandIterator(l);

        // connect
        var flagConnect = new LocalConnectHandler();
        var mode = new MModeHandler(flagConnect);
        var address = new AddressHandler();
        address.AddNext(mode);
        var connect = new ConnectHandler(address);
        var disconnect = new DisconnectHandler();

        // rename
        var renameArgument = new ArgumentRenameHandler();
        var rename = new RenameHandler(renameArgument);

        // fileShow
        var showPath = new FileShowPathHandler();
        var flag = new ConsoleFlagArgumentHandler();
        var showMode = new FileShowMModeHandler(flag);
        var show = new ShowHandler(showPath);
        showPath.AddNext(showMode);

        // fileMove
        var pathMove = new SwapHandler();
        var move = new MoveHandler(pathMove);

        // fileCopy
        var pathCopy = new SwapHandler();
        var copy = new CopyHandler(pathCopy);

        // delete
        var pathDelete = new PathHandler();
        IFileHandler delete = new DeleteHandler(pathDelete);
        delete.AddNext(copy).AddNext(move).AddNext(rename).AddNext(show);
        var fileDelete = new FileHandler(delete);

        // treeGoto
        var pathTreeGoto = new PathHandler();
        var got = new GotoHandler(pathTreeGoto);
        var treeGoto = new TreeHandler(got);

        // treeList
        var modeList = new TreeListDModeHandler();
        var treeList = new ListHandler(modeList);
        got.AddNext(treeList);
        connect.AddNext(disconnect).AddNext(fileDelete).AddNext(treeGoto);
        ICommand command = connect.Handle(iterator);
        command.Execute(context);
    }
}