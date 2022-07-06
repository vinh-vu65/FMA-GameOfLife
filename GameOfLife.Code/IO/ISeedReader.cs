namespace GameOfLife.Code.IO;

public interface ISeedReader
{
    Dictionary<string, string> SeedFilesMenu { get; }

    string[] Read(string filePath);
    string[] GetFilenames();
}