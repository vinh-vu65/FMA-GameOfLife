namespace GameOfLife.Code.Service;

public class SeedGenerator
{
    public int Rows { get; private set; }
    public int Columns { get; private set; }
    
    public string[] ReadFile(string filePath)
    {
        return File.ReadAllLines($"../../../{filePath}");
    }

    public void SetWorldDimensions(string[] seed)
    {
        Rows = seed.Length;
        var lastLine = seed[Rows - 1];
        Columns = lastLine.IndexOf('*') + 1;
    }
}