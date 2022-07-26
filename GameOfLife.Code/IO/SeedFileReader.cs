using System.Configuration;
using System.Reflection;

namespace GameOfLife.Code.IO;

public class SeedFileReader : ISeedReader
{
    public Dictionary<string, string> SeedFilesMenu { get; }
    private readonly string _basePath;
    
    public SeedFileReader()
    {
        _basePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, ConfigurationManager.AppSettings.Get("seedsFolder")!);
        SeedFilesMenu = CreateSeedFilesMenu();
    }
    
    public string[] Read(string filePath)
    {
        var seedPath = JoinFileToPath(filePath);
        return File.ReadAllLines(seedPath);
    }

    private string JoinFileToPath(string fileName)
    {
        return Path.Combine(_basePath, fileName);
    }

    public string[] GetFilenames()
    {
        var d = new DirectoryInfo(_basePath);
        var files = d.GetFiles();
        return files.Select(f => f.Name).OrderBy(name => name).ToArray();
    }
    
    private Dictionary<string, string> CreateSeedFilesMenu()
    {
        var fileNames = GetFilenames();
        var output = new Dictionary<string, string>();

        for (var i = 0; i < fileNames.Length; i++)
        {
            output.Add($"{i + 1}", fileNames[i]);
        }

        return output;
    }
}