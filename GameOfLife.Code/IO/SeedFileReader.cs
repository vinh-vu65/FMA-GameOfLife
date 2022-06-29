using System.Reflection;

namespace GameOfLife.Code.IO;

public class SeedFileReader : ISeedReader
{
    private readonly string _filePath;
    
    public SeedFileReader(string fileName)
    {
        _filePath = CreateFilePath(fileName);
    }
    
    public string[] Read()
    {
        return File.ReadAllLines(_filePath);
    }

    private string CreateFilePath(string fileName)
    {
        var seedsFolder = "Seeds";
        return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, seedsFolder, fileName);
    }
}