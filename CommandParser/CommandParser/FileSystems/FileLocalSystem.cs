using CommandParser.Commands.ShowModes;

namespace CommandParser.FileSystems;

public class FileLocalSystem : IFileSystem
{
    public void Move(ISystemPath sourcePath, ISystemPath destinationPath)
    {
        File.Move(
            sourcePath.PathDirectory,
            Path.Combine(destinationPath.PathDirectory, Path.GetFileName(sourcePath.PathDirectory)));
    }

    public void Copy(ISystemPath sourcePath, ISystemPath destinationPath)
    {
        File.Copy(
            sourcePath.PathDirectory,
            Path.Combine(
                destinationPath.PathDirectory,
                Path.GetFileName(sourcePath.PathDirectory)),
            true);
    }

    public void Show(ISystemPath path, IShowMode mode)
    {
        string content = File.ReadAllText(path.PathDirectory);
        mode.Write(content);
    }

    public void Rename(ISystemPath path, string name)
    {
        string newPath = Path.Combine(Path.GetDirectoryName(path.PathDirectory) ?? string.Empty, name);
        if (!string.IsNullOrEmpty(newPath))
            Move(path, new SystemPath(newPath));
    }

    public void Delete(ISystemPath path)
    {
        File.Delete(path.PathDirectory);
    }

    public ISystemPath TreeGoto(ISystemPath globalPath, ISystemPath path)
    {
        return new SystemPath(Path.Combine(globalPath.PathDirectory, Path.GetFileName(path.PathDirectory)));
    }

    public SystemPathComposite TreeList(string rootDirectory, int maxDepth, int currentDepth)
    {
        var root = new SystemPathComposite(rootDirectory);

        if (currentDepth >= maxDepth)
        {
            return root;
        }

        string[] files = Directory.GetFiles(rootDirectory);
        foreach (string file in files)
        {
            root.AddChild(new SystemPath(file));
        }

        string[] subdirectories = Directory.GetDirectories(rootDirectory);
        foreach (string subdirectory in subdirectories)
        {
            SystemPathComposite subdirectoryNode =
                TreeList(subdirectory, maxDepth, currentDepth + 1);
            root.AddChild(subdirectoryNode);
        }

        return root;
    }
}