using System.Reflection;

namespace GameOfLife.Code.IO;

public class FileReader : IReader
{
    private readonly string _filePath;
    
    public FileReader(string fileName)
    {
        _filePath = CreateFilePath(fileName);
    }
    
    public string[] Read()
    {
        return File.ReadAllLines(_filePath);
    }

    private string CreateFilePath(string fileName)
    {
        return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, "Seeds", fileName);
    }
}