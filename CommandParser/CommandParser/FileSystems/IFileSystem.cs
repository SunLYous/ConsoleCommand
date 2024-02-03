using CommandParser.Commands.ShowModes;

namespace CommandParser.FileSystems;

public interface IFileSystem
{
    void Move(ISystemPath sourcePath, ISystemPath destinationPath);
    void Copy(ISystemPath sourcePath, ISystemPath destinationPath);
    void Show(ISystemPath path, IShowMode mode);
    void Rename(ISystemPath path, string name);
    void Delete(ISystemPath path);
    ISystemPath? TreeGoto(ISystemPath globalPath, ISystemPath path);
    SystemPathComposite TreeList(string rootDirectory, int maxDepth, int currentDepth);
}